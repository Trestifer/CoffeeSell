using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell
{
    public partial class SaleCoffee : Form
    {
        public SaleCoffee()
        {
            InitializeComponent();
            guna2TextBox1.Font = new Font("Segoe UI", 14); // 14pt, chữ bự
            guna2TextBox1.PlaceholderText = "Tìm kiếm...";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrangChu trangchuForm = new TrangChu();
            trangchuForm.Show();
            this.Hide();

        }

        private void SaleCoffee_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
