using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Customer
    {
        // Private fields
        private int _customerId;
        private string _nameCustomer;
        private string _phoneNumber;
        private int _points;

        // Public properties with private setters
        public int CustomerId
        {
            get { return _customerId; }
            private set { _customerId = value; }
        }

        public string NameCustomer
        {
            get { return _nameCustomer; }
            private set { _nameCustomer = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            private set { _phoneNumber = value; }
        }

        public int Points
        {
            get { return _points; }
            private set { _points = value; }
        }

        // Default constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(int customerId, string customerName, string phoneNumber, int points)
        {
            _customerId = customerId;
            _nameCustomer = customerName;
            _phoneNumber = phoneNumber;
            _points = points;
        }
    }
}

