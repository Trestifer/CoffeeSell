namespace CoffeeSell.ObjClass
{
    public class EmailSecurity
    {
        private int id;
        private string email;
        private bool isConfirmed;
        private string currentOTP;
        private DateTime otpExpired;

        public int GetId() => id;
        public string GetEmail() => email;
        public bool GetIsConfirmed() => isConfirmed;
        public string GetCurrentOTP() => currentOTP;
        public DateTime GetOTPExpired() => otpExpired;

        public void SetId(int value) => id = value;
        public void SetEmail(string value) => email = value;
        public void SetIsConfirmed(bool value) => isConfirmed = value;
        public void SetCurrentOTP(string value) => currentOTP = value;
        public void SetOTPExpired(DateTime value) => otpExpired = value;
    }
}
