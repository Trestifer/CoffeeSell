using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOBillDiscountInfo
    {
        static DAODiscountBillInfo bill = new DAODiscountBillInfo();
        public static bool Add(DiscountBillInfo info)
        {
            return bill.InsertDiscountBillInfo(info);
        }

    }
}
