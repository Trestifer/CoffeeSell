using CoffeeSell.BO;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            guna2DataGridView2.DataSource = BOLoginHistory.GetAllLoginHistory();
            guna2DataGridView2.Show();
            guna2DataGridView1.DataSource = BOActivityLog.GetActivityLog();
            guna2DataGridView1.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
