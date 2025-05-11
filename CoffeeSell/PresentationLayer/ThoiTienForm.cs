using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell.PresentationLayer
{
    public partial class ThoiTienForm : Form
    {
        public decimal TienDua = 0;
        private decimal Tien;
        public ThoiTienForm(decimal tien)
        {
            InitializeComponent();
            Tien = tien;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TienDua = decimal.Parse(txt.Text);
                decimal tienThoi = TienDua - Tien;
                if (tienThoi < 0)
                    lblTienThoi.Text = "";
                else
                    lblTienThoi.Text = tienThoi.ToString("N0");
            }
            catch
            {
                txt.Text = "";
                TienDua = 0;
                lblTienThoi.Text = 0.ToString("N0");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TienDua<Tien)
            {
                MessageBox.Show("Không đủ tiền");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Hợp lệ");
                this.Close();
            }
        }
    }
}
