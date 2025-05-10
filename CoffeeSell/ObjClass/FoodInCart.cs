using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    using System;

    namespace CoffeeSell.ObjClass
    {
        public class FoodInCart
        {
            public int FoodId { get; set; }
            public string NameFood { get; set; }
            public string Size { get; set; } // S, M, L
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Amount { get => Price * Quantity; } // Thành tiền = Giá * Số lượng

            // Constructor mặc định
            public FoodInCart() { }

            // Constructor đầy đủ
            public FoodInCart(int foodId, string nameFood, string size, decimal price, int quantity)
            {
                FoodId = foodId;
                NameFood = nameFood;
                Size = size;
                Price = price;
                Quantity = quantity;
            }

            // Getters
            public int GetFoodId() => FoodId;
            public string GetNameFood() => NameFood;
            public string GetSize() => Size;
            public decimal GetPrice() => Price;
            public int GetQuantity() => Quantity;
            public decimal GetAmount() => Amount;

            // Setters
            public void SetFoodId(int foodId) => FoodId = foodId;
            public void SetNameFood(string nameFood) => NameFood = nameFood;
            public void SetSize(string size) => Size = size;
            public void SetPrice(decimal price) => Price = price;
            public void SetQuantity(int quantity) => Quantity = quantity;
        }
    }
}
