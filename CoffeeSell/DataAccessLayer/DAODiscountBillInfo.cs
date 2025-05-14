using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAODiscountBillInfo : DAO
    {
        public bool InsertDiscountBillInfo(DiscountBillInfo info)
        {
            string query = @"
                INSERT INTO DiscountBillInfo (BillId, DiscountId, Saved)
                VALUES (@BillId, @DiscountId, @Saved)";
            try
            {
                return ExecuteNonQuery(
                    query,
                    new string[] { "@BillId", "@DiscountId", "@Saved" },
                    new object[]
                    {
                        info.GetBillId() ?? (object)DBNull.Value,
                        info.GetDiscountId() ?? (object)DBNull.Value,
                        info.GetSaved()
                    }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertDiscountBillInfo error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetDiscountsByBillId(int billId)
        {
            string query = "SELECT * FROM DiscountBillInfo WHERE BillId = @BillId";
            try
            {
                return ExecuteQuery(
                    query,
                    new string[] { "@BillId" },
                    new object[] { billId });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDiscountsByBillId error: {ex.Message}");
                return new DataTable();
            }
        }

        public bool DeleteDiscountsByBillId(int billId)
        {
            string query = "DELETE FROM DiscountBillInfo WHERE BillId = @BillId";
            try
            {
                return ExecuteNonQuery(
                    query,
                    new string[] { "@BillId" },
                    new object[] { billId }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteDiscountsByBillId error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllDiscountBillInfo()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM DiscountBillInfo");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDiscountBillInfo error: {ex.Message}");
                return new DataTable();
            }
        }

        public DiscountBillInfo GetDiscountBillInfoById(int discountInfoId)
        {
            string cmString = "SELECT * FROM DiscountBillInfo WHERE DiscountInfoId = @InfoId";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@InfoId" },
                    new object[] { discountInfoId });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    DiscountBillInfo info = new DiscountBillInfo();
                    info.SetDiscountInfoId(Convert.ToInt32(r["DiscountInfoId"]));
                    info.SetDiscountId(Convert.ToInt32(r["DiscountId"]));
                    info.SetSaved(Convert.ToDecimal(r["Saved"]));
                    return info;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDiscountBillInfoById error: {ex.Message}");
                return null;
            }
        }
    }
}
