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
        public ProductUserControl()
        {
            InitializeComponent();
        }
        public ProductUserControl(string productName, string imageUrl, decimal price1, decimal price2, decimal price3)
        {
            InitializeComponent();
            lblProductName.Text = productName;
            picProductImage.ImageLocation = imageUrl;
            lblPriceS.Text = price1.ToString("N0") + " VNĐ";
            lblPriceM.Text = price2.ToString("N0") + " VNĐ";
            lblPriceL.Text = price3.ToString("N0") + " VNĐ";
        }
        public ProductUserControl(int foodId, string productName, string imageUrl, decimal price1, decimal price2, decimal price3)
        {
            InitializeComponent();
            _foodId = foodId;
            lblProductName.Text = productName;
            picProductImage.ImageLocation = imageUrl;
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
            var foodInCart = new FoodInCart
            {
                FoodId = _foodId,
                NameFood = lblProductName.Text,
                Size = size,
                Price = price,
                Quantity = 1
            };
            ProductSelected?.Invoke(this, foodInCart);
        }
        private void pbPriceS_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("M", decimal.Parse(lblPriceM.Text.Replace(" VNĐ", "").Replace(",", "")));
        }

        private void pbPriceM_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("M", decimal.Parse(lblPriceM.Text.Replace(" VNĐ", "").Replace(",", "")));
        }

        private void pbPriceL_Click(object sender, EventArgs e)
        {
            RaiseProductSelected("L", decimal.Parse(lblPriceL.Text.Replace(" VNĐ", "").Replace(",", "")));
        }
    }
}
