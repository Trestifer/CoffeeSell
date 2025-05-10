namespace CoffeeSell.ObjClass
{
    public class Discount
    {
        // Private auto-properties matching SQL fields
        private int DiscountId { get; set; }
        private string NameDiscount { get; set; }
        private bool IsUseable { get; set; }
        private bool IsReuseable { get; set; }
        private DateTime? EndDate { get; set; }
        private string Detail { get; set; }
        private decimal DiscountPercent { get; set; }
        private int PointRequire { get; set; }  // Newly added property

        // Default constructor
        public Discount() { }

        // Parameterized constructor
        public Discount(int discountId, string nameDiscount, bool isUseable, bool isReuseable, DateTime? endDate, string detail, decimal discountPercent, int pointRequire)
        {
            DiscountId = discountId;
            NameDiscount = nameDiscount;
            IsUseable = isUseable;
            IsReuseable = isReuseable;
            EndDate = endDate;
            Detail = detail;
            DiscountPercent = discountPercent;
            PointRequire = pointRequire;
        }

        // Public getter methods
        public int GetDiscountId() => DiscountId;
        public string GetNameDiscount() => NameDiscount;
        public bool GetIsUseable() => IsUseable;
        public bool GetIsReuseable() => IsReuseable;
        public DateTime? GetEndDate() => EndDate;
        public string GetDetail() => Detail;
        public decimal GetDiscountPercent() => DiscountPercent;
        public int GetPointRequire() => PointRequire;  // Getter for PointRequire

        // Public setter methods
        public void SetDiscountId(int discountId) => DiscountId = discountId;
        public void SetNameDiscount(string nameDiscount) => NameDiscount = nameDiscount;
        public void SetIsUseable(bool isUseable) => IsUseable = isUseable;
        public void SetIsReuseable(bool isReuseable) => IsReuseable = isReuseable;
        public void SetEndDate(DateTime? endDate) => EndDate = endDate;
        public void SetDetail(string detail) => Detail = detail;
        public void SetDiscountPercent(decimal discountPercent) => DiscountPercent = discountPercent;
        public void SetPointRequire(int pointRequire) => PointRequire = pointRequire;  // Setter for PointRequire
    }
}
