using CoffeeSell.DAO;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOAccount
    {
        static DAOAccount account = new DAOAccount();
        public static int CreateAccount(Account accountInfo)
        {
            accountInfo.SetPasswordHash(Security.HashPassword(accountInfo.GetPasswordHash()));
            return account.CreateAccount(accountInfo);
        }
        public static Account Login(Account accountInfo)
        {
            accountInfo.SetPasswordHash(Security.HashPassword(accountInfo.GetPasswordHash()));
            return account.Login(accountInfo);
        }
        public static DataTable GetAllAccount() { return account.GetAllAccount(); }
    }
}
