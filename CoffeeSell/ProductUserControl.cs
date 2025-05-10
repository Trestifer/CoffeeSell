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

namespace CoffeeSell
{
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl()
        {
            InitializeComponent();
        }
        public ProductUserControl(string productName, string imageUrl, decimal price1, decimal price2, decimal price3)
        {
            InitializeComponent();
            lblProductName.Text = productName;
            picProductImage.ImageLocation = imageUrl;
            lblPriceS.Text = price1.ToString("N0") + " VN đ";
            lblPriceM.Text = price2.ToString("N0") + " VN đ";
            lblPriceL.Text = price3.ToString("N0") + " VN đ";


        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
