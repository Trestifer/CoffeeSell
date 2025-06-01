using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using Microsoft.Win32;
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
        string trusecurity;
        int countdown;
        EmailSecurity security;

        public NhapOTP(Account _user)
        {
            user = _user;
            InitializeComponent();

            if(!user.GetTypeAccount())
            {
                security = BOEmployeeEmail.Get(user.GetAccountId());
            }
            else
            {
                security = BOEmailSecurity.Get(user.GetLoginName()); 
            }

            if (security.GetEmail() != null)
                textBox2.Text = security.GetEmail();

            button2.Enabled = false;

            if (security.GetIsConfirmed())
            {
                trusecurity = textBox2.Text;
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
                trusecurity = email;
            if (Security.SendOtpEmail(trusecurity, newOTP))
            {
                MessageBox.Show("Đã gửi mã OTP");
                if (!textBox2.ReadOnly)
                { security.SetEmail(trusecurity); }
                security.SetCurrentOTP(newOTP);
                security.SetOTPExpired(DateTime.Now.AddMinutes(2));
                BOEmailSecurity.Update(security);
                //////////////////////
                //BOEmployesecurity.UpdateEmployesecurity(security);
                /////////////////////
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
            string otp = textBox1.Text.Trim();

            // Kiểm tra OTP có bị trống không
            if (string.IsNullOrEmpty(otp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra OTP phải là 6 chữ số
            if (!System.Text.RegularExpressions.Regex.IsMatch(otp, @"^\d{6}$"))
            {
                MessageBox.Show("Mã OTP phải gồm đúng 6 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTime.Now < security.GetOTPExpired())
            {
                if (textBox1.Text == security.GetCurrentOTP())
                {
                    if (!textBox2.ReadOnly)
                    {
                        security.SetIsConfirmed(true);
                        BOEmailSecurity.Update(security);
                        //BOEmployesecurity.UpdateEmployesecurity(security);
                        MessageBox.Show("Cập nhật Email thành công");
                    }
                    new DoiMatKhau(user).Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Mã OTP không đúng. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                security.SetCurrentOTP("");
                BOEmailSecurity.Update(security);
                //BOEmployesecurity.UpdateEmployesecurity(security);
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
