using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class BillDeviceAssignment
    {
        public string SoHoaDon { get; set; }
        public string MaThietBi { get; set; }

        public BillDeviceAssignment(string soHoaDon, string maThietBi)
        {
            SoHoaDon = soHoaDon;
            MaThietBi = maThietBi;
        }
    }
}