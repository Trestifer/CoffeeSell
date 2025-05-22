using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.Ulti;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell
{
    public partial class QuanLySanPham : Form
    {

        int foodId;
        string _NameCategory;
        int CategoryId;
        private Account user;
        private List<TextBox> textBoxes = new List<TextBox>();
        private string PhotoPath;
        public QuanLySanPham(Account _user)
        {
            InitializeComponent();
            user = _user;
            guna2DataGridView2.CellClick += Guna2DataGridView1_CellClick;
            CaiDat dmform = new CaiDat(user);
            dmform.TopLevel = false;
            dmform.FormBorderStyle = FormBorderStyle.None;
            dmform.Dock = DockStyle.Fill;
            dmform.Show();

            // Add a new empty row at the top
            guna2DataGridView2.CellClick += Guna2DataGridView2_CellClick;
            Reset_SanPham();
            Reset_DanhMuc();
            textBoxes.Add(txtL);
            textBoxes.Add(txtM);
            textBoxes.Add(txtS);
            foreach (TextBox txt in textBoxes)
            {
                txt.KeyPress += KeyPressTien;
                txt.TextChanged += Txt_TextChanged;
            }
            txtName.KeyPress += NamePress;
            // Thêm sự kiện KeyPress cho textBox1
            textBox1.KeyPress += textBox1_KeyPress;

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn tiếng "ding" khi nhấn Enter
                button5_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }

        private void Guna2DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    CategoryId = (int)guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value;
                    _NameCategory = (string)guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value;
                    textBox2.Text = _NameCategory;
                    MessageBox.Show(CategoryId.ToString());
                    // Optionally scroll the selected row into view
                    guna2DataGridView2.FirstDisplayedScrollingRowIndex = e.RowIndex;
                }
                catch (Exception ex)
                {
                    Reset_SanPham();
                    Reset_DanhMuc();
                }
            }
        }

        private void Guna2DataGridView2_CellClick(object? sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_TextChanged(object? sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = TextHandling.InputRange(txtBox, 0, 200);
        }
        private void Reset_DanhMuc()
        {

            DataTable dt = BOCategory.GetCategory();
            //DataRow newRow = dt.NewRow();
            //newRow["NameCategory"] = "";  // Display text
            //newRow["CategoryId"] = -1;    // Value
            //dt.Rows.InsertAt(newRow, 0);
            // Bind to ComboBox
            cbcDanhMuc.DataSource = dt;
            cbcDanhMuc.DisplayMember = "NameCategory";
            cbcDanhMuc.ValueMember = "CategoryId";

            textBox2.Text = "";
            _NameCategory = "";
            CategoryId = -1;
            guna2DataGridView2.DataSource = BOCategory.GetCategory();
            guna2DataGridView2.Refresh();
            guna2DataGridView2.Columns[0].HeaderText = "Mã danh mục";
            guna2DataGridView2.Columns[1].HeaderText = "Tên danh mục";
            guna2DataGridView2.ColumnHeadersHeight = 30;

        }
        private void Reset_SanPham()
        {
            pictureBox1.Image = null;
            foodId = -1;
            _NameCategory = "";
            PhotoPath = "";
            txtL.Text = "";
            txtM.Text = "";
            txtS.Text = "";
            txtName.Text = "";
            DataTable dt = BOFood.GetAllFood();

            // Step 1: Add "BanChay" column to the DataTable
            if (!dt.Columns.Contains("BanChay"))
                dt.Columns.Add("BanChay", typeof(bool));

            // Step 2: Determine top 5 based on Sold
            var sortedRows = dt.AsEnumerable()
                               .OrderByDescending(r => r.Field<int>("Sold"))
                               .ToList();

            bool hasTieAt5 = sortedRows.Count >= 6 && sortedRows[4].Field<int>("Sold") == sortedRows[5].Field<int>("Sold");

            var topKeys = new HashSet<object>(
                sortedRows.Take(5).Where((r, i) => !hasTieAt5 || i < 5).Select(r => r["FoodId"])
            );

            // Step 3: Mark rows in the DataTable
            foreach (DataRow row in dt.Rows)
            {
                var key = row["FoodId"];
                if (key != DBNull.Value && topKeys.Contains(key))
                {
                    row["BanChay"] = true;
                }
                else
                {
                    row["BanChay"] = false;
                }
            }

            // Step 4: Bind to DataGridView
            dtgrid.DataSource = dt;

            // Step 5: Set headers, hide unwanted
            dtgrid.Columns["FoodId"].HeaderText = "Mã món";
            dtgrid.Columns["NameFood"].HeaderText = "Tên món";
            dtgrid.Columns["NameCategory"].HeaderText = "Danh mục";
            dtgrid.Columns["Price_S"].HeaderText = "Giá size nhỏ";
            dtgrid.Columns["Price_M"].HeaderText = "Giá size vừa";
            dtgrid.Columns["Price_L"].HeaderText = "Giá size lớn";
            dtgrid.Columns["Sold"].HeaderText = "Đã bán";
            dtgrid.Columns["BanChay"].HeaderText = "Bán chạy";

            dtgrid.Columns["CategoryId"].Visible = false;
            dtgrid.Columns["Photo"].Visible = false;


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
                food.SetPhoto(PhotoPath);
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
            // Lấy và kiểm tra dữ liệu đầu vào
            string name = txtName.Text.Trim();
            string priceS = txtS.Text.Trim();
            string priceM = txtM.Text.Trim();
            string priceL = txtL.Text.Trim();

            // Kiểm tra các trường bắt buộc không được để trống
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceS) || string.IsNullOrEmpty(priceM) || string.IsNullOrEmpty(priceL))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên sản phẩm và giá Size S, M, L!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Food info = GetFood();
            if (BOFood.Add(info))
            {
                MessageBox.Show("Thêm thành công");
                BOActivityLog.Record(user.GetLoginName(), 'A', $"Đã thêm vào {_NameCategory} sản phẩm {info.GetNameFood()}");
            }
            Reset_SanPham();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lấy và kiểm tra dữ liệu đầu vào
            string name = txtName.Text.Trim();
            string priceS = txtS.Text.Trim();
            string priceM = txtM.Text.Trim();
            string priceL = txtL.Text.Trim();

            // Kiểm tra các trường bắt buộc không được để trống
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceS) || string.IsNullOrEmpty(priceM) || string.IsNullOrEmpty(priceL))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên sản phẩm và giá Size S, M, L!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            Food info = GetFood();
            if (BOFood.Update(info))
            {
                MessageBox.Show("Sủa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', $"Sửa sản phẩm có mã {foodId}");
            }
            Reset_SanPham();

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
                    txtName.Text = foodName;
                    txtS.Text = TextHandling.CustomDecimalToString(row.Cells["Price_S"].Value.ToString());
                    txtL.Text = TextHandling.CustomDecimalToString(row.Cells["Price_L"].Value.ToString());
                    txtM.Text = TextHandling.CustomDecimalToString(row.Cells["Price_M"].Value.ToString());
                    string fileName = row.Cells["Photo"].Value.ToString();
                    pictureBox1.Image = PhotoFunction.LoadImage(fileName);
                }
                catch (Exception ex)
                {

                    Reset_DanhMuc();
                    Reset_SanPham();
                }
            }
        }

        private void dtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Food info = GetFood();
            // Kiểm tra xem đã chọn sản phẩm hay chưa
            if (info == null || info.GetFoodId() <= 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }
            if (BOFood.Delete(info.GetFoodId()))
            {
                MessageBox.Show("Xóa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'D', $"Đã xóa từ {_NameCategory} sản phẩm {info.GetNameFood()}");
            }
            Reset_SanPham();
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
                    string fileName = PhotoFunction.SaveImageToImagesFolder(sourcePath, foodId);
                    PhotoPath = fileName;
                    pictureBox1.Image = PhotoFunction.LoadImage(fileName);

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

        private void button6_Click(object sender, EventArgs e)
        {
            string categoryName = textBox2.Text.Trim();

            // Kiểm tra tên danh mục không được để trống
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            Category category = new Category();
            category.SetCategoryName(textBox2.Text);
            if (BOCategory.Add(category))
            {
                MessageBox.Show("Thêm thành công");
                BOActivityLog.Record(user.GetLoginName(), 'A', $"Đã thêm danh mục {category.GetCategoryName()}");
            }
            Reset_DanhMuc();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn danh mục hay chưa
            if (CategoryId == 0 || string.IsNullOrEmpty(_NameCategory))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BOCategory.Delete(CategoryId))
            {
                MessageBox.Show("Xóa thành công");
                BOActivityLog.Record(user.GetLoginName(), 'D', $"Đã xóa danh mục {_NameCategory}");

            }
            Reset_DanhMuc();
        }


        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbcDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                Reset_SanPham(); // Hiển thị toàn bộ sản phẩm nếu từ khóa rỗng
                return;
            }

            // Gọi tìm kiếm và cập nhật DataGridView
            DataTable searchResult = BOFood.SearchFoodByName(keyword);
            dtgrid.DataSource = searchResult;

            // Cập nhật giao diện giống Reset_SanPham
            if (dtgrid.Columns.Contains("CategoryId"))
                dtgrid.Columns["CategoryId"].Visible = false;
            dtgrid.Columns["Photo"].Visible = false;

            dtgrid.Columns["FoodId"].HeaderText = "Mã món";
            dtgrid.Columns["NameFood"].HeaderText = "Tên món";
            dtgrid.Columns["NameCategory"].HeaderText = "Danh mục";
            dtgrid.Columns["Price_S"].HeaderText = "Giá size nhỏ";
            dtgrid.Columns["Price_M"].HeaderText = "Giá size vừa";
            dtgrid.Columns["Price_L"].HeaderText = "Giá size lớn";
            dtgrid.Columns["Sold"].HeaderText = "Đã bán";

            if (!dtgrid.Columns.Contains("BanChay"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Bán chạy";
                chk.Name = "BanChay";
                chk.ReadOnly = true;
                dtgrid.Columns.Add(chk);
            }

            var rows = searchResult.AsEnumerable()
                                 .OrderByDescending(r => r.Field<int>("Sold"))
                                 .ToList();

            bool hasTieAt5 = rows.Count >= 6 && rows[4].Field<int>("Sold") == rows[5].Field<int>("Sold");

            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow gridRow = dtgrid.Rows[i];
                bool isTop5 = i < 5 && !hasTieAt5;
                gridRow.Cells["BanChay"].Value = isTop5;
            }

            dtgrid.ColumnHeadersHeight = 40;
            dtgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgrid.EnableHeadersVisualStyles = false;
            dtgrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim(); // Lấy từ khóa từ textBox1

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không nhập từ khóa, hiển thị toàn bộ sản phẩm
                Reset_SanPham();
                MessageBox.Show("Vui lòng nhập từ khóa để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gọi phương thức tìm kiếm và cập nhật DataGridView
            DataTable searchResult = BOFood.SearchFoodByName(keyword);
            dtgrid.DataSource = searchResult;

            // Cập nhật giao diện DataGridView giống Reset_SanPham
            if (dtgrid.Columns.Contains("CategoryId"))
                dtgrid.Columns["CategoryId"].Visible = false;
            dtgrid.Columns["Photo"].Visible = false;

            dtgrid.Columns["FoodId"].HeaderText = "Mã món";
            dtgrid.Columns["NameFood"].HeaderText = "Tên món";
            dtgrid.Columns["NameCategory"].HeaderText = "Danh mục";
            dtgrid.Columns["Price_S"].HeaderText = "Giá size nhỏ";
            dtgrid.Columns["Price_M"].HeaderText = "Giá size vừa";
            dtgrid.Columns["Price_L"].HeaderText = "Giá size lớn";
            dtgrid.Columns["Sold"].HeaderText = "Đã bán";

            // Thêm cột "Bán chạy" nếu chưa có
            if (!dtgrid.Columns.Contains("BanChay"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Bán chạy";
                chk.Name = "BanChay";
                chk.ReadOnly = true;
                dtgrid.Columns.Add(chk);
            }

            // Xác định top 5 sản phẩm bán chạy
            var rows = searchResult.AsEnumerable()
                                 .OrderByDescending(r => r.Field<int>("Sold"))
                                 .ToList();

            bool hasTieAt5 = rows.Count >= 6 && rows[4].Field<int>("Sold") == rows[5].Field<int>("Sold");

            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow gridRow = dtgrid.Rows[i];
                bool isTop5 = i < 5 && !hasTieAt5;
                gridRow.Cells["BanChay"].Value = isTop5;
            }

            dtgrid.ColumnHeadersHeight = 40;
            dtgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgrid.EnableHeadersVisualStyles = false;
            dtgrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thông báo nếu không tìm thấy kết quả
            if (searchResult.Rows.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy sản phẩm nào với từ khóa '{keyword}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
