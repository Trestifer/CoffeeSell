using System;

namespace CoffeeSell.ObjClass
{
    public class UsedDiscount
    {
        private int CustomerId { get; set; }
        private int DiscountId { get; set; }
        private DateTime DateEnd { get; set; }

        // Default constructor
        public UsedDiscount() { }

        // Parameterized constructor
        public UsedDiscount(int customerId, int discountId, DateTime dateEnd)
        {
            CustomerId = customerId;
            DiscountId = discountId;
            DateEnd = dateEnd;
        }

        // Public getter methods
        public int GetCustomerId() => CustomerId;
        public int GetDiscountId() => DiscountId;
        public DateTime GetDateEnd() => DateEnd;

        // Public setter methods
        public void SetCustomerId(int customerId) => CustomerId = customerId;
        public void SetDiscountId(int discountId) => DiscountId = discountId;
        public void SetDateEnd(DateTime dateEnd) => DateEnd = dateEnd;
    }
}
