
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
            guna2TextBox2.PasswordChar = '●';
            guna2TextBox2.UseSystemPasswordChar = true;
            guna2TextBox1.TabIndex = 0;
            guna2TextBox2.TabIndex = 1;
            guna2Button1.TabIndex = 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel9.MouseEnter += guna2HtmlLabel9_MouseEnter;
            guna2HtmlLabel9.MouseLeave += guna2HtmlLabel9_MouseLeave;
            guna2TextBox1.Focus();
            guna2TextBox1.Select();
            guna2TextBox2.KeyDown += TextBoxes_KeyDown;
            guna2TextBox1.KeyDown += TextBoxes_KeyDown;
        }
        private void TextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox currentBox = sender as TextBox;
                guna2Button1_Click(null, EventArgs.Empty);
                e.SuppressKeyPress = true;
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Account account = BOAccount.Login(guna2TextBox1.Text, guna2TextBox2.Text);
            if (account != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                BOLoginHistory.SuccessLogin(account.GetAccountId());
                this.Hide();
                if (!account.GetTypeAccount())
                {
                    if (!BOEmployee.CheckFirstLogin(account.GetAccountId()))
                    {
                        new NhapOTP(account).Show();
                        return;
                    }
                }
                else if (BOManagerSecurity.Get(account.GetLoginName()) == null)
                {
                    ManagerSecurity manager = BOManagerSecurity.Add(account.GetLoginName());
                    CameraForm cameraForm = new CameraForm(account);
                    cameraForm.Show();
                    return;
                }
                else if (BOManagerSecurity.Get(account.GetLoginName()).GetEncodingFace() == "")
                {
                    CameraForm cameraForm = new CameraForm(account);
                    cameraForm.Show();
                    return;
                }
                else if(account.GetTypeAccount())
                {
                    new CameraForm(account,true).Show();
                    return;
                }

                TrangChu trangChuForm = new TrangChu(account);
                trangChuForm.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
                BOLoginHistory.FailureLogin(guna2TextBox1.Text);
                guna2TextBox2.Text = string.Empty;
            }

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {
            new QuenMatKhau().Show();
            this.Hide();
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

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

