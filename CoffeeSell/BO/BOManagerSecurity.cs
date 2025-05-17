using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    internal class BOManagerSecurity
    {
        static DAOManagerSecurity mnS  = new DAOManagerSecurity();
        public static ManagerSecurity Get(string LoginName)
        {
            return mnS.GetManagerSecurityByLoginName(LoginName);
        }
        public static ManagerSecurity Add(string LoginName)
        {
            ManagerSecurity info = new ManagerSecurity();
            info.SetCurrentOTP("");
            info.SetOTPExpired(DateTime.Now);
            info.SetEncodingFace("");
            info.SetLoginName(LoginName);
            info.SetEmail("");
            info.SetId(mnS.CreateManagerSecurity(info));
            return info;
        }
        public static bool Update(string LoginName, string encode)
        {
            return mnS.UpdateManagerSecurityByLoginName(LoginName,encode);
        }

    }
}
