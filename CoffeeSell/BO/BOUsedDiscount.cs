using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.BO
{
    public class BOUsedDiscount
    {
        static DAOUsedDiscount usedDiscount = new DAOUsedDiscount();
        public static bool Add(UsedDiscount info)
        {
            return usedDiscount.CreateIndividualDiscount(info);
        }

    }
}
