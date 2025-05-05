using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace CoffeeSell.BO
{
    public class BOEmployeeEmail
    {
        static DAOEmployeeEmail emailFuction = new DAOEmployeeEmail();
        public static bool AddEmployeeEmail(int EmployeeId)
        {
            EmployeeEmail employeeEmail = new EmployeeEmail();
            employeeEmail.SetIsConfirmed(false);
            employeeEmail.SetEmployeeId(EmployeeId);
            employeeEmail.SetOTPExpired(DateTime.Now);
            employeeEmail.SetEmail("");
            employeeEmail.SetCurrentOTP("");
            return emailFuction.CreateEmployeeEmail(employeeEmail) > 0 ;
        }
        public static EmployeeEmail GetEmployeeById(int id)
        {
            return emailFuction.GetEmployeeEmailById(id);
        }
        public static bool UpdateEmployeeEmail(EmployeeEmail employeeEmail)
        {
            return emailFuction.UpdateEmployeeEmail(employeeEmail);
        }
    }
}
