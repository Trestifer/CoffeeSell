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
    public partial class OptionForm : Form
    {

        public int option;
        public OptionForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            option = 0;
            this.DialogResult = DialogResult.OK;  // Close with OK status
            this.Close();  // Close the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            option = 1;
            this.DialogResult = DialogResult.OK;  // Close with OK status
            this.Close();  // Close the form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            option = 7;
            this.DialogResult = DialogResult.OK;  // Close with OK status
            this.Close();  // Close the form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            option = 30;
            this.DialogResult = DialogResult.OK;  // Close with OK status
            this.Close();  // Close the form
        }
    }
}
