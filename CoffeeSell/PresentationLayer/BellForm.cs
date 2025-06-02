using CoffeeSell.DataAccessLayer;
using CoffeeSell.ObjClass;
using CoffeeSell.BO; // Import namespace của lớp BOEsp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell.PresentationLayer
{
    public partial class BellForm : Form
    {
        private BOEsp _boEsp; // Khai báo một thể hiện của BOEsp

        public BellForm()
        {
            InitializeComponent();
            _boEsp = new BOEsp(); // Khởi tạo BOEsp
            LoadEspDevicesToDataGridView();
        }

        private void LoadEspDevicesToDataGridView()
        {
            DataTable devices = _boEsp.GetAllEspDevices(); // Gọi qua BOEsp

            if (devices != null)
            {
                guna2DataGridView1.DataSource = devices;

                guna2DataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                guna2DataGridView1.ColumnHeadersHeight = 35;

                guna2DataGridView1.Columns["DeviceId"].HeaderText = "Mã Thiết Bị";
                guna2DataGridView1.Columns["AssignedMAC"].HeaderText = "Địa Chỉ MAC";
                guna2DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu thiết bị từ cơ sở dữ liệu.", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Empty method
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];

                if (row.Cells["DeviceId"].Value != null)
                {
                    textBox1.Text = row.Cells["DeviceId"].Value.ToString();
                }
                else
                {
                    textBox1.Clear();
                }
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e) // Thêm thiết bị
        {
            string deviceId = textBox1.Text;
            string assignedMAC = GetMacAddressOfFirstActiveAdapter();

            if (string.IsNullOrEmpty(deviceId))
            {
                MessageBox.Show("Vui lòng nhập Device ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (assignedMAC == "MAC Not Found")
            {
                MessageBox.Show("Không thể lấy địa chỉ MAC của thiết bị. Vui lòng kiểm tra kết nối mạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ESP newEspDevice = new ESP(deviceId, assignedMAC);
            string result = _boEsp.CreateEspDevice(newEspDevice); // Gọi qua BOEsp
            string buzzUrl = $"http://esp8266.local/verify?id={deviceId+GetMacAddressOfFirstActiveAdapter}";
            Console.WriteLine($"Buzz URL: {buzzUrl}");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var buzzResponse = await client.GetAsync(buzzUrl);
                    string buzzContent = await buzzResponse.Content.ReadAsStringAsync();

                    if (!buzzResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Đăng ký thất bại cho thiết bị có mã{deviceId}", "Lỗi khi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi lệnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (result == "Success")
            {
                MessageBox.Show("Thiết bị ESP đã được thêm thành công vào cơ sở dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                LoadEspDevicesToDataGridView(); // Tải lại dữ liệu sau khi thêm thành công
            }
            else
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm thiết bị ESP: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Empty method
        }

        private string GetMacAddressOfFirstActiveAdapter()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up &&
                    (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                     nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    string macAddress = nic.GetPhysicalAddress().ToString();
                    if (!string.IsNullOrEmpty(macAddress))
                    {
                        return string.Join(":", Enumerable.Range(0, macAddress.Length / 2)
                                                         .Select(i => macAddress.Substring(i * 2, 2)));
                    }
                }
            }
            return "MAC Not Found";
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Xóa thiết bị
        {
            string deviceIdToDelete = textBox1.Text;

            if (string.IsNullOrEmpty(deviceIdToDelete))
            {
                MessageBox.Show("Vui lòng nhập Device ID của thiết bị cần xóa vào ô văn bản hoặc chọn từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thiết bị với ID: '{deviceIdToDelete}'?",
                "Xác nhận xóa thiết bị",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                string result = _boEsp.DeleteEspDevice(deviceIdToDelete); // Gọi qua BOEsp

                if (result == "Success")
                {
                    MessageBox.Show($"Thiết bị với ID '{deviceIdToDelete}' đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    LoadEspDevicesToDataGridView(); // Tải lại dữ liệu sau khi xóa thành công
                }
                else
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa thiết bị: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}