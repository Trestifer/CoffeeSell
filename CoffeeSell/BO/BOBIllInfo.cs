using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass.CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOBIllInfo
    {
        static DAOBillInfo b = new DAOBillInfo();

        public static bool Add(BillInfo info)
        {
            return b.CreateBillInfo(info)>0;
        }

    }
}
