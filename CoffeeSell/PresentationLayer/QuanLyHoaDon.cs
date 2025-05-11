using CoffeeSell.BO;
using CoffeeSell.DataAccessLayer;
using CoffeeSell.Ulti;
using System;
using System.Data;
using System.Windows.Forms;

namespace CoffeeSell
{
    public partial class QuanLyHoaDon : Form
    {
        DataTable AllBill;
        private DAOBill daoBill = new DAOBill();
        private DAOBillInfo daoBillInfo = new DAOBillInfo();
        private DAOFood daoFood = new DAOFood();

        public QuanLyHoaDon()
        {
            InitializeComponent();
            AllBill = daoBill.GetBillWithCustomerInfo();
            KhoiTaoComboBox();
            TaiLaiDuLieu();
            CapNhatTongDoanhThu();
        }

        private void KhoiTaoComboBox()
        {
            comboBox3.Items.Clear();
            int namHienTai = DateTime.Now.Year;

            for (int nam = 2020; nam <= namHienTai; nam++)
            {
                for (int thang = 1; thang <= 12; thang++)
                {
                    if (nam == namHienTai && thang > DateTime.Now.Month)
                        continue;

                    string item = $"{thang:D2}/{nam}";
                    comboBox3.Items.Add(item);
                }
            }

            comboBox3.SelectedItem = $"{DateTime.Now.Month:D2}/{namHienTai}";
        }

