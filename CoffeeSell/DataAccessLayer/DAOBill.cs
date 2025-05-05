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
                INSERT INTO Bill (DateCheckIn, DateCheckOut, TotalPrice, StatusBill, CustomerId)
                OUTPUT INSERTED.BillId
                VALUES (@CheckIn, @CheckOut, @Total, @Status, @CustomerId)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@CheckIn", "@CheckOut", "@Total", "@Status", "@CustomerId" },
                    new object[]
                    {
                        bill.GetDateCheckIn(),
                        bill.GetDateCheckOut() ?? (object)DBNull.Value,
                        bill.GetTotalPrice(),
                        bill.GetStatusBill(),
                        bill.GetCustomerId() ?? (object)DBNull.Value
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
                SET DateCheckIn = @CheckIn, DateCheckOut = @CheckOut,
                    TotalPrice = @Total, StatusBill = @Status, CustomerId = @CustomerId
                WHERE BillId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@CheckIn", "@CheckOut", "@Total", "@Status", "@CustomerId", "@Id" },
                    new object[]
                    {
                        bill.GetDateCheckIn(),
                        bill.GetDateCheckOut() ?? (object)DBNull.Value,
                        bill.GetTotalPrice(),
                        bill.GetStatusBill(),
                        bill.GetCustomerId() ?? (object)DBNull.Value,
                        bill.GetBillId()
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
                    Bill b = new Bill();
                    b.SetBillId(Convert.ToInt32(r["BillId"]));
                    b.SetDateCheckIn(Convert.ToDateTime(r["DateCheckIn"]));
                    b.SetDateCheckOut(r["DateCheckOut"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["DateCheckOut"]));
                    b.SetTotalPrice(Convert.ToDecimal(r["TotalPrice"]));
                    b.SetStatusBill(Convert.ToInt32(r["StatusBill"]));
                    b.SetCustomerId(r["CustomerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["CustomerId"]));
                    return b;
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
    }
}
