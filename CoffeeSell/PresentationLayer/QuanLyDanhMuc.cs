using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using Guna.UI2.WinForms;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CoffeeSell
{
    public partial class QuanLyDanhMuc : Form
    {
        int CategoryId = -1;
        string name;
        Account user;
        public QuanLyDanhMuc(Account _user)
        {
            InitializeComponent();
            Reset();
            this.user = _user;
        }
        public QuanLyDanhMuc()
        {
            InitializeComponent();
            Reset();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Reset()
        {
            textBox2.Text = "";
            name = "";
            CategoryId = -1;
            guna2DataGridView2.DataSource = BOCategory.GetCategory();
            guna2DataGridView2.Refresh();
            guna2DataGridView2.Columns[0].HeaderText = "Mã danh mục";
            guna2DataGridView2.Columns[1].HeaderText = "Tên danh mục";
            guna2DataGridView2.ColumnHeadersHeight = 30;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    CategoryId = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    name = (string)guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    textBox2.Text = name;

                    // Optionally scroll the selected row into view
                    guna2DataGridView1.FirstDisplayedScrollingRowIndex = e.RowIndex;
                }
                catch (Exception ex)
                {
                    Reset();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
