using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Discount
    {
        // Private auto-properties matching SQL fields
        private int DiscountId { get; set; }
        private string NameDiscount { get; set; }
        private bool IsUseable { get; set; }
        private bool IsIndividual { get; set; }
        private int DiscountValue { get; set; }
        private int DiscountPercent { get; set; }
        private int Scheduling { get; set; }

        // Default constructor
        public Discount() { }

        // Parameterized constructor
        public Discount(int discountId, string nameDiscount, bool isUseable, bool isIndividual, int discountValue, int discountPercent, int scheduling)
        {
            DiscountId = discountId;
            NameDiscount = nameDiscount;
            IsUseable = isUseable;
            IsIndividual = isIndividual;
            DiscountValue = discountValue;
            DiscountPercent = discountPercent;
            Scheduling = scheduling;
        }

        // Public getter methods
        public int GetDiscountId() => DiscountId;
        public string GetNameDiscount() => NameDiscount;
        public bool GetIsUseable() => IsUseable;
        public bool GetIsIndividual() => IsIndividual;
        public int GetDiscountValue() => DiscountValue;
        public int GetDiscountPercent() => DiscountPercent;
        public int GetScheduling() => Scheduling;
        public void SetDiscountId(int discountId) => DiscountId = discountId;
        public void SetNameDiscount(string nameDiscount) => NameDiscount = nameDiscount;
        public void SetIsUseable(bool isUseable) => IsUseable = isUseable;
        public void SetIsIndividual(bool isIndividual) => IsIndividual = isIndividual;
        public void SetDiscountValue(int discountValue) => DiscountValue = discountValue;
        public void SetDiscountPercent(int discountPercent) => DiscountPercent = discountPercent;
        public void SetScheduling(int scheduling) => Scheduling = scheduling;
    }

}

