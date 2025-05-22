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
        DataTable khTable;
        private int Id = -1;
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
            txt4.Text = a.KimCuong.ToString();
            Reset();
        }
        private void Reset()
        {
            khTable = BOCustomer.GetAllCustomer();
            textBox1.Text = "";
            Id = -1;
            textBox2.Text = "";
            textBox3.Text = "";
            ReloadTable();
        }
        private void ReloadTable()
        {
            guna2DataGridView1.DataSource = Fillter(textBox3.Text);
            guna2DataGridView1.Columns["NameCustomer"].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            guna2DataGridView1.Columns["Points"].HeaderText = "Điểm tích lũy";
            guna2DataGridView1.Columns["RegisterDate"].HeaderText = "Ngày đăng ký";
            guna2DataGridView1.Columns["LattestBuy"].HeaderText = "Lần mua gần nhất";
            guna2DataGridView1.Columns["RegisterDate"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
            guna2DataGridView1.Columns["LattestBuy"].DefaultCellStyle.Format = "HH:mm dd/MM/yyyy";
            guna2DataGridView1.ColumnHeadersHeight = 40; // Set to desired height in pixels
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        }

        private DataTable Fillter(string filter = "")
        {
            DataTable dt = khTable.Clone();
            if (filter == "")
            {
                dt = khTable;
            }
            else
            {
                var filteredRows = from row in khTable.AsEnumerable()
                                   let name = row.Field<string>("NameCustomer") ?? "" // Handle null
                                   let phone = row.Field<string>("PhoneNumber") ?? "" // Handle null
                                   where name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                         phone.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                                   select row;
                int rowCount = filteredRows.Count();
                System.Diagnostics.Debug.WriteLine($"Filter: '{filter}', Matching Rows: {rowCount}");
                foreach (DataRow row in filteredRows)
                {
                    try
                    {
                        dt.ImportRow(row);
                        System.Diagnostics.Debug.WriteLine($"Imported row: Name='{row["NameCustomer"]}', Phone='{row["PhoneNumber"]}'");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"ImportRow failed: {ex.Message}");
                    }
                }
            }
            return dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count)
                {
                    DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                    Id = int.Parse(row.Cells["CustomerId"].Value.ToString());
                    textBox1.Text = row.Cells["NameCustomer"].Value?.ToString() ?? ""; // Use column name "Name"
                    textBox2.Text = row.Cells["PhoneNumber"].Value?.ToString() ?? ""; // Use column name "Phone"
                }
            }
            catch
            {
                Reset();
            }

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
            b.Dong = Convert.ToInt32(txt1.Text);
            b.Bac = Convert.ToInt32(txt2.Text);
            b.Vang = Convert.ToInt32(txt3.Text);
            b.KimCuong = Convert.ToInt32(txt4.Text);
            BOCustomer.Update(b);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ReloadTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (BOCustomer.Delete(Id))
            {
                MessageBox.Show("Xóa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'D', $"Đã xóa khách hàng có mã {Id}");
                Reset();
            }
            else
                MessageBox.Show("Có lỗi xảy ra");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (BOCustomer.Update(Id, textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Sửa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', $"Đã sửa khách hàng có mã {Id}");
                Reset();
            }
            else
                MessageBox.Show("Có lỗi xảy ra");
            
        }
    }
}
