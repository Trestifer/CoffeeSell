using System;

namespace CoffeeSell.ObjClass
{
    public class UsedDiscount
    {
        private int CustomerId { get; set; }
        private int DiscountId { get; set; }

        // Default constructor
        public UsedDiscount() { }

        // Parameterized constructor
        public UsedDiscount(int customerId, int discountId)
        {
            CustomerId = customerId;
            DiscountId = discountId;
        }

        // Public getter methods
        public int GetCustomerId() => CustomerId;
        public int GetDiscountId() => DiscountId;

        // Public setter methods
        public void SetCustomerId(int customerId) => CustomerId = customerId;
        public void SetDiscountId(int discountId) => DiscountId = discountId;
    }
}
