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
    public class BOCategory
    {
        static DAOCategory category = new DAOCategory();
        public static DataTable GetCategory()
        {
            return category.GetAllCategory();
        }
        public static bool Add(Category _category)
        {
            return category.CreateCategory(_category) >0;
        }
        public static bool Delete(int CategoryId)
        {
            return category.DeleteCategory(CategoryId);
        }
        public static bool Update(Category _category)
        {
            return category.UpdateCategory(_category);
        }
    }
}
