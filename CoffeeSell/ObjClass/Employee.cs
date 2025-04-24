using System;

namespace CoffeeSell.ObjClass
{
    public class Employee
    {
        private int EmployeeId { get; set; }
        private string NameEmployee { get; set; }
        private DateTime DateOfBirth { get; set; }
        private bool Gender { get; set; }  // 0: Male, 1: Female
        private string HomeAddress { get; set; }
        private string PhoneNumber { get; set; }
        private int AccountId { get; set; }  // Links to Account

        public Employee() { }

        public Employee(int employeeId, string nameEmployee, DateTime dateOfBirth, bool gender, string homeAddress, string phoneNumber, int accountId)
        {
            EmployeeId = employeeId;
            NameEmployee = nameEmployee;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            HomeAddress = homeAddress;
            PhoneNumber = phoneNumber;
            AccountId = accountId;
        }

        public int GetEmployeeId() => EmployeeId;
        public string GetNameEmployee() => NameEmployee;
        public DateTime GetDateOfBirth() => DateOfBirth;
        public bool GetGender() => Gender;
        public string GetHomeAddress() => HomeAddress;
        public string GetPhoneNumber() => PhoneNumber;
        public int GetAccountId() => AccountId;
        public void SetEmployeeId(int employeeId) => EmployeeId = employeeId;
        public void SetNameEmployee(string nameEmployee) => NameEmployee = nameEmployee;
        public void SetDateOfBirth(DateTime dateOfBirth) => DateOfBirth = dateOfBirth;
        public void SetGender(bool gender) => Gender = gender;
        public void SetHomeAddress(string homeAddress) => HomeAddress = homeAddress;
        public void SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void SetAccountId(int accountId) => AccountId = accountId;
    }
}
