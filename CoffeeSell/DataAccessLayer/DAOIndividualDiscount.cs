using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOIndividualDiscount : DAO
    {
        public bool CreateIndividualDiscount(IndividualDiscount ind)
        {
            string cmString = @"
                INSERT INTO IndividualDiscount (CustomerId, DiscountId, Date_End)
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
                Console.WriteLine($"CreateIndividualDiscount error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteIndividualDiscount(int customerId, int discountId)
        {
            string cmString = @"
                DELETE FROM IndividualDiscount
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
                Console.WriteLine($"DeleteIndividualDiscount error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllIndividualDiscounts()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM IndividualDiscount");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllIndividualDiscounts error: {ex.Message}");
                return new DataTable();
            }
        }

        public IndividualDiscount GetIndividualDiscount(int customerId, int discountId)
        {
            string cmString = @"
                SELECT * FROM IndividualDiscount
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
                    ind.SetDateEnd(Convert.ToDateTime(r["Date_End"]));
                    return ind;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetIndividualDiscount error: {ex.Message}");
                return null;
            }
        }
    }
}
