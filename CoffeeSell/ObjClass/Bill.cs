using System;

namespace CoffeeSell.ObjClass
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime DateCheckIn { get; set; }
        public decimal TotalPrice { get; set; }
        public int? CustomerId { get; set; }

        public Bill() { }

        public Bill(int billId, DateTime dateCheckIn, decimal totalPrice, int statusBill, int? customerId)
        {
            BillId = billId;
            DateCheckIn = dateCheckIn;
            TotalPrice = totalPrice;
            CustomerId = customerId;
        }
    }
}
