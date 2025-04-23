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
        private string Username { get; set; }
        private char ActionRecord { get; set; }
        private DateTime TimeRecord { get; set; }
        private string Detail { get; set; }

        // Default constructor
        public ActivityLog() { }

        // Parameterized constructor
        public ActivityLog(int activityId, string username, char actionRecord, DateTime timeRecord, string detail)
        {
            ActivityId = activityId;
            Username = username;
            ActionRecord = actionRecord;
            TimeRecord = timeRecord;
            Detail = detail;
        }

        // Public getter methods
        public int GetActivityId() => ActivityId;
        public string GetUsername() => Username;
        public char GetActionRecord() => ActionRecord;
        public DateTime GetTimeRecord() => TimeRecord;
        public string GetDetail() => Detail;
    }
}

