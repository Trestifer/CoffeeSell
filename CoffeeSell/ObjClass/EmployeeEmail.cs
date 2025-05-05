using System;

namespace CoffeeSell.ObjClass
{
    public class EmployeeEmail
    {
        private int EmployeeId { get; set; }
        private string Email { get; set; }
        private bool IsConfirmed { get; set; }
        private string CurrentOTP { get; set; }
        private DateTime OTPExpired { get; set; }

        public EmployeeEmail() { }

        public EmployeeEmail(int employeeId, string email, bool isConfirmed, string currentOTP, DateTime otpExpired)
        {
            EmployeeId = employeeId;
            Email = email;
            IsConfirmed = isConfirmed;
            CurrentOTP = currentOTP;
            OTPExpired = otpExpired;
        }

        public int GetEmployeeId() => EmployeeId;
        public string GetEmail() => Email;
        public bool GetIsConfirmed() => IsConfirmed;
        public string GetCurrentOTP() => CurrentOTP;
        public DateTime GetOTPExpired() => OTPExpired;

        public void SetEmployeeId(int employeeId) => EmployeeId = employeeId;
        public void SetEmail(string email) => Email = email;
        public void SetIsConfirmed(bool isConfirmed) => IsConfirmed = isConfirmed;
        public void SetCurrentOTP(string currentOTP) => CurrentOTP = currentOTP;
        public void SetOTPExpired(DateTime otpExpired) => OTPExpired = otpExpired;
    }
}
