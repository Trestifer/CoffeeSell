using CoffeeSell.DataAccessLayer;
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
    public partial class BaoCao : Form
    {
        private DAOBillInfo daoBillInfo = new DAOBillInfo();
        private DAOFood daoFood = new DAOFood();
        private bool isInitialLoad = true; // Biến để kiểm soát lần tải đầu tiên

        public BaoCao()
        {
            InitializeComponent();
            // Định dạng DateTimePicker theo MM/dd/yyyy
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";

            // Đặt ngày mặc định là ngày hiện tại
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;

            LoadDrinkReport(dateTimePicker1.Value.Date); // Tải báo cáo số lượng
            LoadRevenueReport(dateTimePicker2.Value.Date); // Tải báo cáo doanh thu
        }

        private void LoadDrinkReport(DateTime selectedDate)
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu, lọc theo ngày chính xác
                DataTable billInfoTable = daoBillInfo.GetBillInfoByDate(selectedDate);
                System.Diagnostics.Debug.WriteLine($"Lọc theo ngày (Drink): {selectedDate:MM/dd/yyyy}, Số hàng: {billInfoTable.Rows.Count}");

                DataTable foodTable = daoFood.GetAllFood();

                if (billInfoTable == null || foodTable == null)
                {
                    MessageBox.Show("Lỗi khi truy xuất dữ liệu từ cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2DataGridView2.DataSource = null;
                    label7.Text = "0";
                    return;
                }

                var foodSales = new Dictionary<int, int>();
                foreach (DataRow billRow in billInfoTable.Rows)
                {
                    int foodId = Convert.ToInt32(billRow["IdFood"]);
                    int quantity = Convert.ToInt32(billRow["Quantity"]);
                    if (foodSales.TryGetValue(foodId, out int existingQuantity))
                    {
                        foodSales[foodId] = existingQuantity + quantity;
                    }
                    else
                    {
                        foodSales[foodId] = quantity;
                    }
                }

                int totalQuantity = foodSales.Values.Sum();

                DataTable reportTable = new DataTable();
                reportTable.Columns.Add("STT", typeof(int));
                reportTable.Columns.Add("Tên thức uống", typeof(string));
                reportTable.Columns.Add("Số lượng", typeof(int));
                reportTable.Columns.Add("Tỷ lệ", typeof(string));

                int stt = 1;
                foreach (DataRow foodRow in foodTable.Rows)
                {
                    int foodId = Convert.ToInt32(foodRow["FoodId"]);
                    if (foodSales.ContainsKey(foodId))
                    {
                        string name = foodRow["NameFood"]?.ToString() ?? "Không xác định";
                        int quantity = foodSales[foodId];
                        double ratio = totalQuantity > 0 ? (double)quantity / totalQuantity * 100 : 0;
                        reportTable.Rows.Add(stt++, name, quantity, $"{ratio:F2}%");
                    }
                }

                guna2DataGridView2.DataSource = reportTable;
                guna2DataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
                guna2DataGridView2.ColumnHeadersHeight = 40;
                label7.Text = totalQuantity.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadDrinkReport error: {ex.Message}");
                MessageBox.Show("Đã xảy ra lỗi khi tải báo cáo số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DataGridView2.DataSource = null;
                label7.Text = "0";
            }
        }

        private void LoadRevenueReport(DateTime selectedDate)
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu, lọc theo ngày chính xác
                DataTable billInfoTable = daoBillInfo.GetBillInfoByDate(selectedDate);
                System.Diagnostics.Debug.WriteLine($"Lọc theo ngày (Revenue): {selectedDate:MM/dd/yyyy}, Số hàng: {billInfoTable.Rows.Count}");

                DataTable foodTable = daoFood.GetAllFood();

                if (billInfoTable == null || foodTable == null)
                {
                    MessageBox.Show("Lỗi khi truy xuất dữ liệu từ cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2DataGridView1.DataSource = null;
                    label3.Text = "0 VNĐ";
                    return;
                }

                // Tổng hợp doanh thu theo từng món
                var foodRevenue = new Dictionary<int, decimal>();
                foreach (DataRow billRow in billInfoTable.Rows)
                {
                    int foodId = Convert.ToInt32(billRow["IdFood"]);
                    int quantity = Convert.ToInt32(billRow["Quantity"]);

                    // Tìm giá của món trong foodTable (giả sử dùng Price_S, có thể mở rộng cho Price_M, Price_L)
                    DataRow[] foodRows = foodTable.Select($"FoodId = {foodId}");
                    if (foodRows.Length > 0)
                    {
                        decimal price = Convert.ToDecimal(foodRows[0]["Price_M"]); // Sử dụng giá nhỏ làm mặc định
                        decimal revenue = price * quantity;
                        if (foodRevenue.TryGetValue(foodId, out decimal existingRevenue))
                        {
                            foodRevenue[foodId] = existingRevenue + revenue;
                        }
                        else
                        {
                            foodRevenue[foodId] = revenue;
                        }
                    }
                }

                // Tính tổng doanh thu
                decimal totalRevenue = foodRevenue.Values.Sum();

                // Chuẩn bị dữ liệu cho DataGridView
                DataTable reportTable = new DataTable();
                reportTable.Columns.Add("STT", typeof(int));
                reportTable.Columns.Add("Tên thức uống", typeof(string));
                reportTable.Columns.Add("Doanh thu", typeof(decimal));
                reportTable.Columns.Add("Tỷ lệ", typeof(string));

                int stt = 1;
                foreach (DataRow foodRow in foodTable.Rows)
                {
                    int foodId = Convert.ToInt32(foodRow["FoodId"]);
                    if (foodRevenue.ContainsKey(foodId))
                    {
                        string name = foodRow["NameFood"]?.ToString() ?? "Không xác định";
                        decimal revenue = foodRevenue[foodId];
                        double ratio = totalRevenue > 0 ? (double)revenue / (double)totalRevenue * 100 : 0;
                        reportTable.Rows.Add(stt++, name, revenue, $"{ratio:F2}%");
                    }
                }

                // Gán dữ liệu vào DataGridView
                guna2DataGridView1.DataSource = reportTable;

                // Tùy chỉnh giao diện DataGridView
                guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
                guna2DataGridView1.ColumnHeadersHeight = 40;

                // Hiển thị tổng doanh thu trên label3
                label3.Text = totalRevenue.ToString("N0") + "K VNĐ";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadRevenueReport error: {ex.Message}");
                MessageBox.Show("Đã xảy ra lỗi khi tải báo cáo doanh thu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DataGridView1.DataSource = null;
                label3.Text = "0 VNĐ";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialLoad)
            {
                isInitialLoad = false;
                return;
            }

            DateTime selectedDate = dateTimePicker1.Value.Date;
            LoadDrinkReport(selectedDate);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialLoad)
            {
                isInitialLoad = false;
                return;
            }

            DateTime selectedDate = dateTimePicker2.Value.Date;
            LoadRevenueReport(selectedDate);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void BaoCao_Load(object sender, EventArgs e) { }
        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}