using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOEmailSecurity
    {
        static DAOEmailSecurity em = new DAOEmailSecurity();
        public static bool Update(EmailSecurity email)
        {
            return em.UpdateEmailSecurityById(email);
        }
        public static EmailSecurity Get(string LoginName)
        {
            return em.GetEmailSecurityByLoginName(LoginName);
        }
    }
}
