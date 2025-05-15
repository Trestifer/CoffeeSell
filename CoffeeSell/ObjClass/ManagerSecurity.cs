using System;

namespace CoffeeSell.ObjClass
{
    public class ManagerSecurity
    {
        private int Id { get; set; }
        private string LoginName { get; set; }
        private string EncodingFace { get; set; }
        private string Email { get; set; }
        private string CurrentOTP { get; set; }
        private DateTime OTPExpired { get; set; }

        public ManagerSecurity() { }

        public ManagerSecurity(int id, string loginName, string encodingFace, string email, string currentOTP, DateTime otpExpired)
        {
            Id = id;
            LoginName = loginName;
            EncodingFace = encodingFace;
            Email = email;
            CurrentOTP = currentOTP;
            OTPExpired = otpExpired;
        }

        public int GetId() => Id;
        public string GetLoginName() => LoginName;
        public string GetEncodingFace() => EncodingFace;
        public string GetEmail() => Email;
        public string GetCurrentOTP() => CurrentOTP;
        public DateTime GetOTPExpired() => OTPExpired;

        public void SetId(int id) => Id = id;
        public void SetLoginName(string loginName) => LoginName = loginName;
        public void SetEncodingFace(string encodingFace) => EncodingFace = encodingFace;
        public void SetEmail(string email) => Email = email;
        public void SetCurrentOTP(string currentOTP) => CurrentOTP = currentOTP;
        public void SetOTPExpired(DateTime otpExpired) => OTPExpired = otpExpired;
    }
}
