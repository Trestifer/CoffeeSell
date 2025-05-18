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

namespace CoffeeSell.PresentationLayer
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account acc  = BOAccount.GetAccount(textBox2.Text);
            if (acc == null)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }
            if(acc.GetTypeAccount())
            {
                MessageBox.Show("Mật khẩu của quản lý không thể bị đổi ở mục này. Vui lòng liên hệ nhà phát triển để được hỗ trợ");
                return;
            }
            else if(!BOEmployee.CheckFirstLogin(acc.GetAccountId()))
            {
                MessageBox.Show("Mật khẩu mặc định cho nhân viên mới: changeme");
                return;
            }
            new NhapOTP(acc).Show();
            this.Close();
        }
    }
}
