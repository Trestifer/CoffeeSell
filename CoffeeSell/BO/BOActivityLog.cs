using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOActivityLog
    {
        static DAOActivityLog _activityLog = new DAOActivityLog();
        public static void Record(string LoginName,char activityName, string Detail)
        {
            ActivityLog activityLog = new ActivityLog();
            activityLog.SetTimeRecord(DateTime.Now);
            activityLog.SetLoginName(LoginName);
            activityLog.SetDetail(Detail);
            activityLog.SetActionRecord(activityName);
            _activityLog.CreateActivityLog(activityLog);
        }
        public static DataTable GetActivityLog()
        {
            DataTable dt = new DataTable();
            dt = _activityLog.GetAllActivityLogs();
            if (dt.Columns.Contains("TimeRecord"))
            {
                DataView dv = dt.DefaultView;
                dv.Sort = "TimeRecord DESC"; // Sort by latest first
                return dv.ToTable();
            }
            return dt;
        }
    }
}
