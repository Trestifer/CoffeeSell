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
    public class BOFood
    {
        static DAOFood food = new DAOFood();
        public static DataTable GetAllFood()
        {
            return food.GetAllFoodWithCategory();
        }
        public static bool Add(Food foodInfo)
        {
            return food.CreateFood(foodInfo) > 0;
        }
        public static bool Delete(int foodId)
        {
            return food.DeleteFood(foodId);
        }
        public static bool Update(Food foodInfo)
        {
            return food.UpdateFood(foodInfo);
        }
        public static bool HasProductsInCategory(int categoryId)
        {
            return food.CountProductsInCategory(categoryId) > 0;
        }
        public static DataTable SearchFoodByName(string keyword)
        {
            return food.SearchFoodByName(keyword);
        }
        public static bool UpdateSold(int id, int foodId)
        {
            return food.IncrementSoldByFoodId(id, foodId);
        }
    }
}
