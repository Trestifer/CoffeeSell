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
        private int Sold {  get; set; }
        private string Photo {  get; set; }

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
            Price[1] = price_m;
            Price[2] = price_l;
        }

        public int GetFoodId() => FoodId;
        public string GetNameFood() => NameFood;
        public int GetCategoryId() => CategoryId;
        public decimal[] GetPrice() => Price;
        public int GetSold() => Sold;
        public void SetSold(int sold) => Sold = sold;
        
    

        // Setters
        public void SetFoodId(int foodId) => FoodId = foodId;
        public void SetNameFood(string nameFood) => NameFood = nameFood;
        public void SetCategoryId(int categoryId) => CategoryId = categoryId;
        public void SetPrice(decimal[] price) => Price = price;
        public void SetPhoto(string photo) => Photo = photo;
        public string GetPhoto() => Photo;


        // Optional: Set individual prices (small, medium, large)
        public void SetPriceSmall(decimal price) => Price[0] = price;
        public void SetPriceMedium(decimal price) => Price[1] = price;
        public void SetPriceLarge(decimal price) => Price[2] = price;
    }
}
