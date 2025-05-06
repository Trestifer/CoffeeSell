using System;

namespace CoffeeSell.ObjClass
{
    public class Customer
    {
        // Private auto-properties
        private int CustomerId { get; set; }
        private string NameCustomer { get; set; }
        private string PhoneNumber { get; set; }
        private int Points { get; set; }
        private DateTime RegisterDate { get; set; }
        private DateTime LattestBuy { get; set; }

        // Default constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(int customerId, string nameCustomer, string phoneNumber, int points, DateTime registerDate, DateTime lattestBuy)
        {
            CustomerId = customerId;
            NameCustomer = nameCustomer;
            PhoneNumber = phoneNumber;
            Points = points;
            RegisterDate = registerDate;
            LattestBuy = lattestBuy;
        }

        // Public getter methods
        public int GetCustomerId() => CustomerId;
        public string GetNameCustomer() => NameCustomer;
        public string GetPhoneNumber() => PhoneNumber;
        public int GetPoints() => Points;
        public DateTime GetRegisterDate() => RegisterDate;
        public DateTime GetLattestBuy() => LattestBuy;

        // Public setter methods
        public void SetCustomerId(int customerId) => CustomerId = customerId;
        public void SetNameCustomer(string nameCustomer) => NameCustomer = nameCustomer;
        public void SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void SetPoints(int points) => Points = points;
        public void SetRegisterDate(DateTime registerDate) => RegisterDate = registerDate;
        public void SetLattestBuy(DateTime lattestBuy) => LattestBuy = lattestBuy;
    }
}
