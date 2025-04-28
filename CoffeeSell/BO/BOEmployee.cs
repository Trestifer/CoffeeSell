using CoffeeSell.DAO;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
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
            loginName: employeeInfo.GetNameEmployee().Replace(" ", "").ToLower() + maxAccontId,
            passwordHash: Security.HashPassword("changeme"),
            displayName: employeeInfo.GetNameEmployee(),
            typeAccount: false
            );
            employeeInfo.SetAccountId(account.CreateAccount(temp));
            if (employeeInfo.GetAccountId() < 0)
                return false;
            return employee.AddEmployee(employeeInfo);
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

    }
}
