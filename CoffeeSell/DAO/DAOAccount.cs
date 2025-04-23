using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DAO
{
    public class DAOAccount :   DAO
    {
        public DataTable GetAllAccount()
        {
            string cmString = "Select * from Account";
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(cmString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public bool CreateAccount(Account accountInfo)
        {
            string cmString = "INSERT INTO Account (LoginName, PasswordHash, DisplayName, TypeAccount) " +
                              "VALUES (@LoginName, @PasswordHash, @DisplayName, @TypeAccount)";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@LoginName", "@PasswordHash", "@DisplayName", "@TypeAccount" },
                    new object[]
                    {
                accountInfo.GetLoginName(),
                accountInfo.GetPasswordHash(),
                accountInfo.GetDisplayName(),
                accountInfo.GetTypeAccount()
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating account: {ex.Message}");
                return false;
            }
        }

    }
}
