using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.Ulti;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class QuanLySanPham : Form
    {
        int foodId;
        string _NameCategory;
        private Account user;
        private List<TextBox> textBoxes = new List<TextBox>();
        private string PhotoBase64;

        public QuanLySanPham()
        {
            InitializeComponent();
            panelcontent.Controls.Clear();
            QuanLyDanhMuc dmform = new QuanLyDanhMuc(user);
            dmform.TopLevel = false;
            dmform.FormBorderStyle = FormBorderStyle.None;
            dmform.Dock = DockStyle.Fill;
            panelcontent.Controls.Add(dmform);
            dmform.Show();
            DataTable dt = BOCategory.GetCategory();

            // Add a new empty row at the top
            DataRow newRow = dt.NewRow();
            newRow["NameCategory"] = "";  // Display text
            newRow["CategoryId"] = -1;    // Value
            dt.Rows.InsertAt(newRow, 0);

            // Bind to ComboBox
            cbcDanhMuc.DataSource = dt;
            cbcDanhMuc.DisplayMember = "NameCategory";
            cbcDanhMuc.ValueMember = "CategoryId";
            Reset();
            textBoxes.Add(txtL);
            textBoxes.Add(txtM);
            textBoxes.Add(txtS);
            foreach (TextBox txt in textBoxes)
            {
                txt.KeyPress += KeyPressTien;
                txt.TextChanged += Txt_TextChanged;
            }
            txtName.KeyPress += NamePress;


        }

        private void Txt_TextChanged(object? sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = TextHandling.InputRange(txtBox, 0, 200);
        }

        private void Reset()
        {
            pictureBox1.Image = null;
            foodId = -1;
            _NameCategory = "";
            PhotoBase64 = "";
            txtL.Text = "";
            txtM.Text = "";
            txtS.Text = "";
            txtName.Text = "";
            cbcDanhMuc.SelectedIndex = 0;
            // Bind data to DataGridView
            DataTable dt = BOFood.GetAllFood();
            dtgrid.DataSource = dt;

            // Hide CategoryId column
            if (dtgrid.Columns.Contains("CategoryId"))
                dtgrid.Columns["CategoryId"].Visible = false;
            dtgrid.Columns["Photo"].Visible = false;

            // Set Vietnamese headers
            dtgrid.Columns["FoodId"].HeaderText = "Mã món";
            dtgrid.Columns["NameFood"].HeaderText = "Tên món";
            dtgrid.Columns["NameCategory"].HeaderText = "Danh mục";
            dtgrid.Columns["Price_S"].HeaderText = "Giá nhỏ";
            dtgrid.Columns["Price_M"].HeaderText = "Giá vừa";
            dtgrid.Columns["Price_L"].HeaderText = "Giá lớn";
            dtgrid.Columns["Sold"].HeaderText = "Đã bán";

            // Add "Bán chạy" checkbox column
            if (!dtgrid.Columns.Contains("BanChay"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Bán chạy";
                chk.Name = "BanChay";
                chk.ReadOnly = true;
                dtgrid.Columns.Add(chk);
            }

            // Determine top 5 by Sold (without ties at position 5)
            var rows = dt.AsEnumerable()
                         .OrderByDescending(r => r.Field<int>("Sold"))
                         .ToList();

            bool hasTieAt5 = rows.Count >= 6 && rows[4].Field<int>("Sold") == rows[5].Field<int>("Sold");

            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow gridRow = dtgrid.Rows[i];

                // Only check if in top 5 AND no tie at position 5
                bool isTop5 = i < 5 && !hasTieAt5;
                gridRow.Cells["BanChay"].Value = isTop5;
            }

            // Fixed header height
            dtgrid.ColumnHeadersHeight = 40;
            dtgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Auto size columns
            dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Optional: Improve visuals
            dtgrid.EnableHeadersVisualStyles = false;
            dtgrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private Food GetFood()
        {
            Food food = new Food();
            _NameCategory = cbcDanhMuc.Text;
            food.SetFoodId(foodId);
            food.SetNameFood(txtName.Text);
            try
            {
                food.SetPriceLarge(Convert.ToDecimal(txtL.Text));
                food.SetPriceMedium(Convert.ToDecimal(txtM.Text));
                food.SetPriceSmall(Convert.ToDecimal(txtS.Text));
                food.SetCategoryId((int)cbcDanhMuc.SelectedValue);
                food.SetPhoto(PhotoBase64);
            }
            catch { }
            return food;

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Food info = GetFood();
            if (BOFood.Add(info))
            {
                MessageBox.Show("Thêm thành công");
                BOActivityLog.Record("trestifer", 'A', $"Đã thêm vào {_NameCategory} sản phẩm {info.GetNameFood()}");
            }
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {




            Food info = GetFood();
            if (BOFood.Update(info))
            {
                MessageBox.Show("Sủa thành công");
                BOActivityLog.Record("trestifer", 'E', $"Sửa sản phẩm có mã {foodId}");
            }
            Reset();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dtgrid.Rows[e.RowIndex];
                    int columnIndex = e.ColumnIndex;
                    foodId = Convert.ToInt32(row.Cells["FoodId"].Value);
                    string foodName = row.Cells["NameFood"].Value.ToString();
                    cbcDanhMuc.SelectedValue = Convert.ToInt32(row.Cells["CategoryId"].Value);
                    txtS.Text = TextHandling.CustomDecimalToString(row.Cells["Price_S"].Value.ToString());
                    txtL.Text = TextHandling.CustomDecimalToString(row.Cells["Price_L"].Value.ToString());
                    txtM.Text = TextHandling.CustomDecimalToString(row.Cells["Price_M"].Value.ToString());
                    pictureBox1.Image = PhotoFunction.Base64ToImage(row.Cells["Photo"].Value.ToString());
                }
                catch (Exception ex)
                {

                    Reset();
                }
            }
        }

        private void dtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Food info = GetFood();
            if (BOFood.Delete(info.GetFoodId()))
            {
                MessageBox.Show("Xóa thành công");
                BOActivityLog.Record("trestifer", 'D', $"Đã xóa từ {_NameCategory} sản phẩm {info.GetNameFood()}");
            }
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;
                    PhotoBase64 = PhotoFunction.ImageToBase64(sourcePath);
                    pictureBox1.Image = PhotoFunction.Base64ToImage(PhotoBase64);

                }
            }

        }

        private void KeyPressTien(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            // Check if the character is a valid numeric input (like your `txtS_KeyPress` method)
            if (!TextHandling.IsValidNumericInput(e.KeyChar, txtBox.Text))
            {
                e.Handled = true;  // Block the keypress if it's not valid
            }
        }
        private void NamePress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            // Check if the character is a valid numeric input (like your `txtS_KeyPress` method)
            if (!TextHandling.IsValidAlphabeticInput(e.KeyChar, txtBox.Text))
            {
                e.Handled = true;  // Block the keypress if it's not valid
            }
        }

        private void panelcontent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
