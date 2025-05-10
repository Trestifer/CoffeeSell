using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOLoginHistory : DAO
    {
        public int CreateLoginHistory(LoginHistory history)
        {
            string cmString = @"
                INSERT INTO LoginHistory (IdAccount, LoginTime, LogoutTime, SuccessfulLogin)
                OUTPUT INSERTED.Id
                VALUES (@AccountId, @LoginTime, @LogoutTime, @Success)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@AccountId", "@LoginTime", "@LogoutTime", "@Success" },
                    new object[]
                    {
                        history.GetIdAccount(),
                        history.GetLoginTime(),
                        history.GetLogoutTime() ?? (object)DBNull.Value,
                        history.GetSuccessfulLogin()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateLoginHistory error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateLogoutTime(int historyId, DateTime logoutTime)
        {
            string cmString = @"
                UPDATE LoginHistory
                SET LogoutTime = @LogoutTime
                WHERE Id = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@LogoutTime", "@Id" },
                    new object[] { logoutTime, historyId });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateLogoutTime error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllLoginHistory()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM LoginHistory");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllLoginHistory error: {ex.Message}");
                return new DataTable();
            }
        }

        public LoginHistory GetLoginHistoryById(int id)
        {
            string cmString = "SELECT * FROM LoginHistory WHERE Id = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    LoginHistory lh = new LoginHistory();
                    lh.SetId(Convert.ToInt32(r["Id"]));
                    lh.SetIdAccount(Convert.ToInt32(r["IdAccount"]));
                    lh.SetLoginTime(Convert.ToDateTime(r["LoginTime"]));
                    lh.SetLogoutTime(r["LogoutTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["LogoutTime"]));
                    lh.SetSuccessfulLogin(Convert.ToBoolean(r["SuccessfulLogin"]));
                    return lh;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetLoginHistoryById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxLoginHistoryId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(Id), 0) FROM LoginHistory");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxLoginHistoryId error: {ex.Message}");
                return -1;
            }
        }
        public LoginHistory GetLatestSuccessfulLogin(int accountId)
        {
            string cmString = @"
        SELECT TOP 1 * FROM LoginHistory
        WHERE IdAccount = @AccountId AND SuccessfulLogin = 1
        ORDER BY LoginTime DESC";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@AccountId" },
                    new object[] { accountId });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    LoginHistory lh = new LoginHistory();
                    lh.SetId(Convert.ToInt32(r["Id"]));
                    lh.SetIdAccount(Convert.ToInt32(r["IdAccount"]));
                    lh.SetLoginTime(Convert.ToDateTime(r["LoginTime"]));
                    lh.SetLogoutTime(r["LogoutTime"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r["LogoutTime"]));
                    lh.SetSuccessfulLogin(Convert.ToBoolean(r["SuccessfulLogin"]));
                    return lh;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetLatestSuccessfulLogin error: {ex.Message}");
                return null;
            }
        }
        public DataTable GetLoginHistoryWithUsernames()
        {
            string cmString = @"
        SELECT 
            lh.Id AS LoginHistoryId,
            acc.LoginName,
            lh.LoginTime,
            lh.LogoutTime,
            lh.SuccessfulLogin
        FROM 
            LoginHistory lh
        INNER JOIN 
            Account acc ON lh.IdAccount = acc.AccountId
        ORDER BY 
            lh.LoginTime DESC"; // Change to ASC for oldest first

            try
            {
                return ExecuteQuery(cmString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetLoginHistoryWithUsernames error: {ex.Message}");
                return new DataTable();
            }
        }


    }
}
