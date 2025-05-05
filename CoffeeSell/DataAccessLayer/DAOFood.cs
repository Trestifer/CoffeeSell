using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOFood : DAO
    {
        public int CreateFood(Food food)
        {
            string cmString = @"
                INSERT INTO Food (NameFood, CategoryId, Price_S, Price_M, Price_L)
                OUTPUT INSERTED.FoodId
                VALUES (@Name, @CatId, @PriceS, @PriceM, @PriceL)";

            try
            {
                decimal[] prices = food.GetPrice();

                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@Name", "@CatId", "@PriceS", "@PriceM", "@PriceL" },
                    new object[]
                    {
                food.GetNameFood(),
                food.GetCategoryId(),
                prices[0],
                prices[1],
                prices[2]
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateFood error: {ex.Message}");
                return -1;
            }
        }


        public bool UpdateFood(Food food)
        {
            string cmString = @"
                UPDATE Food
                SET NameFood = @Name, CategoryId = @CatId, Price_S = @PriceS, Price_M = @PriceM, Price_L = @PriceL
                WHERE FoodId = @Id";

            try
            {
                decimal[] prices = food.GetPrice();

                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Name", "@CatId", "@PriceS", "@PriceM", "@PriceL", "@Id" },
                    new object[]
                    {
                food.GetNameFood(),
                food.GetCategoryId(),
                prices[0],
                prices[1],
                prices[2],
                food.GetFoodId()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateFood error: {ex.Message}");
                return false;
            }
        }


        public bool DeleteFood(int foodId)
        {
            string cmString = "DELETE FROM Food WHERE FoodId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { foodId }) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteFood error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllFood()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM Food");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllFood error: {ex.Message}");
                return new DataTable();
            }
        }

        public int GetMaxFoodId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(FoodId), 0) FROM Food");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetMaxFoodId error: {ex.Message}");
                return -1;
            }
        }
    }
}
