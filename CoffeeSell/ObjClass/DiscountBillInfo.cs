using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class DiscountBillInfo
    {
        // Private auto-properties matching SQL columns
        private int DiscountInfoId { get; set; }
        private int DiscountId { get; set; }

        // Default constructor
        public DiscountBillInfo() { }

        // Parameterized constructor
        public DiscountBillInfo(int discountInfoId, int discountId)
        {
            DiscountInfoId = discountInfoId;
            DiscountId = discountId;
        }

        // Public getter methods
        public int GetDiscountInfoId() => DiscountInfoId;
        public int GetDiscountId() => DiscountId;
    }
}

