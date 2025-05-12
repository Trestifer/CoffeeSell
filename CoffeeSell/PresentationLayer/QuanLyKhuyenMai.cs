using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.PresentationLayer;
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
    public partial class QuanLyKhuyenMai : Form
    {
        private Account user;
        private int id;
        public QuanLyKhuyenMai(Account _user)
        {
            InitializeComponent();
            user = _user;
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
            Reset();
        }



         private void button2_Click(object sender, EventArgs e)
        {
            Discount temp = GetDiscount();
           
            temp.SetEndDate(new DateTime(1753, 1, 1));
            if (BODiscount.Add(temp))
            {
                MessageBox.Show("Thêm khuyến mãi thành công");
                BOActivityLog.Record(user.GetLoginName(), 'A', $"Đã thêm khuyến mãi {temp.GetNameDiscount}");
            }
            Reset();
        }
        private void Reset()
        {
            id = -1;
            txtName.Text = "";
            txtPercent.Text = "";
            cbcCustomer.Items.Clear();
            Ranking ranking = BOCustomer.GetRanking();
            cbcCustomer.Items.Add(new KeyValuePair<string, int>("Mọi người", 0));
            cbcCustomer.Items.Add(new KeyValuePair<string, int>("Thành viên Đồng", ranking.Dong));
            cbcCustomer.Items.Add(new KeyValuePair<string, int>("Thành viên Bạc", ranking.Bac));
            cbcCustomer.Items.Add(new KeyValuePair<string, int>("Thành Viên Vàng", ranking.Vang));
            cbcCustomer.Items.Add(new KeyValuePair<string, int>("Thành viên KC", ranking.KiemCuong));

            DataTable dt = BODiscount.GetDiscountInfo();

            // Add RemainingDays column manually
            dt.Columns.Add("RemainingDays", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(row["EndDate"]) == new DateTime(1753, 1, 1))
                {
                    row["RemainingDays"] = "";
                }
                else
                {
                    DateTime endDate = Convert.ToDateTime(row["EndDate"]);
                    if (endDate == DateTime.MaxValue)
                        row["RemainingDays"] = "Không giới hạn";
                    else
                        row["RemainingDays"] = ((endDate - DateTime.Now).Days + 1) + " ngày";
                }
            }

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            guna2DataGridView1.DataSource = dt;

            // Set header text and order
            guna2DataGridView1.Columns["IsUseable"].DisplayIndex = 0;
            guna2DataGridView1.Columns["DiscountId"].DisplayIndex = 1;
            guna2DataGridView1.Columns["NameDiscount"].DisplayIndex = 2;
            guna2DataGridView1.Columns["RemainingDays"].DisplayIndex = 3;

            guna2DataGridView1.Columns["IsUseable"].HeaderText = "Thực thi";
            guna2DataGridView1.Columns["DiscountId"].HeaderText = "Mã KM";
            guna2DataGridView1.Columns["NameDiscount"].HeaderText = "Tên khuyến mãi";
            guna2DataGridView1.Columns["RemainingDays"].HeaderText = "Còn lại";

            // Fixed width (adjust as needed)
            guna2DataGridView1.Columns["IsUseable"].Width = 80;
            guna2DataGridView1.Columns["DiscountId"].Width = 80;
            guna2DataGridView1.Columns["NameDiscount"].Width = 200;
            guna2DataGridView1.Columns["RemainingDays"].Width = 100;

            // Optional: Disable row resizing
            guna2DataGridView1.ColumnHeadersHeight = 50;
            guna2DataGridView1.AllowUserToResizeRows = false;
            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
            {
                if (col.Name != "IsUseable" &&
                    col.Name != "DiscountId" &&
                    col.Name != "NameDiscount" &&
                    col.Name != "RemainingDays")
                {
                    col.Visible = false;
                }
            }

        }


        private Discount GetDiscount()
        {
            Discount discountInfo = new Discount();
            discountInfo.SetDiscountId(id);
            discountInfo.SetDetail(guna2TextBox1.Text);
            discountInfo.SetDiscountPercent(decimal.Parse(txtPercent.Text));
            discountInfo.SetNameDiscount(txtName.Text);
            discountInfo.SetPointRequire(((KeyValuePair<string, int>)cbcCustomer.SelectedItem).Value);
            discountInfo.SetIsReuseable(!checkBox1.Checked);
            return discountInfo;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            OptionForm formtemp = new OptionForm();
            DialogResult result = formtemp.ShowDialog();
            DateTime endDate = DateTime.Now;
            int option;
            if (result == DialogResult.OK)
            {
                option = formtemp.option;
                if (option == 0)
                {
                    endDate = DateTime.MaxValue;
                }
                else
                {
                    endDate = endDate.AddDays(option);
                }
            }

            if (BODiscount.UpdateState(id, true, endDate))
            {
                MessageBox.Show("Kích hoạt khuyến mãi thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', $"Kích hoạt khuyến mãi mã {id}");
            }
            Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (BODiscount.UpdateState(id, false, new DateTime(1753, 1, 1)))
            {
                MessageBox.Show("Kết thúc mãi thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', $"Đã kết thúc khuyến mãi mã {id}");
            }
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Discount temp = GetDiscount();
            temp.SetIsReuseable(false);
            temp.SetEndDate(new DateTime(1753, 1, 1));
            if (BODiscount.Update(temp))
            {
                MessageBox.Show("Cập nhật mãi thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', $"Đã cập nhật khuyến mãi {id}");
            }
            Reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (BODiscount.Delete(id))
            {
                MessageBox.Show("Xóa khuyến mãi thành công");
                BOActivityLog.Record(user.GetLoginName(), 'D', $"Xoá thành công khuyến mãi {id}");
            }
            Reset();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                    id = Convert.ToInt32(row.Cells["DiscountId"].Value);
                    txtName.Text = row.Cells["NameDiscount"].Value.ToString();
                    txtPercent.Text = row.Cells["DiscountPercent"].Value.ToString();
                    guna2TextBox1.Text = row.Cells["Detail"].Value.ToString();
                    checkBox1.Checked = !Convert.ToBoolean(row.Cells["IsReuseable"].Value);


                    // Safely select the value if it exists in combo box
                    int pointRequire = Convert.ToInt32(row.Cells["PointRequire"].Value);
                    foreach (KeyValuePair<string, int> item in cbcCustomer.Items)
                    {
                        if (item.Value == pointRequire)
                        {
                            cbcCustomer.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch
            {
                Reset();
            }
        }

        private void cbcCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyKhuyenMai_Load(object sender, EventArgs e)
        {

        }
    }
}
