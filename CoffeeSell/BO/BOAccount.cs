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
    public class BOAccount
    {
        static DAOAccount account = new DAOAccount();
        public static int CreateAccount(Account accountInfo)
        {
            accountInfo.SetPasswordHash(Security.HashPassword(accountInfo.GetPasswordHash()));
            return account.CreateAccount(accountInfo);
        }
        public static Account Login(string username, string password)
        {
            return account.Login(username, Security.HashPassword(password));
        }
        public static Account GetAccount(string username)
        {
            return account.GetAccount(username);
        }
        public static DataTable GetAllAccount() { return account.GetAllAccount(); }

        public static bool UpdateAccount(Account accountInfo)
        {
            accountInfo.SetPasswordHash(Security.HashPassword(accountInfo.GetPasswordHash()));
            return account.UpdateAccount(accountInfo); 
        }
        public static bool Delete(int id)
        {
            return account.Delete(id);
        }
        
    }
}
