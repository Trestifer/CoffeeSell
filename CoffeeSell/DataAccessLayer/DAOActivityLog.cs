using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOActivityLog : DAO
    {
        public int CreateActivityLog(ActivityLog log)
        {
            string cmString = @"
                INSERT INTO ActivityLog (Username, ActionRecord, TimeRecord, Detail)
                OUTPUT INSERTED.ActivityId
                VALUES (@Username, @Action, @Time, @Detail)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new[] { "@Username", "@Action", "@Time", "@Detail" },
                    new object[]
                    {
                        log.GetUsername(),
                        log.GetActionRecord(),
                        log.GetTimeRecord(),
                        log.GetDetail()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateActivityLog error: {ex.Message}");
                return -1;
            }
        }

        public DataTable GetAllActivityLogs()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM ActivityLog");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllActivityLogs error: {ex.Message}");
                return new DataTable();
            }
        }

        public ActivityLog GetActivityLogById(int id)
        {
            string cmString = "SELECT * FROM ActivityLog WHERE ActivityId = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    ActivityLog log = new ActivityLog();
                    log.SetActivityId(Convert.ToInt32(r["ActivityId"]));
                    log.SetUsername(r["Username"].ToString());
                    log.SetActionRecord(Convert.ToChar(r["ActionRecord"]));
                    log.SetTimeRecord(Convert.ToDateTime(r["TimeRecord"]));
                    log.SetDetail(r["Detail"].ToString());
                    return log;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetActivityLogById error: {ex.Message}");
                return null;
            }
        }

        public bool DeleteActivityLog(int id)
        {
            string cmString = "DELETE FROM ActivityLog WHERE ActivityId = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new[] { "@Id" },
                    new object[] { id }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteActivityLog error: {ex.Message}");
                return false;
            }
        }

        public int GetMaxActivityLogId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(ActivityId), 0) FROM ActivityLog");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxActivityLogId error: {ex.Message}");
                return -1;
            }
        }
    }
}
