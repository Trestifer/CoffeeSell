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
    public class BOBill
    {
        static DAOBill bil = new DAOBill();
        public static int Add(Bill billInfo)
        {
            billInfo.StatusBill = 0;
            billInfo.DateCheckIn = DateTime.Now;
            return bil.CreateBill(billInfo);
        }
        public static DataTable GetAllBill()
        { return bil.GetAllBill(); }
        public static DataTable GetDataTableBill()
        {
            return bil.GetBillWithCustomerInfo();
        }
    }
}
