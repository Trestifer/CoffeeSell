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
    }
}
