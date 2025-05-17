using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.PresentationLayer;
using Guna.UI2.WinForms;
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
    public partial class TrangChu : Form
    {
        private Panel currentPanel = null;
        private Account user;
        public TrangChu(Account _user)
        {
            InitializeComponent();
            panel10.Controls.Clear();
            NenTrangChu tcform = new NenTrangChu();
            tcform.TopLevel = false; // Đặt TopLevel thành false để Form có thể được nhúng
            tcform.FormBorderStyle = FormBorderStyle.None; // Xóa viền của Form (tùy chọn)
            tcform.Dock = DockStyle.Fill; // Đảm bảo Form lấp đầy panel10
            panel10.Controls.Add(tcform);
            tcform.Show();
            // Tạo danh sách các panel
            List<Panel> panels = new List<Panel> { panel1, panel2, panel3, panel4, panel6, panel7, panel8, panel9, panel11 };

            // Dùng vòng lặp để gán sự kiện cho tất cả các panel
            foreach (var p in panels)
            {
                p.MouseEnter += Panel_MouseEnter;
                p.MouseLeave += Panel_MouseLeave;
                p.MouseDown += Panel_MouseDown;
            }
            user = _user;
            lblDisplayName.Text = user.GetDisplayName();
            lblStaff.Text = user.GetTypeAccount() ? "Quản lý" : "Nhân viên";
            UpdateDateTime();
            timer1.Start();
            if (!user.GetTypeAccount()) new[] { panel4, panel6, panel7, panel9, panel11 }.ToList().ForEach(p => p.Visible = false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Panel1_Click(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

            panel1.Click += Panel1_Click;
            panel2.Click += Panel2_Click;
            panel3.Click += Panel3_Click;
            panel4.Click += Panel4_Click;

            panel6.Click += Panel6_Click;
            panel7.Click += Panel7_Click;
            panel8.Click += Panel8_Click;
            panel9.Click += Panel9_Click;
            panel11.Click += Panel11_Click;
            timer1.Interval = 10000; // 10 seconds
            timer1.Tick += timer1_Tick;
            timer1.Start(); // Start the timer

            UpdateDateTime(); // Initial update when form loads
        }
        private void Panel11_Click(object sender, EventArgs e)
        {


            panel10.Controls.Clear();
            LogForm testform = new LogForm();
            testform.TopLevel = false; // Đặt TopLevel thành false để Form có thể được nhúng
            testform.FormBorderStyle = FormBorderStyle.None; // Xóa viền của Form (tùy chọn)
            testform.Dock = DockStyle.Fill; // Đảm bảo Form lấp đầy panel10
            panel10.Controls.Add(testform);
            testform.Show();
        }
        private void Panel2_Click(object sender, EventArgs e)
        {
            SaleCoffee saleform = new SaleCoffee(user);
            saleform.Show();


        }
        private void Panel1_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            NenTrangChu tcform = new NenTrangChu();
            tcform.TopLevel = false; // Đặt TopLevel thành false để Form có thể được nhúng
            tcform.FormBorderStyle = FormBorderStyle.None; // Xóa viền của Form (tùy chọn)
            tcform.Dock = DockStyle.Fill; // Đảm bảo Form lấp đầy panel10
            panel10.Controls.Add(tcform);
            tcform.Show();


        }
        private void Panel3_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            QuanLyHoaDon hdform = new QuanLyHoaDon();
            hdform.TopLevel = false;
            hdform.FormBorderStyle = FormBorderStyle.None;
            hdform.Dock = DockStyle.Fill;
            panel10.Controls.Add(hdform);
            hdform.Show();

        }
        private void Panel4_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            QuanLySanPham spform = new QuanLySanPham(user);
            spform.TopLevel = false;
            spform.FormBorderStyle = FormBorderStyle.None;
            spform.Dock = DockStyle.Fill;
            panel10.Controls.Add(spform);
            spform.Show();


        }
        private void Panel5_Click(object sender, EventArgs e)
        {



        }
        private void Panel6_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            QuanLyKhuyenMai kmform = new QuanLyKhuyenMai(user);
            kmform.TopLevel = false;
            kmform.FormBorderStyle = FormBorderStyle.None;
            kmform.Dock = DockStyle.Fill;
            panel10.Controls.Add(kmform);
            kmform.Show();


        }
        private void Panel7_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            QuanLyNhanVien nvform = new QuanLyNhanVien(user);
            nvform.TopLevel = false;
            nvform.FormBorderStyle = FormBorderStyle.None;
            nvform.Dock = DockStyle.Fill;
            panel10.Controls.Add(nvform);
            nvform.Show();



        }
        private void Panel8_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            QuanLyKhachHang khform = new QuanLyKhachHang(user);
            khform.TopLevel = false;
            khform.FormBorderStyle = FormBorderStyle.None;
            khform.Dock = DockStyle.Fill;
            panel10.Controls.Add(khform);
            khform.Show();

        }
        private void Panel9_Click(object sender, EventArgs e)
        {
            panel10.Controls.Clear();
            BaoCao bcform = new BaoCao();
            bcform.TopLevel = false;
            bcform.FormBorderStyle = FormBorderStyle.None;
            bcform.Dock = DockStyle.Fill;
            panel10.Controls.Add(bcform);
            bcform.Show();


        }


        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && p != currentPanel) // Đổi màu khi hover vào panel và không phải là panel đã chọn
            {
                p.BackColor = Color.FromArgb(0, 94, 165);
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null && p != currentPanel) // Đổi màu lại khi không hover nữa
            {
                p.BackColor = Color.FromArgb(61, 132, 187);
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;

            // Kiểm tra nếu p là một Panel
            if (p != null)
            {
                // Nếu có panel đang được chọn, đổi lại màu ban đầu
                if (currentPanel != null && currentPanel != p)
                {
                    currentPanel.BackColor = Color.FromArgb(61, 132, 187); // Màu mặc định ban đầu của Panel
                }

                // Đổi màu cho panel hiện tại thành màu nâu
                p.BackColor = Color.FromArgb(0, 94, 165);

                // Lưu lại panel hiện tại
                currentPanel = p;
            }
        }



        private void UpdateDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            string[] vietnameseDays = { "Chủ Nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
            lblDays.Text = vietnameseDays[(int)DateTime.Now.DayOfWeek];
            lblTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
            BODiscount.UpdateEndate();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            BOLoginHistory.Logout(user.GetAccountId());
            new Login().Show();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Panel4_Click(sender, e);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (user.GetTypeAccount())
            {
                new CameraForm(user).Show();

            }
            else
            {
                new NhapOTP(user).Show();
            }
            BOLoginHistory.Logout(user.GetAccountId());
            this.Close();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Panel2_Click(sender, e);
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Panel3_Click(sender, e);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Panel8_Click(sender, e);
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            Panel11_Click(sender, e);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Panel6_Click(sender, e);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Panel7_Click(sender, e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Panel9_Click(sender, e);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
