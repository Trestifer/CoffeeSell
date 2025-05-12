using CoffeeSell.DataAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

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
            chartRevenueByMonth.Location = new System.Drawing.Point(1000 - 400, 600 - 400); // Căn sát góc phải và đáy
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
                DataTable billTable = daoBill.GetAllBill();

                if (billTable == null)
                {
                    System.Diagnostics.Debug.WriteLine("Dữ liệu trả về từ bảng Bill là null.");
                    label1.Text = "0 VNĐ";
                    label2.Text = "0";
                    label3.Text = "0";
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Số hàng trong Bill: {billTable.Rows.Count}");

                decimal totalRevenue = 0;
                int totalUniqueBills = 0;
                int totalUniqueFoods = 0;

                // Tính tổng doanh thu từ TotalPrice
                foreach (DataRow billRow in billTable.Rows)
                {
                    if (billRow["TotalPrice"] != DBNull.Value)
                    {
                        totalRevenue += Convert.ToDecimal(billRow["TotalPrice"]);
                    }
                }

                // Đếm số lượng hóa đơn duy nhất
                var uniqueBillIds = new HashSet<int>();
                foreach (DataRow billRow in billTable.Rows)
                {
                    if (billRow.Table.Columns.Contains("BillId"))
                    {
                        uniqueBillIds.Add(Convert.ToInt32(billRow["BillId"]));
                    }
                }
                totalUniqueBills = uniqueBillIds.Count;
                System.Diagnostics.Debug.WriteLine($"Tổng số hóa đơn duy nhất: {totalUniqueBills}");

                // Đếm số lượng món ăn duy nhất từ bảng Food
                DataTable foodTable = daoFood.GetAllFood();
                if (foodTable != null)
                {
                    var uniqueFoodIds = new HashSet<int>();
                    foreach (DataRow foodRow in foodTable.Rows)
                    {
                        if (foodRow.Table.Columns.Contains("FoodId"))
                        {
                            uniqueFoodIds.Add(Convert.ToInt32(foodRow["FoodId"]));
                        }
                    }
                    totalUniqueFoods = uniqueFoodIds.Count;
                    System.Diagnostics.Debug.WriteLine($"Tổng số loại món ăn duy nhất: {totalUniqueFoods}");
                }

                // Cập nhật các label
                label1.Text = totalRevenue.ToString("N0") + "K VNĐ"; // Tổng doanh thu từ TotalPrice
                label2.Text = totalUniqueBills.ToString(); // Số lượng hóa đơn
                label3.Text = totalUniqueFoods.ToString(); // Số lượng món ăn
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

                if (billTable == null)
                {
                    System.Diagnostics.Debug.WriteLine("Dữ liệu trả về từ bảng Bill là null.");
                    return;
                }

                decimal[] monthlyRevenue = new decimal[12];
                Array.Clear(monthlyRevenue, 0, 12);

                foreach (DataRow billRow in billTable.Rows)
                {
                    if (billRow["DateCheckIn"] != DBNull.Value && billRow["TotalPrice"] != DBNull.Value)
                    {
                        DateTime dateCheckIn = Convert.ToDateTime(billRow["DateCheckIn"]);
                        if (dateCheckIn.Year == year)
                        {
                            int month = dateCheckIn.Month - 1;
                            monthlyRevenue[month] += Convert.ToDecimal(billRow["TotalPrice"]);
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