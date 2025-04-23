using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Customer
    {
        // Private auto-properties
        private int CustomerId { get; set; }
        private string NameCustomer { get; set; }
        private string PhoneNumber { get; set; }
        private int Points { get; set; }

        // Default constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(int customerId, string nameCustomer, string phoneNumber, int points)
        {
            CustomerId = customerId;
            NameCustomer = nameCustomer;
            PhoneNumber = phoneNumber;
            Points = points;
        }

        // Public getter methods
        public int GetCustomerId() => CustomerId;
        public string GetNameCustomer() => NameCustomer;
        public string GetPhoneNumber() => PhoneNumber;
        public int GetPoints() => Points;
    }
}


