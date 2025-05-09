using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;

namespace CoffeeSell.BO
{
    public class BODiscount
    {
        static DAODiscount discount = new DAODiscount();
        public static DataTable GetDiscountInfo()
        {
            DataTable discounts = discount.GetAllDiscounts();
            DataView view = discounts.DefaultView;
            view.Sort = "IsUseable DESC";
            DataTable sortedDiscounts = view.ToTable();
            return sortedDiscounts;
        }
        public static bool Add(Discount info)
        {
            return discount.CreateDiscount(info) > 0;
        }
        public static bool Update(Discount info)
        {
            return discount.UpdateDiscount(info);
        }

        public static bool UpdateState(int id, bool state, DateTime date)
        {
            return discount.UpdateIsUseable(id, state,date);
        }
        public static bool Delete(int id)
        { return discount.DeleteDiscount(id); }

    }
}
