using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using CoffeeSell.ObjClass.CoffeeSell.ObjClass;
using Microsoft.Data.SqlClient;
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
        private DAOFood daoFood = new DAOFood();
        private DAOCategory daoCategory = new DAOCategory();
        private string selectedSize = "Tất cả"; // Biến lưu size được chọn
        private decimal? minPrice = null; // Giá thấp nhất
        private decimal? maxPrice = null; // Giá cao nhất
        private System.Windows.Forms.Timer searchTimer; // Dùng đúng loại Timer
        private string connectionString = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";
        public SaleCoffee()
        {
            InitializeComponent();
            // Tăng chiều cao của header
            //InitializeDataGridView();
            LoadProducts();
            guna2DataGridView1.ColumnHeadersHeight = 40; // Chiều cao 40 pixel, có thể tăng thêm nếu muốn
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            comboBox1.Items.AddRange(new string[] { "A-Z", "Z-A", "Tất cả" });
            comboBox1.SelectedIndex = 0;
            guna2TextBox1.Font = new Font("Segoe UI", 14); // 14pt, chữ bự
            guna2TextBox1.PlaceholderText = "Tìm kiếm...";
            comboBox2.Items.AddRange(new string[] { "Tất cả", "S", "M", "L" });
            comboBox2.SelectedIndex = 0; // Mặc định chọn "Tất cả"
            // Khởi tạo Timer
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 300; // Đợi 300ms sau khi người dùng ngừng gõ
            searchTimer.Tick += (s, args) =>
            {
                searchTimer.Stop();
                SearchProducts(guna2TextBox1.Text.Trim());
            };

            // Đảm bảo sự kiện TextChanged được gán
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
        }
        private void SearchProducts(string keyword)
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear(); // Xóa danh sách sản phẩm hiện tại

                // Câu truy vấn SQL
                string query = string.IsNullOrEmpty(keyword)
                    ? "SELECT * FROM Food"
                    : "SELECT * FROM Food WHERE NameFood LIKE @keyword";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Thêm tham số để tránh SQL Injection
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Đọc dữ liệu và hiển thị sản phẩm
                    while (reader.Read())
                    {
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);
                        // Tạo ProductUserControl và thêm vào FlowLayoutPanel
                        ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price1, price2, price3);
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }

                // Làm mới giao diện
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void SaleCoffee_Load(object sender, EventArgs e)
        {
            LoadCategories(); // Load categories when the form is loaded
            LoadProducts(); // Optionally, load all products initially
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flpProducts_Paint(object sender, PaintEventArgs e)
        {

        }
        // Khởi tạo cấu trúc DataGridView
        //private void InitializeDataGridView()
        //{
        //    guna2DataGridView1.Columns.Clear();
        //    guna2DataGridView1.Columns.Add("ProductName", "Tên sản phẩm");
        //    guna2DataGridView1.Columns.Add("Quantity", "Số lượng");
        //    guna2DataGridView1.Columns.Add("Size", "Size");
        //    guna2DataGridView1.Columns.Add("Price", "Giá (VNĐ)");
        //    guna2DataGridView1.Columns.Add("Total", "Thành tiền (VNĐ)");

        //    // Thêm cột Hành động với nút Sửa và Xóa
        //    var actionColumn = new Guna2DataGridViewButtonColumn
        //    {
        //        Name = "Actions",
        //        HeaderText = "Hành động",
        //        Text = "Sửa|Xóa",
        //        UseColumnTextForButtonValue = false
        //    };
        //    guna2DataGridView1.Columns.Add(actionColumn);

        //    // Định dạng cột
        //    guna2DataGridView1.Columns["Price"].DefaultCellStyle.Format = "N0";
        //    guna2DataGridView1.Columns["Total"].DefaultCellStyle.Format = "N0";
        //    guna2DataGridView1.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    guna2DataGridView1.Columns["Size"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    // Gắn sự kiện CellContentClick
        //    guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
        //}
        //private void LoadProducts()
        //{
        //    var foods = daoFood.GetAllFood();
        //    foreach (System.Data.DataRow row in foods.Rows)
        //    {
        //        var product = new ProductUserControl(
        //            Convert.ToInt32(row["FoodId"]),
        //            row["NameFood"].ToString(),
        //            row["Photo"].ToString(),
        //            Convert.ToDecimal(row["Price_S"]),
        //            Convert.ToDecimal(row["Price_M"]),
        //            Convert.ToDecimal(row["Price_L"])
        //        );
        //        product.ProductSelected += ProductUserControl_ProductSelected;
        //        flowLayoutPanel1.Controls.Add(product); // Giả định flowLayoutPanel1 chứa các ProductUserControl
        //    }
        //}

        // Xử lý sự kiện khi chọn sản phẩm
        private void ProductUserControl_ProductSelected(object sender, FoodInCart foodInCart)
        {
            // Thêm dòng mới vào DataGridView
            guna2DataGridView1.Rows.Add(
                foodInCart.NameFood,
                foodInCart.Quantity,
                foodInCart.Size,
                foodInCart.Price,
                foodInCart.Amount,
                "Sửa|Xóa" // Giá trị cho cột Hành động
            );
        }
        private void LoadProducts(int? categoryId = null)
        {
            string query = categoryId.HasValue
                ? $"SELECT * FROM Food WHERE CategoryId = {categoryId}"
                : "SELECT * FROM Food";

            flowLayoutPanelProducts.Controls.Clear(); // Clear existing products
            using (SqlConnection connection = new SqlConnection("Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False"))
            {
                SqlDataReader reader;
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                while (reader.Read())
                {
                    string productName = reader["NameFood"].ToString();
                    string relativePath = reader["Photo"].ToString(); // Ví dụ: "espresso.png"
                    string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                    decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                    decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                    decimal price3 = Convert.ToDecimal(reader["Price_L"]);
                    ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price1, price2, price3);
                    flowLayoutPanelProducts.Controls.Add(productControl);
                }
            }
        }

        private void LoadCategories()
        {
            // Lấy danh sách danh mục từ cơ sở dữ liệu
            string query = "SELECT * FROM Category";
            using (SqlConnection connection = new SqlConnection("Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False"))
            {
                SqlDataReader reader;
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();

                    // --- Sao chép style từ guna2Button1 (nút mẫu trên form) ---
                    b.Size = guna2Button1.Size;
                    b.FillColor = guna2Button1.FillColor;
                    b.Font = guna2Button1.Font;
                    b.ForeColor = guna2Button1.ForeColor;
                    b.BorderRadius = guna2Button1.BorderRadius;
                    b.TextAlign = guna2Button1.TextAlign;
                    b.Cursor = guna2Button1.Cursor;
                    b.Margin = guna2Button1.Margin;
                    b.Padding = guna2Button1.Padding;
                    b.HoverState.FillColor = guna2Button1.HoverState.FillColor;
                    b.HoverState.ForeColor = guna2Button1.HoverState.ForeColor;
                    b.HoverState.BorderColor = guna2Button1.HoverState.BorderColor;

                    // --- Thiết lập giá trị ---
                    b.Text = reader["NameCategory"].ToString();
                    b.Tag = Convert.ToInt32(reader["CategoryId"]); // Gắn ID vào nút

                    // --- Sự kiện click ---
                    b.Click += CategoryButton_Click;

                    // --- Thêm vào FlowLayoutPanel ---
                    flowLayoutPanelCategories.Controls.Add(b);
                }
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            if (clickedButton == null) return;

            int categoryId = (int)clickedButton.Tag;
            LoadProducts(categoryId); // Lọc sản phẩm theo danh mục
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Dừng timer hiện tại và bắt đầu lại
            searchTimer.Stop();
            searchTimer.Start();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedOption)) return;

            try
            {
                flowLayoutPanelProducts.Controls.Clear(); // Xóa danh sách sản phẩm hiện tại

                string connectionString = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";
                string query = "SELECT * FROM Food";

                // Thêm điều kiện sắp xếp dựa trên lựa chọn
                if (selectedOption == "A-Z")
                    query += " ORDER BY NameFood ASC";
                else if (selectedOption == "Z-A")
                    query += " ORDER BY NameFood DESC";
                // "Tất cả" hoặc tùy chọn khác không cần sắp xếp, giữ mặc định

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]);

                        // Tạo ProductUserControl và thêm vào FlowLayoutPanel
                        ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price1, price2, price3);
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }

                // Làm mới giao diện
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSize = comboBox2.SelectedItem?.ToString() ?? "Tất cả";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox2.Text, out decimal price))
                maxPrice = price;
            else
                maxPrice = null; // Nếu không parse được, đặt về null
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal price))
                minPrice = price;
            else
                minPrice = null; // Nếu không parse được, đặt về null
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear(); // Xóa danh sách sản phẩm hiện tại

                string connectionString = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";
                string query = "SELECT * FROM Food";
                var conditions = new List<string>();

                // Xác định cột giá dựa trên size
                string priceColumn;
                if (selectedSize == "S") priceColumn = "Price_S";
                else if (selectedSize == "M") priceColumn = "Price_M";
                else if (selectedSize == "L") priceColumn = "Price_L";
                else priceColumn = null; // Tất cả size

                // Thêm điều kiện lọc theo giá
                if (minPrice.HasValue)
                {
                    if (priceColumn != null)
                        conditions.Add($"{priceColumn} >= @minPrice");
                    else
                        conditions.Add("(Price_S >= @minPrice OR Price_M >= @minPrice OR Price_L >= @minPrice)");
                }
                if (maxPrice.HasValue)
                {
                    if (priceColumn != null)
                        conditions.Add($"{priceColumn} <= @maxPrice");
                    else
                        conditions.Add("(Price_S <= @maxPrice OR Price_M <= @maxPrice OR Price_L <= @maxPrice)");
                }

                // Kết hợp các điều kiện
                if (conditions.Count > 0)
                    query += " WHERE " + string.Join(" AND ", conditions);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    if (minPrice.HasValue)
                        cmd.Parameters.AddWithValue("@minPrice", minPrice.Value);
                    if (maxPrice.HasValue)
                        cmd.Parameters.AddWithValue("@maxPrice", maxPrice.Value);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader["NameFood"].ToString();
                        string relativePath = reader["Photo"].ToString();
                        string imageUrl = Path.Combine(Application.StartupPath, "Images", relativePath);
                        decimal price1 = Convert.ToDecimal(reader["Price_S"]);
                        decimal price2 = Convert.ToDecimal(reader["Price_M"]);
                        decimal price3 = Convert.ToDecimal(reader["Price_L"]); // Hiển thị giá Small mặc định

                        ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price1, price2, price3);
                        flowLayoutPanelProducts.Controls.Add(productControl);
                    }
                }

                // Làm mới giao diện
                flowLayoutPanelProducts.Refresh();
                flowLayoutPanelProducts.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Xử lý nút Sửa
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Actions" && guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() == "Sửa")
            {
                string productName = guna2DataGridView1.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                decimal price = decimal.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());

                // Hiển thị hộp thoại để nhập số lượng mới
                string input = Microsoft.VisualBasic.Interaction.InputBox($"Nhập số lượng mới cho {productName}:", "Sửa số lượng", guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
                {
                    guna2DataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = newQuantity;
                    guna2DataGridView1.Rows[e.RowIndex].Cells["Total"].Value = newQuantity * price;
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Xử lý nút Xóa
            else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Actions" && guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() == "Xóa")
            {
                guna2DataGridView1.Rows.RemoveAt(e.RowIndex);
                // Cập nhật lại số thứ tự
                orderIndex = 1;
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    row.Cells["OrderIndex"].Value = orderIndex++;
                }
            }
        }
         private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Actions")
            {
                e.Value = "Sửa | Xóa";
                e.FormattingApplied = true;
            }
        }

        private void productUserControl1_Load(object sender, EventArgs e)
        {

        }
        private void SetupDataGridViewColumns()
        {
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.AutoGenerateColumns = false;

            // Cột Số thứ tự
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderIndex",
                HeaderText = "STT",
                Width = 50
            });

            // Cột Tên sản phẩm
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Tên sản phẩm",
                Width = 150
            });

            // Cột Số lượng
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Số lượng",
                Width = 80
            });

            // Cột Giá tiền
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Giá tiền",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Cột Thành tiền
            guna2DataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Thành tiền",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Cột Hành động
            DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Hành động",
                Width = 150,
                UseColumnTextForButtonValue = false
            };
            guna2DataGridView1.Columns.Add(actionColumn);
        }
        private int orderIndex = 1; // Biến đếm số thứ tự
        private void AddOrUpdateProductToGrid(string productName, decimal price)
        {
            // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["ProductName"].Value?.ToString() == productName)
                {
                    // Tăng số lượng
                    int currentQuantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = currentQuantity + 1;
                    // Cập nhật thành tiền
                    row.Cells["Total"].Value = (currentQuantity + 1) * price;
                    return;
                }
            }

            // Thêm sản phẩm mới
            guna2DataGridView1.Rows.Add(orderIndex++, productName, 1, price, price);
        }
    }
}
