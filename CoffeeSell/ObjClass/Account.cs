using System;
namespace CoffeeSell.ObjClass
{
    public class Account
    {
        private int AccountId { get; set; }
        private string LoginName { get; set; }
        private string PasswordHash { get; set; }
        private string DisplayName { get; set; }
        private bool TypeAccount { get; set; }  // 0: Employee, 1: Manager

        public Account() { }

        public Account(int accountId, string loginName, string passwordHash, string displayName, bool typeAccount)
        {
            AccountId = accountId;
            LoginName = loginName;
            PasswordHash = passwordHash;
            DisplayName = displayName;
            TypeAccount = typeAccount;
        }

        public int GetAccountId() => AccountId;
        public string GetLoginName() => LoginName;
        public string GetPasswordHash() => PasswordHash;
        public string GetDisplayName() => DisplayName;
        public bool GetTypeAccount() => TypeAccount;

    }
}
