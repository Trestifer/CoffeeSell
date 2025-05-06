using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class ActivityLog
    {
        // Private auto-properties
        private int ActivityId { get; set; }
        private string LoginName { get; set; }
        private char ActionRecord { get; set; }
        private DateTime TimeRecord { get; set; }
        private string Detail { get; set; }

        // Default constructor
        public ActivityLog() { }

        // Parameterized constructor
        public ActivityLog(int activityId, string loginName, char actionRecord, DateTime timeRecord, string detail)
        {
            ActivityId = activityId;
            LoginName = loginName;
            ActionRecord = actionRecord;
            TimeRecord = timeRecord;
            Detail = detail;
        }

        // Public getter methods
        public int GetActivityId() => ActivityId;
        public string GetLoginName() => LoginName;
        public char GetActionRecord() => ActionRecord;
        public DateTime GetTimeRecord() => TimeRecord;
        public string GetDetail() => Detail;
        // Public setter methods
        public void SetActivityId(int activityId) => ActivityId = activityId;
        public void SetLoginName(string username) => LoginName = username;
        public void SetActionRecord(char actionRecord) => ActionRecord = actionRecord;
        public void SetTimeRecord(DateTime timeRecord) => TimeRecord = timeRecord;
        public void SetDetail(string detail) => Detail = detail;
    }
}

