using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOEmployee
    {
        static DAOEmployee employee = new DAOEmployee();
        public static bool AddEmployee(Employee employeeInfo)
        {
            DAOAccount account = new DAOAccount();
            int maxAccontId = account.GetMaxAccountId();
            Account temp = new Account(
            accountId: 1,
            loginName: RemoveDiacritics(employeeInfo.GetNameEmployee().Replace(" ", "").ToLower()) + (maxAccontId+1),
            passwordHash: Security.HashPassword("changeme"),
            displayName: employeeInfo.GetNameEmployee(),
            typeAccount: false
            );
            employeeInfo.SetAccountId(account.CreateAccount(temp));
            if (employeeInfo.GetAccountId() < 0)
                return false;
            if (!employee.AddEmployee(employeeInfo)) ;
                
            int maxEmployeeId = employee.GetMaxEmployeeId();
            MessageBox.Show("" + maxEmployeeId);
            return BOEmployeeEmail.AddEmployeeEmail(maxEmployeeId);
        }
        public static DataTable GetAllEmployees()
        {
            return employee.GetAllEmployees();
        }
        public static bool DeleteEmployee(int id)
        {
            return employee.DeleteEmployee(id);
        }
        public static bool EditEmployee(Employee employeeInfo)
        {
            return employee.UpdateEmployee(employeeInfo);
        }

        public static bool CheckFirstLogin(int AccountId)
        {
            Employee _employee = employee.GetEmployeeByAccountId(AccountId);
            EmployeeEmail employeeEmail = BOEmployeeEmail.GetEmployeeById(_employee.GetEmployeeId());
            return employeeEmail.GetIsConfirmed();
        }
        public static EmployeeEmail GetEmployeeEmail(int AccountId)
        {
            Employee _employee = employee.GetEmployeeByAccountId(AccountId);
            return BOEmployeeEmail.GetEmployeeById(_employee.GetEmployeeId());
        }
        private static string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
