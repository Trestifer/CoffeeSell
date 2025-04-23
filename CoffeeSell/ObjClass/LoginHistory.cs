using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class LoginHistory
    {
        // Private auto-properties
        private int Id { get; set; }
        private int IdAccount { get; set; }
        private DateTime LoginTime { get; set; }
        private DateTime? LogoutTime { get; set; }
        private bool SuccessfulLogin { get; set; }

        // Default constructor
        public LoginHistory() { }

        // Parameterized constructor
        public LoginHistory(int id, int idAccount, DateTime loginTime, DateTime? logoutTime, bool successfulLogin)
        {
            Id = id;
            IdAccount = idAccount;
            LoginTime = loginTime;
            LogoutTime = logoutTime;
            SuccessfulLogin = successfulLogin;
        }

        // Public getter methods
        public int GetId() => Id;
        public int GetIdAccount() => IdAccount;
        public DateTime GetLoginTime() => LoginTime;
        public DateTime? GetLogoutTime() => LogoutTime;
        public bool GetSuccessfulLogin() => SuccessfulLogin;
    }
}

