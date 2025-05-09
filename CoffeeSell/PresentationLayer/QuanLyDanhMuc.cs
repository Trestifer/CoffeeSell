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

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Reset()
        {
            textBox2.Text = "";
            name = "";
            CategoryId = -1;
            guna2DataGridView1.DataSource = BOCategory.GetCategory();
            guna2DataGridView1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.SetCategoryName(textBox2.Text);
            if (BOCategory.Add(category))
            {
                MessageBox.Show("Thêm thành công");
                BOActivityLog.Record(user.GetLoginName(), 'A', $"Đã thêm danh mục {category.GetCategoryName()}");
            }
            Reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BOCategory.Delete(CategoryId))
            {
                MessageBox.Show("Xóa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'D', $"Đã xóa danh mục {name}");

            }
            Reset();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    CategoryId = (int)guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    name = (string)guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value;
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
