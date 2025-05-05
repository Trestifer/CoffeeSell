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
    //ghiiiiiiiiiiiiiiiiiiiiiiiii chuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu
    /// <summary>
    /// eqqweqweqweqweweq
    /// </summary>
    public partial class ResetMatKhau : Form
    {
        public ResetMatKhau()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhapOTP nhapotpForm = new NhapOTP();
            nhapotpForm.Show();
            this.Hide();
        }
    }
    
}
