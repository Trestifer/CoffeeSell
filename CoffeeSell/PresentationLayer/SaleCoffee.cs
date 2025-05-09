using CoffeeSell.ObjClass;
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
        private System.Windows.Forms.Timer searchTimer; // Dùng đúng loại Timer
        private string connectionString = "Server=26.58.112.204,1433;Database=QuanLyBanCafe;User Id=trestifer;Password=tam73105;Encrypt=False";
        public SaleCoffee()
        {
            InitializeComponent();
            guna2TextBox1.Font = new Font("Segoe UI", 14); // 14pt, chữ bự
            guna2TextBox1.PlaceholderText = "Tìm kiếm...";
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
                        decimal price = Convert.ToDecimal(reader["Price_S"]);

                        // Tạo ProductUserControl và thêm vào FlowLayoutPanel
                        ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price);
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
                    decimal price = Convert.ToDecimal(reader["Price_S"]);
                    ProductUserControl productControl = new ProductUserControl(productName, imageUrl, price);
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

    }
}
