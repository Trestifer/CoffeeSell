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
        Account user;
        public QuanLyNhanVien(Account _user)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MinDate = new DateTime(DateTime.Now.Year - 50, 12, 31);
            dateTimePicker1.MaxDate = new DateTime(DateTime.Now.Year - 16, 1, 1);
            user = _user;
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
            // Set the data source
            employeeDttb = BOEmployee.SpeccialDataTable();

            if (employeeDttb == null)
            {
                MessageBox.Show("Failed to load employee data.");
                return;
            }

            // Add "Giới tính" column with translated values
            if (!employeeDttb.Columns.Contains("GioiTinhText"))
            {
                employeeDttb.Columns.Add("GioiTinhText", typeof(string));
                foreach (DataRow row in employeeDttb.Rows)
                {
                    bool gender = Convert.ToBoolean(row["Gender"]);
                    row["GioiTinhText"] = gender ? "Nam" : "Nữ";
                }
            }

            // Bind data
            if (dtgridNhanVien == null)
            {
                MessageBox.Show("Guna2DataGridView is not initialized.");
                return;
            }

            dtgridNhanVien.DataSource = employeeDttb;

            // Enable column resizing
            dtgridNhanVien.AllowUserToResizeColumns = true;
            dtgridNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;  // Automatically adjust column width

            // Hide all columns first
            foreach (DataGridViewColumn col in dtgridNhanVien.Columns)
            {
                col.Visible = false;
            }

            // Show and rename only desired columns, set custom widths
            if (employeeDttb.Columns.Contains("EmployeeId"))
            {
                dtgridNhanVien.Columns["EmployeeId"].Visible = true;
                dtgridNhanVien.Columns["EmployeeId"].MinimumWidth = 150;
                dtgridNhanVien.Columns["EmployeeId"].HeaderText = "Mã nhân viên";
            }

            if (employeeDttb.Columns.Contains("NameEmployee"))
            {
                dtgridNhanVien.Columns["NameEmployee"].Visible = true;
                dtgridNhanVien.Columns["NameEmployee"].MinimumWidth = 250;
                dtgridNhanVien.Columns["NameEmployee"].HeaderText = "Tên nhân viên";
            }

            if (employeeDttb.Columns.Contains("GioiTinhText"))
            {
                dtgridNhanVien.Columns["GioiTinhText"].Visible = true;
                dtgridNhanVien.Columns["GioiTinhText"].MinimumWidth = 100;
                dtgridNhanVien.Columns["GioiTinhText"].HeaderText = "Giới tính";
            }

            if (employeeDttb.Columns.Contains("DateOfBirth"))
            {
                dtgridNhanVien.Columns["DateOfBirth"].Visible = true;
                dtgridNhanVien.Columns["DateOfBirth"].MinimumWidth = 150;
                dtgridNhanVien.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            }

            if (employeeDttb.Columns.Contains("LoginName"))
            {
                dtgridNhanVien.Columns["LoginName"].Visible = true;
                dtgridNhanVien.Columns["LoginName"].MinimumWidth = 220;
                dtgridNhanVien.Columns["LoginName"].HeaderText = "Tên đăng nhập";
            }

            if (employeeDttb.Columns.Contains("Email"))
            {
                dtgridNhanVien.Columns["Email"].Visible = true;
                dtgridNhanVien.Columns["Email"].MinimumWidth = 270;
                dtgridNhanVien.Columns["Email"].HeaderText = "Email";
            }

            if (employeeDttb.Columns.Contains("HomeAddress"))
            {
                dtgridNhanVien.Columns["HomeAddress"].Visible = true;
                dtgridNhanVien.Columns["HomeAddress"].MinimumWidth = 270;
                dtgridNhanVien.Columns["HomeAddress"].HeaderText = "Địa chỉ";
            }

            // Set header height
            dtgridNhanVien.ColumnHeadersHeight = 40;
            dtgridNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

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
            if (BOEmployee.AddEmployee(newEmployee))
            {
                MessageBox.Show("Thêm thành công");
                BOActivityLog.Record(user.GetLoginName(), 'A', $"Đã thêm nhân viên {newEmployee.GetNameEmployee()}");
            }
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (employeeID != -1)
            {
                if (BOEmployee.DeleteEmployee(employeeID))
                {
                    MessageBox.Show("Xoá thành công");

                    BOActivityLog.Record(user.GetLoginName(), 'D', $"Đã xóa nhân viên có mã {employeeID}");

                }

            }
            Reset();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (employeeID != 1)
            {
                if (BOEmployee.EditEmployee(GetEmployeeInfo()))
                {
                    MessageBox.Show("Sửa thành công");
                    BOActivityLog.Record(user.GetLoginName(), 'E', $"Đã sửa nhân viên có mã {employeeID}");

                }// Trả về Boolean có thể thêm If để kt
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