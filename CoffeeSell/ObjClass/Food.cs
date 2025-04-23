using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Food
    {
        

        private int FoodId { get; set; }
        private string NameFood { get; set; }
        private int CategoryId { get; set; }
        private decimal[] Price{ get; set; }

        public Food()
        {
            Price = new decimal[3];
        }

        public Food(int foodId, string nameFood, int categoryId, decimal[] price)
        {
            FoodId = foodId;
            NameFood = nameFood;
            CategoryId = categoryId;
            Price = price;
        }
        public Food(int foodId, string nameFood, int categoryId, decimal price_s,decimal price_m, decimal price_l)
        {
            FoodId = foodId;
            NameFood = nameFood;
            CategoryId = categoryId;
            Price = new decimal[3];
            Price[0] = price_s;
            Price[0] = price_m;
            Price[0] = price_l;
        }

        public int GetFoodId() => FoodId;
        public string GetNameFood() => NameFood;
        public int GetCategoryId() => CategoryId;
        public decimal[] GetPrice() => Price;

    }
}
