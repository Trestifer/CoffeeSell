using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class IndividualDiscount
    {
        public IndividualDiscount()
        {
        }

        private int CustomerId {  get; set; }
        private int DiscountId { get; set; }
        private DateTime DateEnd   {  get; set; }

        public IndividualDiscount(int coustomerId, int discountId, DateTime dateEnd)
        {
            CustomerId = coustomerId;
            DiscountId = discountId;
            DateEnd = dateEnd;
        }
        public int GetCustomerId ()=> CustomerId;
        public int GetDiscountId ()=> DiscountId;
        public DateTime GetDateEnd ()=> DateEnd;
        public void SetCustomerId(int customerId) => CustomerId = customerId;
        public void SetDiscountId(int discountId) => DiscountId = discountId;
        public void SetDateEnd(DateTime dateEnd) => DateEnd = dateEnd;
    }
}
