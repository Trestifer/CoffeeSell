using CoffeeSell.DataAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoffeeSell
{
    public partial class NenTrangChu : Form
    {
        private DAOBill daoBill = new DAOBill();
        private DAOBillInfo daoBillInfo = new DAOBillInfo();
        private DAOFood daoFood = new DAOFood();
        private Chart chartRevenueByMonth;

        public NenTrangChu()
        {
            InitializeComponent();
            InitializeChart();
            LoadStatistics();
            InitializeComboBox();
            LoadRevenueChart(DateTime.Now.Year);
        }

        private void InitializeChart()
        {
            chartRevenueByMonth = new Chart();
            chartRevenueByMonth.Size = new System.Drawing.Size(900, 600); // Tăng kích thước biểu đồ
            // Đặt vị trí ở góc dưới cùng bên phải, giả định form có kích thước 1000x600
            chartRevenueByMonth.Location = new System.Drawing.Point(1000 -400, 600-400 ); // Căn sát góc phải và đáy
            chartRevenueByMonth.Name = "chartRevenueByMonth";

            ChartArea chartArea = new ChartArea();
            chartRevenueByMonth.ChartAreas.Add(chartArea);

            this.Controls.Add(chartRevenueByMonth);
        }

        private void InitializeComboBox()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 5; year <= currentYear; year++)
            {
                comboBox1.Items.Add(year);
            }
            comboBox1.SelectedItem = currentYear;
        }

        private void LoadStatistics()
        {
            try
            {
                DateTime currentDate = DateTime.Now.Date;
                System.Diagnostics.Debug.WriteLine($"Đang tải số liệu cho ngày: {currentDate:yyyy-MM-dd}");

                DataTable billTable = daoBill.GetAllBill();
                DataTable billInfoTable = daoBillInfo.GetBillInfoByDate(currentDate);
                DataTable foodTable = daoFood.GetAllFood();

                if (billTable == null || billInfoTable == null || foodTable == null)
                {
                    System.Diagnostics.Debug.WriteLine("Dữ liệu trả về từ một trong các bảng là null.");
                    label1.Text = "0 VNĐ";
                    label2.Text = "0";
                    label3.Text = "0";
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Số hàng - Bill: {billTable.Rows.Count}, BillInfo: {billInfoTable.Rows.Count}, Food: {foodTable.Rows.Count}");

                decimal totalRevenue = 0;
                int totalProducts = 0;

                foreach (DataRow billInfoRow in billInfoTable.Rows)
                {
                    if (!billInfoRow.Table.Columns.Contains("IdBill") || !billInfoRow.Table.Columns.Contains("IdFood") || !billInfoRow.Table.Columns.Contains("Quantity"))
                    {
                        System.Diagnostics.Debug.WriteLine("Cột IdBill, IdFood hoặc Quantity không tồn tại trong BillInfo.");
                        continue;
                    }

                    int billId = Convert.ToInt32(billInfoRow["IdBill"]);
                    int foodId = Convert.ToInt32(billInfoRow["IdFood"]);
                    int quantity = Convert.ToInt32(billInfoRow["Quantity"]);

                    DataRow[] billRows = billTable.Select($"BillId = {billId}");
                    if (billRows.Length > 0)
                    {
                        DateTime dateCheckIn = Convert.ToDateTime(billRows[0]["DateCheckIn"]);
                        if (dateCheckIn.Date != currentDate)
                        {
                            System.Diagnostics.Debug.WriteLine($"Hóa đơn BillId {billId} không thuộc ngày {currentDate:yyyy-MM-dd}.");
                            continue;
                        }

                        DataRow[] foodRows = foodTable.Select($"FoodId = {foodId}");
                        if (foodRows.Length > 0)
                        {
                            if (!foodRows[0].Table.Columns.Contains("Price_S"))
                            {
                                System.Diagnostics.Debug.WriteLine($"Cột Price_S không tồn tại trong bảng Food cho FoodId {foodId}.");
                                continue;
                            }

                            decimal price;
                            try
                            {
                                price = Convert.ToDecimal(foodRows[0]["Price_S"]);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Lỗi chuyển đổi Price_S cho FoodId {foodId}: {ex.Message}");
                                price = 0;
                            }
                            totalRevenue += price * quantity;
                            totalProducts += quantity;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Không tìm thấy FoodId {foodId} trong bảng Food.");
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Không tìm thấy BillId {billId} trong bảng Bill.");
                    }
                }

                int totalBills = billTable.AsEnumerable()
                    .Count(row => row.Field<DateTime>("DateCheckIn").Date == currentDate);
                System.Diagnostics.Debug.WriteLine($"Tổng số hóa đơn: {totalBills}");

                label1.Text = totalRevenue.ToString("N0") + "K VNĐ";
                label2.Text = totalBills.ToString();
                label3.Text = totalProducts.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadStatistics error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                label1.Text = "0 VNĐ";
                label2.Text = "0";
                label3.Text = "0";
            }
        }

        private void LoadRevenueChart(int year)
        {
            try
            {
                chartRevenueByMonth.Series.Clear();
                chartRevenueByMonth.Titles.Clear();

                chartRevenueByMonth.Titles.Add("Doanh Thu Theo Tháng - Năm " + year);

                Series series = new Series("Doanh Thu");
                series.ChartType = SeriesChartType.Column;
                chartRevenueByMonth.Series.Add(series);

                DataTable billTable = daoBill.GetAllBill();
                DataTable billInfoTable = daoBillInfo.GetAllBillInfo();
                DataTable foodTable = daoFood.GetAllFood();

                if (billTable == null || billInfoTable == null || foodTable == null)
                {
                    System.Diagnostics.Debug.WriteLine("Dữ liệu trả về từ một trong các bảng là null.");
                    return;
                }

                decimal[] monthlyRevenue = new decimal[12];
                Array.Clear(monthlyRevenue, 0, 12);

                foreach (DataRow billInfoRow in billInfoTable.Rows)
                {
                    if (!billInfoRow.Table.Columns.Contains("IdBill") || !billInfoRow.Table.Columns.Contains("IdFood") || !billInfoRow.Table.Columns.Contains("Quantity"))
                    {
                        System.Diagnostics.Debug.WriteLine("Cột IdBill, IdFood hoặc Quantity không tồn tại trong BillInfo.");
                        continue;
                    }

                    int billId = Convert.ToInt32(billInfoRow["IdBill"]);
                    int foodId = Convert.ToInt32(billInfoRow["IdFood"]);
                    int quantity = Convert.ToInt32(billInfoRow["Quantity"]);

                    DataRow[] billRows = billTable.Select($"BillId = {billId}");
                    if (billRows.Length > 0)
                    {
                        DateTime dateCheckIn = Convert.ToDateTime(billRows[0]["DateCheckIn"]);
                        if (dateCheckIn.Year == year)
                        {
                            DataRow[] foodRows = foodTable.Select($"FoodId = {foodId}");
                            if (foodRows.Length > 0)
                            {
                                if (!foodRows[0].Table.Columns.Contains("Price_S"))
                                {
                                    System.Diagnostics.Debug.WriteLine($"Cột Price_S không tồn tại trong bảng Food cho FoodId {foodId}.");
                                    continue;
                                }

                                decimal price;
                                try
                                {
                                    price = Convert.ToDecimal(foodRows[0]["Price_S"]);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Lỗi chuyển đổi Price_S cho FoodId {foodId}: {ex.Message}");
                                    price = 0;
                                }
                                int month = dateCheckIn.Month - 1;
                                monthlyRevenue[month] += price * quantity;
                            }
                        }
                    }
                }

                for (int month = 0; month < 12; month++)
                {
                    series.Points.AddXY(month + 1, monthlyRevenue[month]);
                }

                chartRevenueByMonth.ChartAreas[0].AxisX.Title = "Tháng";
                chartRevenueByMonth.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";
                chartRevenueByMonth.ChartAreas[0].AxisX.Interval = 1;
                chartRevenueByMonth.ChartAreas[0].AxisX.Minimum = 1;
                chartRevenueByMonth.ChartAreas[0].AxisX.Maximum = 12;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoadRevenueChart error: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int selectedYear = Convert.ToInt32(comboBox1.SelectedItem);
                LoadRevenueChart(selectedYear);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void NenTrangChu_Load(object sender, EventArgs e)
        {
        }
    }
}