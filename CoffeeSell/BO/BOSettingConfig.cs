using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOSettingConfig
    {
        static DAOSettingConfig sc = new DAOSettingConfig();    
        public static SettingConfig Get()
        {
            return sc.GetSettingConfig();
        }
        public static bool Update(SettingConfig info)
        {
            return sc.UpdateSettingConfig(info);
        }
    }
}