        private void TaiLaiDuLieu()
        {
            guna2DataGridView1.DataSource = AllBill;
            guna2DataGridView1.Show();
            guna2DataGridView3.DataSource = null;
            guna2DataGridView3.Show();
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView2.ColumnHeadersHeight = 40;

            if (guna2DataGridView1.Columns.Contains("BillId"))
                guna2DataGridView1.Columns["BillId"].HeaderText = "Mã Hóa Đơn";
            if (guna2DataGridView1.Columns.Contains("DateCheckIn"))
            {
                guna2DataGridView1.Columns["DateCheckIn"].HeaderText = "Ngày Lập Hóa Đơn";
                guna2DataGridView1.Columns["DateCheckIn"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (guna2DataGridView1.Columns.Contains("TotalPrice"))
            {
                guna2DataGridView1.Columns["TotalPrice"].HeaderText = "Tổng Tiền";
                guna2DataGridView1.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            }
            if (guna2DataGridView1.Columns.Contains("NameCustomer"))
                guna2DataGridView1.Columns["NameCustomer"].HeaderText = "Tên Khách Hàng";
            if (guna2DataGridView1.Columns.Contains("PhoneNumber"))
                guna2DataGridView1.Columns["PhoneNumber"].HeaderText = "Số Điện Thoại";
            if (guna2DataGridView1.Columns.Contains("StatusBill"))
                guna2DataGridView1.Columns["StatusBill"].Visible = false;
        }

        private void CapNhatTongDoanhThu()
        {
            decimal tongDoanhThu = 0;
            foreach (DataRow row in AllBill.Rows)
            {
                if (row["TotalPrice"] != DBNull.Value)
                    tongDoanhThu += Convert.ToDecimal(row["TotalPrice"]);
            }
            label4.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
        }

        private void LocHoaDonTheoThangNam(string thangNam)
        {
            try
            {
                string[] parts = thangNam.Split('/');
                int thang = Convert.ToInt32(parts[0]);
                int nam = Convert.ToInt32(parts[1]);

                DataTable hoaDonLoc = AllBill.Clone();
                foreach (DataRow dong in AllBill.Rows)
                {
                    if (dong["DateCheckIn"] != DBNull.Value)
                    {
                        DateTime ngayHoaDon = Convert.ToDateTime(dong["DateCheckIn"]);
                        if (ngayHoaDon.Year == nam && ngayHoaDon.Month == thang)
                        {
                            hoaDonLoc.ImportRow(dong);
                        }
                    }
                }

                guna2DataGridView1.DataSource = hoaDonLoc;
                if (guna2DataGridView1.Columns.Contains("DateCheckIn"))
                {
                    guna2DataGridView1.Columns["DateCheckIn"].HeaderText = "Ngày Lập Hóa Đơn";
                    guna2DataGridView1.Columns["DateCheckIn"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (guna2DataGridView1.Columns.Contains("TotalPrice"))
                    guna2DataGridView1.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
                if (guna2DataGridView1.Columns.Contains("StatusBill"))
                    guna2DataGridView1.Columns["StatusBill"].Visible = false;

                decimal tongDoanhThu = 0;
                foreach (DataRow row in hoaDonLoc.Rows)
                {
                    if (row["TotalPrice"] != DBNull.Value)
                        tongDoanhThu += Convert.ToDecimal(row["TotalPrice"]);
                }
                label4.Text = $"Tổng Doanh Thu: {tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LocHoaDonTheoThangNam error: {ex.Message}");
                MessageBox.Show("Lỗi khi lọc hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                string thangNam = comboBox3.SelectedItem.ToString();
                LocHoaDonTheoThangNam(thangNam);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int maHoaDon = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["BillId"].Value);
                    string path = (guna2DataGridView1.SelectedRows[0].Cells["Photo"].Value).ToString();
                    PhotoFunction.OpenImageByName(path);
                    HienThiChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"button1_Click error: {ex.Message}");
                    MessageBox.Show("Lỗi khi xem chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int maHoaDon = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["BillId"].Value);
                    HienThiChiTietHoaDon(maHoaDon);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"guna2DataGridView1_CellClick error: {ex.Message}");
                }
            }
        }

        private void HienThiChiTietHoaDon(int maHoaDon)
        {
            try
            {
                // Lấy chi tiết hóa đơn
                DataTable bangChiTietHoaDon = daoBillInfo.GetAllBillInfo();
                System.Diagnostics.Debug.WriteLine($"Số dòng trong BillInfo: {bangChiTietHoaDon.Rows.Count}");
                if (bangChiTietHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết hóa đơn trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!bangChiTietHoaDon.Columns.Contains("IdBill") || !bangChiTietHoaDon.Columns.Contains("IdFood") || !bangChiTietHoaDon.Columns.Contains("Quantity"))
                {
                    throw new Exception("Bảng BillInfo thiếu cột cần thiết (IdBill, IdFood, hoặc Quantity).");
                }

                DataRow[] dongChiTiet = bangChiTietHoaDon.Select($"IdBill = {maHoaDon}");
                System.Diagnostics.Debug.WriteLine($"Số dòng khớp với IdBill {maHoaDon}: {dongChiTiet.Length}");
                if (dongChiTiet.Length == 0)
                {
                    guna2DataGridView3.DataSource = null;
                    MessageBox.Show($"Hóa đơn {maHoaDon} không có chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo DataTable mới để hiển thị thông tin chi tiết
                DataTable chiTiet = new DataTable();
                chiTiet.Columns.Add("Id", typeof(int));
                chiTiet.Columns.Add("IdBill", typeof(int));
                chiTiet.Columns.Add("TenMon", typeof(string));
                chiTiet.Columns.Add("Gia", typeof(decimal));
                chiTiet.Columns.Add("SoLuong", typeof(int));
                chiTiet.Columns.Add("ThanhTien", typeof(decimal));

                // Lấy danh sách món ăn
                DataTable allFood = daoFood.GetAllFood();
                System.Diagnostics.Debug.WriteLine($"Số dòng trong Food: {allFood.Rows.Count}");
                if (allFood.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu món ăn trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!allFood.Columns.Contains("FoodId") || !allFood.Columns.Contains("NameFood") || !allFood.Columns.Contains("Price_M"))
                {
                    throw new Exception("Bảng Food thiếu cột cần thiết (FoodId, NameFood, hoặc Price_M).");
                }

                // Điền dữ liệu vào DataTable chi tiết
                foreach (DataRow row in dongChiTiet)
                {
                    int idFood = Convert.ToInt32(row["IdFood"]);
                    DataRow[] foodRows = allFood.Select($"FoodId = {idFood}");
                    if (foodRows.Length > 0)
                    {
                        DataRow foodRow = foodRows[0];
                        string tenMon = foodRow["NameFood"].ToString();
                        decimal gia = Convert.ToDecimal(foodRow["Price_S"]);
                        int soLuong = Convert.ToInt32(row["Quantity"]);
                        decimal thanhTien = gia * soLuong;

                        chiTiet.Rows.Add(
                            row["Id"],
                            row["IdBill"],
                            tenMon,
                            gia,
                            soLuong,
                            thanhTien
                        );
                        System.Diagnostics.Debug.WriteLine($"Thêm dòng: Id={row["Id"]}, TenMon={tenMon}, Gia={gia}, SoLuong={soLuong}, ThanhTien={thanhTien}");
                    }
                    else
                    {
                        // Nếu không tìm thấy món ăn, hiển thị thông tin mặc định
                        chiTiet.Rows.Add(
                            row["Id"],
                            row["IdBill"],
                            "Món không tồn tại",
                            0,
                            Convert.ToInt32(row["Quantity"]),
                            0
                        );
                        System.Diagnostics.Debug.WriteLine($"Không tìm thấy món với IdFood={idFood}");
                    }
                }

                // Gán DataTable vào DataGridView và làm mới
                guna2DataGridView2.DataSource = null; // Xóa dữ liệu cũ
                guna2DataGridView2.DataSource = chiTiet;
                guna2DataGridView2.Refresh(); // Làm mới DataGridView

                // Định dạng cột
                if (guna2DataGridView2.Columns.Contains("Id"))
                    guna2DataGridView2.Columns["Id"].HeaderText = "Mã Chi Tiết";
                if (guna2DataGridView2.Columns.Contains("IdBill"))
                    guna2DataGridView2.Columns["IdBill"].HeaderText = "Mã Hóa Đơn";
                if (guna2DataGridView2.Columns.Contains("TenMon"))
                    guna2DataGridView2.Columns["TenMon"].HeaderText = "Tên Món";
                if (guna2DataGridView2.Columns.Contains("Gia"))
                {
                    guna2DataGridView2.Columns["Gia"].HeaderText = "Giá";
                    guna2DataGridView2.Columns["Gia"].DefaultCellStyle.Format = "N0";
                }
                if (guna2DataGridView2.Columns.Contains("SoLuong"))
                    guna2DataGridView2.Columns["SoLuong"].HeaderText = "Số Lượng";
                if (guna2DataGridView2.Columns.Contains("ThanhTien"))
                {
                    guna2DataGridView2.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    guna2DataGridView2.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"HienThiChiTietHoaDon error: {ex.Message}");
                MessageBox.Show("Lỗi khi hiển thị chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}