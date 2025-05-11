using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Receipt
    {
        public int id;
        public List<Products> Items;
        public decimal totalPrice;
        public decimal totalDiscount;
        public decimal finalPrice;
        public decimal receive;
        public decimal changeDue;
        public int MyProperty { get; set; }

    }
    public class Products
    {
        public string name;
        public int quantity;
        public decimal price;
        public Products(string name, int quantity, decimal price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
