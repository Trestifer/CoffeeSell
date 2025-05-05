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
                INSERT INTO Discount (NameDiscount, IsUseable, IsIndividual, Discount, DiscountPercent, Scheduling)
                OUTPUT INSERTED.DiscountId
                VALUES (@Name, @IsUseable, @IsIndividual, @Discount, @Percent, @Schedule)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new[] { "@Name", "@IsUseable", "@IsIndividual", "@Discount", "@Percent", "@Schedule" },
                    new object[]
                    {
                        discount.GetNameDiscount(),
                        discount.GetIsUseable(),
                        discount.GetIsIndividual(),
                        discount.GetDiscountValue(),
                        discount.GetDiscountPercent(),
                        discount.GetScheduling()
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
                SET NameDiscount = @Name, IsUseable = @IsUseable, IsIndividual = @IsIndividual,
                    Discount = @Discount, DiscountPercent = @Percent, Scheduling = @Schedule
                WHERE DiscountId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new[] { "@Name", "@IsUseable", "@IsIndividual", "@Discount", "@Percent", "@Schedule", "@Id" },
                    new object[]
                    {
                        discount.GetNameDiscount(),
                        discount.GetIsUseable(),
                        discount.GetIsIndividual(),
                        discount.GetDiscountValue(),
                        discount.GetDiscountPercent(),
                        discount.GetScheduling(),
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
                    d.SetIsIndividual(Convert.ToBoolean(r["IsIndividual"]));
                    d.SetDiscountValue(Convert.ToInt32(r["Discount"]));
                    d.SetDiscountPercent(Convert.ToInt32(r["DiscountPercent"]));
                    d.SetScheduling(Convert.ToInt32(r["Scheduling"]));
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
    }
}
