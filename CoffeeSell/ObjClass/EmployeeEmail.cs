namespace CoffeeSell.ObjClass
{
    public class EmployeeEmail : EmailSecurity
    {
        private int employeeId;

        public EmployeeEmail() { }

        public EmployeeEmail(int EmailId, int employeeId, string email, bool isConfirmed, string currentOTP, DateTime otpExpired)
        {
            SetId(EmailId);
            this.employeeId = employeeId;
            SetEmail(email);
            SetIsConfirmed(isConfirmed);
            SetCurrentOTP(currentOTP);
            SetOTPExpired(otpExpired);
        }

        public int GetEmployeeId() => employeeId;
        public void SetEmployeeId(int value) => employeeId = value;
    }
}
