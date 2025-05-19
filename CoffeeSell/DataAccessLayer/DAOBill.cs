using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOBill : DAO
    {
        public int CreateBill(Bill bill)
        {
            string cmString = @"
                INSERT INTO Bill (DateCheckIn, TotalPrice, CustomerId)
                OUTPUT INSERTED.BillId
                VALUES (@CheckIn, @Total,  @CustomerId)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@CheckIn", "@Total", "@CustomerId" },
                    new object[]
                    {
                        bill.DateCheckIn,
                        bill.TotalPrice,
                        bill.CustomerId ?? (object)DBNull.Value
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateBill error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateBill(Bill bill)
        {
            string cmString = @"
                UPDATE Bill
                SET DateCheckIn = @CheckIn,
                    TotalPrice = @Total,
                    CustomerId = @CustomerId
                WHERE BillId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@CheckIn", "@Total", "@CustomerId", "@Id" },
                    new object[]
                    {
                        bill.DateCheckIn,
                        bill.TotalPrice,
                        bill.CustomerId ?? (object)DBNull.Value,
                        bill.BillId
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateBill error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteBill(int billId)
        {
            string cmString = "DELETE FROM Bill WHERE BillId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { billId }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteBill error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllBill()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM Bill");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllBill error: {ex.Message}");
                return new DataTable();
            }
        }

        public Bill GetBillById(int id)
        {
            string cmString = "SELECT * FROM Bill WHERE BillId = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    return new Bill
                    {
                        BillId = Convert.ToInt32(r["BillId"]),
                        DateCheckIn = Convert.ToDateTime(r["DateCheckIn"]),
                        TotalPrice = Convert.ToDecimal(r["TotalPrice"]),
                        CustomerId = r["CustomerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["CustomerId"])
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetBillById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxBillId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(BillId), 0) FROM Bill");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxBillId error: {ex.Message}");
                return -1;
            }
        }
        public DataTable GetBillWithCustomerInfo()
        {
            string query = @"
        SELECT 
            b.BillId,
            b.DateCheckIn,
            b.TotalPrice,
            b.Photo,
            c.NameCustomer,
            c.PhoneNumber
        FROM 
            Bill b
        LEFT JOIN 
            Customer c ON b.CustomerId = c.CustomerId";

            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetBillWithCustomerInfo error: {ex.Message}");
                return new DataTable();
            }
        }
        public bool UpdateBillPhoto(int billId, string photo)
        {
            string cmString = @"
        UPDATE Bill
        SET Photo = @Photo
        WHERE BillId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Photo", "@Id" },
                    new object[] { photo, billId });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateBillPhoto error: {ex.Message}");
                return false;
            }
        }

    }
}
