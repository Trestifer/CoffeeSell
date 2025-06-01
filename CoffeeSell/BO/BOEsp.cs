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
    internal class BOEsp
    {
        private DAOEsp _daoEsp;

        public BOEsp()
        {
            _daoEsp = new DAOEsp();
        }

        public string CreateEspDevice(ESP esp)
        {
            string result = _daoEsp.CreateDeviced(esp);
            return result;
        }

        public DataTable GetAllEspDevices()
        {
            DataTable data = _daoEsp.GetAllDevices();
            return data;
        }

        public DataTable GetAllEspDeviceIds()
        {
            DataTable data = _daoEsp.GetAllDeviceIds(); // Corrected method call
            return data;
        }

        public string UpdateEspDevice(ESP esp)
        {
            string result = _daoEsp.UpdateDeviced(esp);
            return result;
        }

        public string DeleteEspDevice(string deviceId)
        {
            string result = _daoEsp.DeleteDeviced(deviceId);
            return result;
        }
    }
}