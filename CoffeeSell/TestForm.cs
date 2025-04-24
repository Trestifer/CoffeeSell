using CoffeeSell.DAO;
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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            Account managerAccount = new Account(
            accountId: 1,
            loginName: "trestifer",
            passwordHash: Security.HashPassword("Tam73105"),
            displayName: "Trestifer",
            typeAccount: true
            );
            DAOAccount acc = new DAOAccount();
            acc.CreateAccount( managerAccount );
            DataTable accList = acc.GetAllAccount();
            dtGridTest.DataSource = accList;
            dtGridTest.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
