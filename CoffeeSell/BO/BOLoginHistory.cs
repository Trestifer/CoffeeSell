using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOLoginHistory
    {
        static DAOLoginHistory lgh = new DAOLoginHistory();
        public static void SuccessLogin(int accountId)
        {
            LoginHistory loginHistory = new LoginHistory();
            loginHistory.SetIdAccount(accountId);
            loginHistory.SetSuccessfulLogin(true);
            loginHistory.SetLoginTime(DateTime.Now);
            lgh.CreateLoginHistory(loginHistory);
        }
        public static void FailureLogin(string username)
        {
            LoginHistory loginHistory = new LoginHistory();
            Account account =BOAccount.GetAccount(username);
            if (account == null)
                return;
            loginHistory.SetIdAccount(account.GetAccountId());
            loginHistory.SetSuccessfulLogin(false);
            loginHistory.SetLoginTime(DateTime.Now);
            lgh.CreateLoginHistory(loginHistory);
        }
        public static void Logout(int accountId)
        {
            LoginHistory loginHistory = lgh.GetLatestSuccessfulLogin(accountId);
            lgh.UpdateLogoutTime(loginHistory.GetId(), DateTime.Now);
        }
        public static DataTable GetAllLoginHistory()
        {
            DataTable dt = lgh.GetAllLoginHistory();
            var sortedRows = dt.AsEnumerable()
                   .OrderByDescending(row => row.Field<DateTime>("LoginTime"))
                   .CopyToDataTable();

            return sortedRows;
        }
    }
}
