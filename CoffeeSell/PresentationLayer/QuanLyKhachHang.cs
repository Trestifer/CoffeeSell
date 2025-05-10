using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using Guna.UI2.WinForms;
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
    public partial class QuanLyKhachHang : Form
    {
        Account user;
        public QuanLyKhachHang(Account _user)
        {
            InitializeComponent();
            user = _user;
            if (!user.GetTypeAccount())
            {
                button1.Visible = false;
                button2.Visible = false;
            }
            button2.Enabled = false;
            panel3.Enabled = false;
            Ranking a = BOCustomer.GetRanking();
            txt1.Text = a.Dong.ToString();
            txt2.Text = a.Bac.ToString();
            txt3.Text = a.Vang.ToString();
            txt4.Text = a.KiemCuong.ToString();
            
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = BOCustomer.GetAllCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            panel3.Enabled = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            panel3.Enabled = false;
            Ranking b = new Ranking();
            b.Dong =Convert.ToInt32(txt1.Text);
            b.Bac =Convert.ToInt32(txt2.Text);
            b.Vang =Convert.ToInt32(txt3.Text);
            b.KiemCuong =Convert.ToInt32(txt4.Text);
            BOCustomer.Update(b);
        }
    }
}
