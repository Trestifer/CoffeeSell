using System;
using System.Data;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAORanking : DAO
    {
        public Ranking GetRanking()
        {
            string query = "SELECT TOP 1 * FROM Ranking";

            try
            {
                DataTable dt = ExecuteQuery(query);
                if (dt.Rows.Count == 1)
                {
                    DataRow row = dt.Rows[0];
                    return new Ranking(
                        Convert.ToInt32(row["Dong"]),
                        Convert.ToInt32(row["Bac"]),
                        Convert.ToInt32(row["Vang"]),
                        Convert.ToInt32(row["KiemCuong"])
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetRanking error: {ex.Message}");
                return null;
            }
        }

        public bool UpdateRanking(Ranking ranking)
        {
            string query = @"
                UPDATE Ranking
                SET Dong = @Dong,
                    Bac = @Bac,
                    Vang = @Vang,
                    KiemCuong = @KiemCuong";

            try
            {
                int rows = ExecuteNonQuery(
                    query,
                    new string[] { "@Dong", "@Bac", "@Vang", "@KiemCuong" },
                    new object[] { ranking.Dong, ranking.Bac, ranking.Vang, ranking.KiemCuong });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateRanking error: {ex.Message}");
                return false;
            }
        }
    }
}
