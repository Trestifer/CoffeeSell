using CoffeeSell.BO;
using CoffeeSell.ObjClass;
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
    public partial class DoiMatKhau : Form
    {
        private Account user;
        public DoiMatKhau(Account _user)
        {
            InitializeComponent();
            user = _user;
            textBox1.PasswordChar = '●';
            textBox2.PasswordChar = '●';
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if both password and confirm password fields are not empty
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không được để trống");
                return; // Stop further execution if any field is empty
            }
            if (textBox1.Text == textBox2.Text)
            {
                user.SetPasswordHash(textBox1.Text);
                if (BOAccount.UpdateAccount(user))
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công");
                    this.Close();
                    new Login().Show();
                }
                else
                {
                    MessageBox.Show("Hệ thống gặp sự cố");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng");
             
            }
            textBox2.Text = "";
        }
    }
}
