using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Bill
    {
        // Private auto-properties
        private int BillId { get; set; }
        private DateTime DateCheckIn { get; set; }
        private DateTime? DateCheckOut { get; set; }
        private decimal TotalPrice { get; set; }
        private int StatusBill { get; set; }
        private int? CustomerId { get; set; }

        // Default constructor
        public Bill() { }

        // Parameterized constructor
        public Bill(int billId, DateTime dateCheckIn, DateTime? dateCheckOut, decimal totalPrice, int statusBill, int? customerId)
        {
            BillId = billId;
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;
            TotalPrice = totalPrice;
            StatusBill = statusBill;
            CustomerId = customerId;
        }

        // Public getter methods
        public int GetBillId() => BillId;
        public DateTime GetDateCheckIn() => DateCheckIn;
        public DateTime? GetDateCheckOut() => DateCheckOut;
        public decimal GetTotalPrice() => TotalPrice;
        public int GetStatusBill() => StatusBill;
        public int? GetCustomerId() => CustomerId;
    }
}

