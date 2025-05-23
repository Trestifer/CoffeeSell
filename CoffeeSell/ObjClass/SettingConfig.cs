namespace CoffeeSell.ObjClass
{
    public class SettingConfig
    {
        private string storeName;
        private string address;
        private string wifi;
        private string password;
        private string slogan;
        private string bankName;
        private string bank;
        private string bankAccountNumber;

        public SettingConfig() { }

        public SettingConfig(string storeName, string address, string wifi, string password, string slogan, string bankName, string bank, string bankAccountNumber)
        {
            this.storeName = storeName;
            this.address = address;
            this.wifi = wifi;
            this.password = password;
            this.slogan = slogan;
            this.bankName = bankName;
            this.bank = bank;
            this.bankAccountNumber = bankAccountNumber;
        }

        public string GetStoreName() => storeName;
        public void SetStoreName(string value) => storeName = value;

        public string GetAddress() => address;
        public void SetAddress(string value) => address = value;

        public string GetWifi() => wifi;
        public void SetWifi(string value) => wifi = value;

        public string GetPassword() => password;
        public void SetPassword(string value) => password = value;

        public string GetSlogan() => slogan;
        public void SetSlogan(string value) => slogan = value;

        public string GetBankName() => bankName;
        public void SetBankName(string value) => bankName = value;

        public string GetBank() => bank;
        public void SetBank(string value) => bank = value;

        public string GetBankAccountNumber() => bankAccountNumber;
        public void SetBankAccountNumber(string value) => bankAccountNumber = value;
    }
}