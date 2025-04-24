using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeSell.DAO
{
    public class DAO
    {
        protected readonly string conn = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105";


        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
    
                SqlDataAdapter adap = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                return dt;
            }
        }

        public int ExecuteNonQuery(string query, string[] paramNames, object[] paramValues)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (paramNames != null && paramValues != null)
                {
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
        }
    }

}
