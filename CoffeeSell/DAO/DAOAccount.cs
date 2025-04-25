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

        public bool UpdateAccount(Account accountInfo)
        {
            string cmString = "UPDATE Account " +
                              "SET PasswordHash = @PasswordHash, DisplayName = @DisplayName, TypeAccount = @TypeAccount " +
                              "WHERE LoginName = @LoginName";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@PasswordHash", "@DisplayName", "@TypeAccount", "@LoginName" },
                    new object[]
                    {
                accountInfo.GetPasswordHash(),
                accountInfo.GetDisplayName(),
                accountInfo.GetTypeAccount(),
                accountInfo.GetLoginName()
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating account: {ex.Message}");
                return false;
            }
        }
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
        public int CreateAccount(Account accountInfo)
        {
            string cmString = @"
        INSERT INTO Account (LoginName, PasswordHash, DisplayName, TypeAccount)
        OUTPUT INSERTED.AccountId
        VALUES (@LoginName, @PasswordHash, @DisplayName, @TypeAccount)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@LoginName", "@PasswordHash", "@DisplayName", "@TypeAccount" },
                    new object[]
                    {
                accountInfo.GetLoginName(),
                accountInfo.GetPasswordHash(),
                accountInfo.GetDisplayName(),
                accountInfo.GetTypeAccount()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating account: {ex.Message}");
                return -1;
            }
        }

        public Account Login(Account accountInfo)
        {
            string cmString = "SELECT * FROM Account WHERE LoginName = @LoginName AND PasswordHash = @PasswordHash";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new string[] { "@LoginName", "@PasswordHash" },
                    new object[] { accountInfo.GetLoginName(), accountInfo.GetPasswordHash() }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    Account loggedInAccount = new Account();
                    loggedInAccount.SetLoginName(row["LoginName"].ToString());
                    loggedInAccount.SetPasswordHash(row["PasswordHash"].ToString());
                    loggedInAccount.SetDisplayName(row["DisplayName"].ToString());
                    loggedInAccount.SetTypeAccount(Convert.ToBoolean(row["TypeAccount"]));
                    return loggedInAccount;
                }
                else
                {
                    // No match found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }
        public Account Delete(int AccountId)
        {
            string cmString = "Delete FROM Account WHERE AccountId = @AccountId";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new string[] { "@AccountId"},
                    new object[] { AccountId }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    Account loggedInAccount = new Account();
                    loggedInAccount.SetLoginName(row["LoginName"].ToString());
                    loggedInAccount.SetPasswordHash(row["PasswordHash"].ToString());
                    loggedInAccount.SetDisplayName(row["DisplayName"].ToString());
                    loggedInAccount.SetTypeAccount(Convert.ToBoolean(row["TypeAccount"]));
                    return loggedInAccount;
                }
                else
                {
                    // No match found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during search: {ex.Message}");
                return null;
            }
        }
        public bool GetAccount(string LoginName)
        {
            string cmString = "SELECT * FROM Account WHERE LoginName = @LoginName";

            try
            {
                int result = ExecuteNonQuery(
                    cmString,
                    new string[] { "@LoginName" },
                    new object[] { LoginName }
                );

                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during delete: {ex.Message}");
                return false;
            }
        }
        public int GetMaxAccountId()
        {
            string cmString = "SELECT ISNULL(MAX(AccountId), 0) FROM Account";

            try
            {
                object result = ExecuteScalar(cmString);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting max AccountId: {ex.Message}");
                return -1;
            }
        }

    }
}
