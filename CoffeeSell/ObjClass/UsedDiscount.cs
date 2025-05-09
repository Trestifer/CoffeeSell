using System;

namespace CoffeeSell.ObjClass
{
    public class IndividualDiscount
    {
        private int CustomerId { get; set; }
        private int DiscountId { get; set; }
        private DateTime DateEnd { get; set; }

        // Default constructor
        public IndividualDiscount() { }

        // Parameterized constructor
        public IndividualDiscount(int customerId, int discountId, DateTime dateEnd)
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
