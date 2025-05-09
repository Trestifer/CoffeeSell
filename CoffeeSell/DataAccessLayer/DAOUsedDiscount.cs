using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOUsedDiscount : DAO
    {
        // Create a new individual discount
        public bool CreateIndividualDiscount(IndividualDiscount ind)
        {
            string cmString = @"
                INSERT INTO UsedDiscount (CustomerId, DiscountId, DateEnd)
                VALUES (@CustomerId, @DiscountId, @DateEnd)";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new[] { "@CustomerId", "@DiscountId", "@DateEnd" },
                    new object[]
                    {
                        ind.GetCustomerId(),
                        ind.GetDiscountId(),
                        ind.GetDateEnd()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateIndividualDiscount error: {ex.Message}");
                return false;
            }
        }

        // Delete an individual discount
        public bool DeleteIndividualDiscount(int customerId, int discountId)
        {
            string cmString = @"
                DELETE FROM UsedDiscount
                WHERE CustomerId = @CustomerId AND DiscountId = @DiscountId";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new[] { "@CustomerId", "@DiscountId" },
                    new object[] { customerId, discountId });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteIndividualDiscount error: {ex.Message}");
                return false;
            }
        }

        // Get all individual discounts
        public DataTable GetAllIndividualDiscounts()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM UsedDiscount");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllIndividualDiscounts error: {ex.Message}");
                return new DataTable();
            }
        }

        // Get a specific individual discount by customerId and discountId
        public IndividualDiscount GetIndividualDiscount(int customerId, int discountId)
        {
            string cmString = @"
                SELECT * FROM UsedDiscount
                WHERE CustomerId = @CustomerId AND DiscountId = @DiscountId";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new[] { "@CustomerId", "@DiscountId" },
                    new object[] { customerId, discountId });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    IndividualDiscount ind = new IndividualDiscount();
                    ind.SetCustomerId(Convert.ToInt32(r["CustomerId"]));
                    ind.SetDiscountId(Convert.ToInt32(r["DiscountId"]));
                    ind.SetDateEnd(Convert.ToDateTime(r["DateEnd"]));
                    return ind;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetIndividualDiscount error: {ex.Message}");
                return null;
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
