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
                System.Diagnostics.Debug.WriteLine($"LoadRevenueReport được gọi với ngày: {selectedDate:dd/MM/yyyy}");

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable billInfoTable = daoBillInfo.GetBillInfoByDate(selectedDate);
                System.Diagnostics.Debug.WriteLine($"Lọc theo ngày (Revenue): {selectedDate:dd/MM/yyyy}, Số hàng BillInfo: {billInfoTable?.Rows.Count ?? 0}");

                DataTable foodTable = daoFood.GetAllFood();
                System.Diagnostics.Debug.WriteLine($"Số hàng Food: {foodTable?.Rows.Count ?? 0}");

                // Kiểm tra dữ liệu rỗng
                if (billInfoTable == null || billInfoTable.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Không có dữ liệu BillInfo cho ngày {selectedDate:dd/MM/yyyy}.");
                    guna2DataGridView1.DataSource = null;
                    label3.Text = "0 VNĐ";
                    MessageBox.Show($"Không có dữ liệu hóa đơn cho ngày {selectedDate:dd/MM/yyyy}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (foodTable == null || foodTable.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Không có dữ liệu Food trong cơ sở dữ liệu.");
                    guna2DataGridView1.DataSource = null;
                    label3.Text = "0 VNĐ";
                    MessageBox.Show("Không có dữ liệu món ăn trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tổng hợp doanh thu theo từng món
                var foodRevenue = new Dictionary<int, decimal>();
                int validRows = 0; // Đếm số hàng hợp lệ
                foreach (DataRow billRow in billInfoTable.Rows)
                {
                    try
                    {
                        int foodId = billRow["IdFood"] != DBNull.Value ? Convert.ToInt32(billRow["IdFood"]) : -1;
                        int quantity = billRow["Quantity"] != DBNull.Value ? Convert.ToInt32(billRow["Quantity"]) : 0;
                        decimal foodPrice = billRow["foodPrice"] != DBNull.Value ? Convert.ToDecimal(billRow["foodPrice"]) : 0;

                        System.Diagnostics.Debug.WriteLine($"Xử lý hàng BillInfo: IdFood={foodId}, Quantity={quantity}, foodPrice={foodPrice}");

                        if (foodId == -1 || quantity == 0 || foodPrice == 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"Dữ liệu không hợp lệ trong BillInfo: IdFood={foodId}, Quantity={quantity}, foodPrice={foodPrice}");
                            continue;
                        }

                        DataRow[] foodRows = foodTable.Select($"FoodId = {foodId}");
                        if (foodRows.Length > 0)
                        {
                            decimal revenue = foodPrice * quantity;
                            if (foodRevenue.ContainsKey(foodId))
                            {
                                foodRevenue[foodId] += revenue;
                            }
                            else
                            {
                                foodRevenue[foodId] = revenue;
                            }
                            validRows++;
                            System.Diagnostics.Debug.WriteLine($"Thêm doanh thu: FoodId={foodId}, Revenue={revenue}");
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Không tìm thấy món với FoodId = {foodId} trong Food.");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi xử lý hàng BillInfo: {ex.Message}");
                        continue;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Số hàng BillInfo hợp lệ: {validRows}");
                if (validRows == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Không có hàng BillInfo nào hợp lệ để tính doanh thu.");
                    guna2DataGridView1.DataSource = null;
                    label3.Text = "0 VNĐ";
                    MessageBox.Show("Không có dữ liệu hóa đơn hợp lệ để hiển thị báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tính tổng doanh thu
                decimal totalRevenue = foodRevenue.Values.Sum();
                System.Diagnostics.Debug.WriteLine($"Tổng doanh thu: {totalRevenue}");

                // Chuẩn bị dữ liệu cho DataGridView
                DataTable reportTable = new DataTable();
                reportTable.Columns.Add("STT", typeof(int));
                reportTable.Columns.Add("Tên thức uống", typeof(string));
                reportTable.Columns.Add("Doanh thu", typeof(decimal));
                reportTable.Columns.Add("Tỷ lệ", typeof(string));

                int stt = 1;
                foreach (DataRow foodRow in foodTable.Rows)
                {
                    try
                    {
                        int foodId = Convert.ToInt32(foodRow["FoodId"]);
                        if (foodRevenue.ContainsKey(foodId))
                        {
                            string name = foodRow["NameFood"]?.ToString() ?? "Không xác định";
                            decimal revenue = foodRevenue[foodId];
                            double ratio = totalRevenue > 0 ? (double)revenue / (double)totalRevenue * 100 : 0;
                            reportTable.Rows.Add(stt++, name, revenue, $"{ratio:F2}%");
                            System.Diagnostics.Debug.WriteLine($"Thêm vào báo cáo: FoodId={foodId}, Name={name}, Revenue={revenue}, Ratio={ratio:F2}%");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi xử lý hàng Food: {ex.Message}");
                        continue;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Số hàng trong reportTable: {reportTable.Rows.Count}");
                if (reportTable.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("reportTable rỗng, không có dữ liệu để hiển thị.");
                    MessageBox.Show("Không có dữ liệu hợp lệ để hiển thị báo cáo doanh thu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Gán dữ liệu vào DataGridView
                guna2DataGridView1.DataSource = null; // Xóa dữ liệu cũ
                guna2DataGridView1.DataSource = reportTable;

                // Tùy chỉnh giao diện DataGridView
                guna2DataGridView1.AutoGenerateColumns = true;
                guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
                guna2DataGridView1.ColumnHeadersHeight = 40;

                // Hiển thị tổng doanh thu trên label3
                label3.Text = totalRevenue.ToString("N0") + "K VNĐ";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadRevenueReport error: {ex.Message}\nStackTrace: {ex.StackTrace}");
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