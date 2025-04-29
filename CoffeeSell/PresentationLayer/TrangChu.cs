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
        public TrangChu()
        {
            InitializeComponent();
            // Tạo danh sách các panel
            List<Panel> panels = new List<Panel> { panel1, panel2, panel3, panel4, panel5, panel6, panel7, panel8, panel9 };

            // Dùng vòng lặp để gán sự kiện cho tất cả các panel
            foreach (var p in panels)
            {
                p.MouseEnter += Panel_MouseEnter;
                p.MouseLeave += Panel_MouseLeave;
                p.MouseDown += Panel_MouseDown;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            panel5.Click += Panel5_Click;
            panel6.Click += Panel6_Click;
            panel7.Click += Panel7_Click;
            panel8.Click += Panel8_Click;
            panel9.Click += Panel9_Click;
            
        }
        private void Panel2_Click(object sender, EventArgs e)
        {
            SaleCoffee saleform = new SaleCoffee();
            saleform.Show();
            this.Hide();

        }
        private void Panel1_Click(object sender, EventArgs e)
        {
            TrangChu tcform = new TrangChu();
            tcform.Show();


        }
        private void Panel3_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon hdform = new QuanLyHoaDon();
            hdform.Show();


        }
        private void Panel4_Click(object sender, EventArgs e)
        {
            QuanLySanPham spform = new QuanLySanPham();
            spform.Show();


        }
        private void Panel5_Click(object sender, EventArgs e)
        {
            QuanLyDanhMuc dmform = new QuanLyDanhMuc();
            dmform.Show();


        }
        private void Panel6_Click(object sender, EventArgs e)
        {
            QuanLyKhuyenMai kmform = new QuanLyKhuyenMai();
            kmform.Show();


        }
        private void Panel7_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nvform = new QuanLyNhanVien();
            nvform.Show();


        }
        private void Panel8_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang khform = new QuanLyKhachHang();
            khform.Show();
            this.Hide();

        }
        private void Panel9_Click(object sender, EventArgs e)
        {
            BaoCao bcform = new BaoCao();
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


        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
