using CoffeeSell.BO;
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
    public partial class QuanLyHoaDon : Form
    {
        DataTable AllBill;
        public QuanLyHoaDon()
        {
            InitializeComponent();
            AllBill = BOBill.GetDataTableBill();
            Reset();
        }
        private void Reset()
        {
            guna2DataGridView3.DataSource = AllBill;
            guna2DataGridView3.Show();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
