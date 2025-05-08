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
            if(acc.GetTypeAccount()||!BOEmployee.CheckFirstLogin(acc.GetAccountId()))
            {
                MessageBox.Show("Có lỗi diễn ra lêu lêu");
                return;
            }
            new NhapOTP(acc).Show();
            this.Close();
        }
    }
}
