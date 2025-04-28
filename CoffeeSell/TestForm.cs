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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            var employee = new Employee(
            employeeId: 0,  // 0 if it's auto-incremented by DB
            nameEmployee: "Nguyen Van A",
            dateOfBirth: new DateTime(1995, 5, 20),
            gender: false,  // false = Male
            homeAddress: "123 Nguyen Trai, Ha Noi",
            phoneNumber: "0123456789",
            accountId: 0
            );
            BOEmployee.AddEmployee(employee);
            dtgridTest.DataSource = BOEmployee.GetAllEmployees();
            Console.WriteLine(111111111111111111);
            dtgridTest.Show();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void dtgridTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
