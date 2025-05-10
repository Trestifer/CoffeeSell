using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeSell.ObjClass;
using CoffeeSell.ObjClass.CoffeeSell.ObjClass;

namespace CoffeeSell
{
    public partial class ProductUserControl : UserControl
    {
        // Sự kiện để thông báo khi chọn sản phẩm
        public event EventHandler<FoodInCart> ProductSelected;
        private int _foodId; // Lưu FoodId để sử dụng trong FoodInCart
        private decimal _priceS;
        private decimal _priceM;
        private decimal _priceL;
        private string _productName;
        public ProductUserControl()
        {
            InitializeComponent();
        }
        
        public ProductUserControl(int foodId, string productName, decimal price1, decimal price2, decimal price3)
        {
            InitializeComponent();
            _foodId = foodId;
            _productName = productName;
            _priceS = price1;
            _priceM = price2;
            _priceL = price3;
            lblProductName.Text = productName;
            lblPriceS.Text = price1.ToString("N0") + " VNĐ";
            lblPriceM.Text = price2.ToString("N0") + " VNĐ";
            lblPriceL.Text = price3.ToString("N0") + " VNĐ";
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void RaiseProductSelected(string size, decimal price)
        {
            if (_foodId == 0)
            {
                MessageBox.Show("FoodId không hợp lệ. Vui lòng sử dụng constructor có tham số foodId.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var foodInCart = new FoodInCart
            {
                FoodId = _foodId,
                NameFood = _productName,
                Size = size,
                Price = price,
                Quantity = 1
            };

            if (ProductSelected == null)
            {
                MessageBox.Show("Sự kiện ProductSelected chưa được gán!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ProductSelected?.Invoke(this, foodInCart);
        }
        private void pbPriceS_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("S", _priceS);
        }

        private void pbPriceM_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("M", _priceM);
        }

        private void pbPriceL_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("L", _priceL);
        }
    }
}
