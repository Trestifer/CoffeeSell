namespace CoffeeSell
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel9.MouseEnter += guna2HtmlLabel9_MouseEnter;
            guna2HtmlLabel9.MouseLeave += guna2HtmlLabel9_MouseLeave;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TrangChu trangChuForm = new TrangChu();
            trangChuForm.Show();
            this.Hide();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {
            ResetMatKhau resetForm = new ResetMatKhau();
            resetForm.Show();

        }
        private void guna2HtmlLabel9_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel9.ForeColor = Color.Orange; // Ð?i màu ch? sang cam khi hover
        }

        private void guna2HtmlLabel9_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel9.ForeColor = Color.Black; // Khôi ph?c màu ch? ban ð?u
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

