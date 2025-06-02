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
            billInfo.DateCheckIn = DateTime.Now;
            return bil.CreateBill(billInfo);
        }
        public static DataTable GetAllBill()
        { return bil.GetAllBill(); }
        public static DataTable GetDataTableBill()
        {
            return bil.GetBillWithCustomerInfo();
        }
        public static bool UpdatePhoto(int id,string photo)
        {
            return bil.UpdateBillPhoto(id,photo);
        }
        public static bool Delete(int id)
        {
            return bil.DeleteBill(id);
        }
    }
}
