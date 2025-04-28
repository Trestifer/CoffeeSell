using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell
{
    public partial class QuanLyNhanVien : Form
    {
        DataTable employeeDttb;
        int employeeID;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MinDate = new DateTime(DateTime.Now.Year - 50, 12, 31);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year - 16, 1, 1);
            Reset();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private Employee GetEmployeeInfo()
        {
            Employee employee = new Employee();
            employee.SetEmployeeId(employeeID);
            employee.SetNameEmployee(txtName.Text);
            employee.SetPhoneNumber(txtPhoneNumber.Text);
            employee.SetHomeAddress(txtAddress.Text);
            employee.SetGender(genderCheckBox.Checked);
            employee.SetDateOfBirth(dateTimePicker1.Value);
            return employee;
        }


        private void Reset()
        {
            employeeDttb = BOEmployee.GetAllEmployees();
            dtgridNhanVien.DataSource = employeeDttb;
            dtgridNhanVien.Show();
            genderCheckBox.Checked = true;
            txtAddress.Text = "";
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            employeeID = -1;

        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgridNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dtgridNhanVien.Rows[e.RowIndex];
                    int columnIndex = e.ColumnIndex;
                    employeeID = Convert.ToInt32(row.Cells["EmployeeId"].Value);
                    string employeeName = row.Cells["NameEmployee"].Value.ToString();
                    string phoneNumber = row.Cells["PhoneNumber"].Value.ToString();
                    string address = row.Cells["HomeAddress"].Value.ToString();
                    DateTime dob = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                    genderCheckBox.Checked = Convert.ToBoolean(row.Cells["Gender"].Value);
                    txtName.Text = employeeName;
                    txtPhoneNumber.Text = phoneNumber;
                    txtAddress.Text = address;
                    dateTimePicker1.Value = dob;

                }
                catch (Exception ex)
                {

                    Reset();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)// Cần check thông tin Employee trc khi thêm (Đã thêm thành công nhân viên ko họ ko tên ko mã tài khoản)
        {
            Employee newEmployee = GetEmployeeInfo();
            newEmployee.SetEmployeeId(0);
            BOEmployee.AddEmployee(newEmployee); // Trả về Boolean có thể thêm If để kt
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (employeeID != -1)
            {
                BOEmployee.DeleteEmployee(employeeID); // Trả về Boolean có thể thêm If để kt

            }
            MessageBox.Show(employeeID.ToString());
            Reset();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (employeeID != 1)
            {
                BOEmployee.EditEmployee(GetEmployeeInfo()); // Trả về Boolean có thể thêm If để kt
            }
            Reset();
        }

        private void genderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !genderCheckBox.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !genderCheckBox.Checked;
        }
    }
}