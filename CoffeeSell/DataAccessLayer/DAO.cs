using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CoffeeSell.DataAccessLayer
{
    public class DAO
    {
        protected readonly string conn = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";


        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
        protected DataTable ExecuteQuery(string query, string[] paramNames, object[] paramValues)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        protected DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(query, new string[0], new object[0]);
        }

        protected int ExecuteNonQuery(string query, string[] paramNames, object[] paramValues)
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
        protected object ExecuteScalar(string query, string[] parameterNames, object[] parameterValues)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < parameterNames.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parameterNames[i], parameterValues[i]);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }
        protected object ExecuteScalar(string query)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
     
    }

}
