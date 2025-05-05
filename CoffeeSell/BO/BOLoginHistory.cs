using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOLoginHistory
    {
        static DAOLoginHistory lgh = new DAOLoginHistory();
        static void SuccessLogin(int accountId)
        {
            LoginHistory loginHistory = new LoginHistory();
            loginHistory.SetIdAccount(accountId);
            loginHistory.SetSuccessfulLogin(true);
            loginHistory.SetLoginTime(DateTime.Now);
        }
        static void FailureLogin(int accountId)
        {
            LoginHistory loginHistory = new LoginHistory();
            loginHistory.SetIdAccount(accountId);
            loginHistory.SetSuccessfulLogin(false);
            loginHistory.SetLoginTime(DateTime.Now);
        }
        static void Logout(int accountId)
        {
            LoginHistory loginHistory = lgh.GetLatestSuccessfulLogin(accountId);
            lgh.UpdateLogoutTime(loginHistory.GetId(), DateTime.Now);
        }
    }
}
