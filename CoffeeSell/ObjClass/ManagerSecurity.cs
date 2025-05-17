namespace CoffeeSell.ObjClass
{
    public class ManagerSecurity : EmailSecurity
    {
        private string loginName;
        private string encodingFace;

        public ManagerSecurity() { }

        public ManagerSecurity(int id, string loginName, string encodingFace, string email, bool isConfirmed, string currentOTP, DateTime otpExpired)
        {
            SetId(id);
            this.loginName = loginName;
            this.encodingFace = encodingFace;
            SetEmail(email);
            SetIsConfirmed(isConfirmed);
            SetCurrentOTP(currentOTP);
            SetOTPExpired(otpExpired);
        }

        public string GetLoginName() => loginName;
        public string GetEncodingFace() => encodingFace;

        public void SetLoginName(string value) => loginName = value;
        public void SetEncodingFace(string value) => encodingFace = value;
    }
}
