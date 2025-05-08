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
    public partial class NhapOTP : Form
    {
        Account user;
        EmployeeEmail Eemail;
        string trueEmail;
        int countdown;
        public NhapOTP(Account _user)
        {
            InitializeComponent();
            user = _user;
            Eemail = BOEmployee.GetEmployeeEmail(user.GetAccountId());
            
            if (Eemail.GetEmail() != null)
                textBox2.Text = Eemail.GetEmail();
            button2.Enabled = false;
            if (Eemail.GetIsConfirmed())
            {
                trueEmail = textBox2.Text;
                textBox2.Text = MaskEmail(textBox2.Text);
                textBox2.ReadOnly = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                button2.Enabled = true;
            else
                button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newOTP = Security.GenerateOTP();
            string email = textBox2.Text;
            if(!textBox2.ReadOnly)
                trueEmail = email;
            if (Security.SendOtpEmail(trueEmail, newOTP))
            {
                MessageBox.Show("Đã gửi mã OTP");
                if (!textBox2.ReadOnly)
                { Eemail.SetEmail(trueEmail); }
                Eemail.SetCurrentOTP(newOTP);
                Eemail.SetOTPExpired(DateTime.Now.AddMinutes(2));
                BOEmployeeEmail.UpdateEmployeeEmail(Eemail);
                countdown = 120;
                button1.Text = $"{countdown}s";
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Hệ thống gặp lỗi, vui lòng thử lại sau");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (DateTime.Now < Eemail.GetOTPExpired())
            {
                if (textBox1.Text == Eemail.GetCurrentOTP())
                {
                    if (!textBox2.ReadOnly)
                    {
                        Eemail.SetIsConfirmed(true);
                        BOEmployeeEmail.UpdateEmployeeEmail(Eemail);
                        MessageBox.Show("Cập nhật Email thành công");
                    }
                    new DoiMatKhau(user).Show();
                    this.Close();

                }
            }
            else
            {
                Eemail.SetCurrentOTP("");
                BOEmployeeEmail.UpdateEmployeeEmail(Eemail);
                MessageBox.Show("Mã đã hết hạn");
            }
        }
        private string MaskEmail(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex <= 2)
                return email; // too short to mask, return as-is

            string username = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex);

            string masked = username.Substring(0, 2) + "*****" + username[^1] + domain;
            return masked;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            countdown--;
            if (countdown > 0)
            {
                button1.Text = $"{countdown}s";
            }
            else
            {
                timer1.Stop();
                button1.Text = "GỬI LẠI";
                button1.Enabled = true;
            }
        }
    }

}
