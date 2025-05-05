using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOCategory : DAO
    {
        public int CreateCategory(Category category)
        {
            string cmString = @"
                INSERT INTO Category (NameCategory)
                OUTPUT INSERTED.CategoryId
                VALUES (@Name)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@Name" },
                    new object[] { category.GetCategoryName() });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateCategory error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateCategory(Category category)
        {
            string cmString = @"
                UPDATE Category
                SET NameCategory = @Name
                WHERE CategoryId = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Name", "@Id" },
                    new object[] { category.GetCategoryName(), category.GetCategoryID() });

                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateCategory error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            string cmString = "DELETE FROM Category WHERE CategoryId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id }) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteCategory error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllCategory()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM Category");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllCategory error: {ex.Message}");
                return new DataTable();
            }
        }

        public Category GetCategoryById(int id)
        {
            string cmString = "SELECT * FROM Category WHERE CategoryId = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    Category c = new Category();
                    c.SetCategoryID(Convert.ToInt32(r["CategoryId"]));
                    c.SetCategoryName(r["NameCategory"].ToString());
                    return c;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCategoryById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxCategoryId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(CategoryId), 0) FROM Category");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetMaxCategoryId error: {ex.Message}");
                return -1;
            }
        }
    }
}
