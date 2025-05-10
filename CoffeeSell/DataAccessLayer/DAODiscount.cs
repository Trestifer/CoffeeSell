using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAODiscount : DAO
    {
        public int CreateDiscount(Discount discount)
        {
            string cmString = @"
                INSERT INTO Discount (NameDiscount, IsUseable, IsReuseable, EndDate, Detail, DiscountPercent, PointRequire)
                OUTPUT INSERTED.DiscountId
                VALUES (@Name, @IsUseable, @IsReuseable, @EndDate, @Detail, @Percent, @PointRequire)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new[] { "@Name", "@IsUseable", "@IsReuseable", "@EndDate", "@Detail", "@Percent", "@PointRequire" },
                    new object[]
                    {
                        discount.GetNameDiscount(),
                        discount.GetIsUseable(),
                        discount.GetIsReuseable(),
                        discount.GetEndDate(),
                        discount.GetDetail(),
                        discount.GetDiscountPercent(),
                        discount.GetPointRequire()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateDiscount error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateDiscount(Discount discount)
        {
            string cmString = @"
                UPDATE Discount
                SET NameDiscount = @Name, IsUseable = @IsUseable, IsReuseable = @IsReuseable,
                    EndDate = @EndDate, Detail = @Detail, DiscountPercent = @Percent, PointRequire = @PointRequire
                WHERE DiscountId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new[] { "@Name", "@IsUseable", "@IsReuseable", "@EndDate", "@Detail", "@Percent", "@PointRequire", "@Id" },
                    new object[]
                    {
                        discount.GetNameDiscount(),
                        discount.GetIsUseable(),
                        discount.GetIsReuseable(),
                        discount.GetEndDate(),
                        discount.GetDetail(),
                        discount.GetDiscountPercent(),
                        discount.GetPointRequire(),
                        discount.GetDiscountId()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateDiscount error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteDiscount(int id)
        {
            string cmString = "DELETE FROM Discount WHERE DiscountId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new[] { "@Id" },
                    new object[] { id }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteDiscount error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllDiscounts()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM Discount");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDiscounts error: {ex.Message}");
                return new DataTable();
            }
        }

        public Discount GetDiscountById(int id)
        {
            string cmString = "SELECT * FROM Discount WHERE DiscountId = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    Discount d = new Discount();
                    d.SetDiscountId(Convert.ToInt32(r["DiscountId"]));
                    d.SetNameDiscount(r["NameDiscount"].ToString());
                    d.SetIsUseable(Convert.ToBoolean(r["IsUseable"]));
                    d.SetIsReuseable(Convert.ToBoolean(r["IsReuseable"]));
                    d.SetEndDate(r["EndDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["EndDate"]));
                    d.SetDetail(r["Detail"]?.ToString());
                    d.SetDiscountPercent(Convert.ToDecimal(r["DiscountPercent"]));
                    d.SetPointRequire(Convert.ToInt32(r["PointRequire"]));
                    return d;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDiscountById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxDiscountId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(DiscountId), 0) FROM Discount");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxDiscountId error: {ex.Message}");
                return -1;
            }
        }
        public bool UpdateIsUseable(int discountId, bool usable, DateTime? endDate)
        {
            string cmString = "UPDATE Discount SET IsUseable = @IsUseable, EndDate = @EndDate WHERE DiscountId = @Id";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new[] { "@IsUseable", "@EndDate", "@Id" },
                    new object[] { usable ? 1 : 0, (object?)endDate ?? DBNull.Value, discountId });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateIsUseable error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAvailableDiscountsForCustomer(int customerId)
        {
            string cmString = @"
        SELECT * FROM Discount d
        WHERE IsUseable = 1 AND (
            d.IsReuseable = 1
            OR NOT EXISTS (
                SELECT 1 FROM UsedDiscount ud
                WHERE ud.CustomerId = @CustomerId AND ud.DiscountId = d.DiscountId
            )
        )
        AND (
            d.PointRequire = 0
            OR d.PointRequire = (
                SELECT MAX(PointRequire)
                FROM Discount
                WHERE PointRequire <= (
                    SELECT Points FROM Customer WHERE CustomerId = @CustomerId
                )
            )
        )";

            try
            {
                return ExecuteQuery(
                    cmString,
                    new[] { "@CustomerId" },
                    new object[] { customerId });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAvailableDiscountsForCustomer error: {ex.Message}");
                return new DataTable();
            }
        }

    }
}
