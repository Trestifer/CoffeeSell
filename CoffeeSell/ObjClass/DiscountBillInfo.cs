namespace CoffeeSell.ObjClass
{
    public class DiscountBillInfo
    {
        private int? _billId;
        private int? _discountId;
        private decimal _saved;

        public DiscountBillInfo() { }

        // Parameterized constructor
        public DiscountBillInfo(int discountInfoId, int discountId)
        {
            DiscountInfoId = discountInfoId;
            DiscountId = discountId;
        }

        public int? GetBillId() => _billId;
        public void SetBillId(int? value) => _billId = value;

        public int? GetDiscountId() => _discountId;
        public void SetDiscountId(int? value) => _discountId = value;

        public decimal GetSaved() => _saved;
        public void SetSaved(decimal value) => _saved = value;
    }
}
