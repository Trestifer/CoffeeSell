namespace CoffeeSell.ObjClass
{
    public class DiscountBillInfo
    {
<<<<<<< HEAD
        private int? _billId;
        private int? _discountId;
        private decimal _saved;
=======
        // Private auto-properties matching SQL columns
        private int DiscountInfoId { get; set; }
        private int DiscountId { get; set; }
        private decimal Saved { get; set; }  // New property
>>>>>>> discountbillInfo and QuanLyKhuyenMai

        public DiscountBillInfo() { }

<<<<<<< HEAD
        public DiscountBillInfo(int? billId, int? discountId, decimal saved)
        {
            _billId = billId;
            _discountId = discountId;
            _saved = saved;
        }

        public int? GetBillId() => _billId;
        public void SetBillId(int? value) => _billId = value;

        public int? GetDiscountId() => _discountId;
        public void SetDiscountId(int? value) => _discountId = value;

        public decimal GetSaved() => _saved;
        public void SetSaved(decimal value) => _saved = value;
=======
        // Parameterized constructor
        public DiscountBillInfo(int discountInfoId, int discountId, decimal saved)
        {
            DiscountInfoId = discountInfoId;
            DiscountId = discountId;
            Saved = saved;
        }

        // Public getter methods
        public int GetDiscountInfoId() => DiscountInfoId;
        public int GetDiscountId() => DiscountId;
        public decimal GetSaved() => Saved;

        // Public setter methods
        public void SetDiscountInfoId(int discountInfoId) => DiscountInfoId = discountInfoId;
        public void SetDiscountId(int discountId) => DiscountId = discountId;
        public void SetSaved(decimal saved) => Saved = saved;
>>>>>>> discountbillInfo and QuanLyKhuyenMai
    }
}
