using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    namespace CoffeeSell.ObjClass
    {
        public class BillInfo
        {
            // Private auto-properties matching table columns
            private int Id { get; set; }
            private int IdBill { get; set; }
            private int IdFood { get; set; }
            private int Quantity { get; set; }

            // Default constructor
            public BillInfo() { }

            // Parameterized constructor
            public BillInfo(int id, int idBill, int idFood, int quantity)
            {
                Id = id;
                IdBill = idBill;
                IdFood = idFood;
                Quantity = quantity;
            }

            // Public getter methods
            public int GetId() => Id;
            public int GetIdBill() => IdBill;
            public int GetIdFood() => IdFood;
            public int GetQuantity() => Quantity;
        }
    }

}
