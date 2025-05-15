using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOCustomer : DAO
    {
        public int CreateCustomer(Customer cus)
        {
            string cmString = @"
                INSERT INTO Customer (NameCustomer, PhoneNumber, Points, RegisterDate, LattestBuy)
                OUTPUT INSERTED.CustomerId
                VALUES (@Name, @Phone, @Points, @RegisterDate, @LattestBuy)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@Name", "@Phone", "@Points", "@RegisterDate", "@LattestBuy" },
                    new object[]
                    {
                        cus.GetNameCustomer(),
                        cus.GetPhoneNumber(),
                        cus.GetPoints(),
                        cus.GetRegisterDate(),
                        cus.GetLattestBuy()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateCustomer error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateCustomer(Customer cus)
        {
            string cmString = @"
                UPDATE Customer
                SET NameCustomer = @Name,
                    PhoneNumber = @Phone,
                    Points = @Points,
                    RegisterDate = @RegisterDate,
                    LattestBuy = @LattestBuy
                WHERE CustomerId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Name", "@Phone", "@Points", "@RegisterDate", "@LattestBuy", "@Id" },
                    new object[]
                    {
                        cus.GetNameCustomer(),
                        cus.GetPhoneNumber(),
                        cus.GetPoints(),
                        cus.GetRegisterDate(),
                        cus.GetLattestBuy(),
                        cus.GetCustomerId()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateCustomer error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            string cmString = "DELETE FROM Customer WHERE CustomerId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteCustomer error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllCustomer()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM Customer");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllCustomer error: {ex.Message}");
                return new DataTable();
            }
        }

        public Customer GetCustomerById(int id)
        {
            string cmString = "SELECT * FROM Customer WHERE CustomerId = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    Customer c = new Customer();
                    c.SetCustomerId(Convert.ToInt32(r["CustomerId"]));
                    c.SetNameCustomer(r["NameCustomer"].ToString());
                    c.SetPhoneNumber(r["PhoneNumber"].ToString());
                    c.SetPoints(Convert.ToInt32(r["Points"]));
                    c.SetRegisterDate(Convert.ToDateTime(r["RegisterDate"]));
                    c.SetLattestBuy(Convert.ToDateTime(r["LattestBuy"]));
                    return c;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetCustomerById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxCustomerId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(CustomerId), 0) FROM Customer");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxCustomerId error: {ex.Message}");
                return -1;
            }
        }


        public List<Customer> GetCustomerList()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customer";

            // Call your existing method
            DataTable dt = ExecuteQuery(query, new string[] { }, new object[] { });

            foreach (DataRow row in dt.Rows)
            {
                Customer cus = new Customer(
                    customerId: Convert.ToInt32(row["CustomerId"]),
                    nameCustomer: row["NameCustomer"].ToString(),
                    phoneNumber: row["PhoneNumber"].ToString(),
                    points: row["Points"] != DBNull.Value ? Convert.ToInt32(row["Points"]) : 0,
                    registerDate: row["RegisterDate"] != DBNull.Value ? Convert.ToDateTime(row["RegisterDate"]) : DateTime.MinValue,
                    lattestBuy: row["LattestBuy"] != DBNull.Value ? Convert.ToDateTime(row["LattestBuy"]) : DateTime.MinValue
                );

                customers.Add(cus);
            }

            return customers;
        }
        public bool ResetPointsIfInactive()
        {
            string cmString = @"
        UPDATE Customer
        SET Points = 0
        WHERE DATEDIFF(DAY, LattestBuy, GETDATE()) > 30";

            try
            {
                int result = ExecuteNonQuery(cmString,null,null);
                return result > 0; // True if updated
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ResetPointsIfInactive error: {ex.Message}");
                return false;
            }
        }



    }
}
