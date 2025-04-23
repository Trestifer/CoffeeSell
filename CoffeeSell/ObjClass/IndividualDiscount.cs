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

        private int CoustomerId {  get; set; }
        private int DiscountId { get; set; }
        private DateTime DateEnd   {  get; set; }

        public IndividualDiscount(int coustomerId, int discountId, DateTime dateEnd)
        {
            CoustomerId = coustomerId;
            DiscountId = discountId;
            DateEnd = dateEnd;
        }
        public int GetCustomerId ()=> CoustomerId;
        public int GetDiscountId ()=> DiscountId;
        public DateTime GetDateEnd ()=> DateEnd;
    }
}
