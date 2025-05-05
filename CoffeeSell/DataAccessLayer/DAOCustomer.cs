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
                INSERT INTO Customer (NameCustomer, PhoneNumber, Points)
                OUTPUT INSERTED.CustomerId
                VALUES (@Name, @Phone, @Points)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@Name", "@Phone", "@Points" },
                    new object[]
                    {
                        cus.GetNameCustomer(),
                        cus.GetPhoneNumber(),
                        cus.GetPoints()
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
                SET NameCustomer = @Name, PhoneNumber = @Phone, Points = @Points
                WHERE CustomerId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Name", "@Phone", "@Points", "@Id" },
                    new object[]
                    {
                        cus.GetNameCustomer(),
                        cus.GetPhoneNumber(),
                        cus.GetPoints(),
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
    }
}
