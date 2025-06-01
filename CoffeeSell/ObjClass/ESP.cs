using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    internal class ESP
    {
        public string DeviceId { get; set; }
        public string AssignedMAC { get; set; }

        public ESP(string deviceId, string assignedMAC)
        {
            this.DeviceId = deviceId;
            this.AssignedMAC = assignedMAC;
        }
    }
}
