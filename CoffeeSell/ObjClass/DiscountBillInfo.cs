namespace CoffeeSell.ObjClass
{
    public class DiscountBillInfo
    {
        private int? _billId;
        private int? _discountId;
        private decimal _saved;

        public DiscountBillInfo() { }

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
    }
}
