
using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using CoffeeSell.PresentationLayer;

namespace CoffeeSell
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            new TestForm().Show();
            guna2TextBox2.PasswordChar = '●';
            guna2TextBox2.UseSystemPasswordChar = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel9.MouseEnter += guna2HtmlLabel9_MouseEnter;
            guna2HtmlLabel9.MouseLeave += guna2HtmlLabel9_MouseLeave;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Account account = BOAccount.Login(guna2TextBox1.Text, guna2TextBox2.Text);
            if (account != null)
                MessageBox.Show("Đăng nhập thàn công");
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
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

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
                guna2TextBox2.PasswordChar = '\0'; // remove masking
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
                guna2TextBox2.PasswordChar = '●'; // or '*'
            }
        }
    }
}

