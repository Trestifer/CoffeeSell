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
        public ProductUserControl(string productName, string imageUrl, decimal price)
        {
            InitializeComponent();
            lblProductName.Text = productName;
            picProductImage.ImageLocation = imageUrl;
            lblPrice.Text = price.ToString("N0") + " VN đ";

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
