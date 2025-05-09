using CoffeeSell.BO;
using Guna.UI2.WinForms;
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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            guna2DataGridView2.DataSource = BOLoginHistory.GetSpecialLoginHistory();
            // Set Vietnamese column headers
            guna2DataGridView2.Columns["LoginHistoryId"].HeaderText = "Mã";
            guna2DataGridView2.Columns["LoginName"].HeaderText = "Tên đăng nhập";
            guna2DataGridView2.Columns["LoginTime"].HeaderText = "Thời gian đăng nhập";
            guna2DataGridView2.Columns["LogoutTime"].HeaderText = "Thời gian đăng xuất";
            guna2DataGridView2.Columns["SuccessfulLogin"].HeaderText = "Đăng nhập thành công";

            // Set fixed header height
            guna2DataGridView2.ColumnHeadersHeight = 40;
            guna2DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Prevent resizing and editing
            guna2DataGridView2.AllowUserToResizeColumns = false;
            guna2DataGridView2.AllowUserToResizeRows = false;
            guna2DataGridView2.ReadOnly = true;
            guna2DataGridView2.RowHeadersVisible = false;

            // Optional: set column auto size mode if needed
            guna2DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            guna2DataGridView2.Show();
            DataTable dt = BOActivityLog.GetActivityLog();

            // Add ActionText column
            if (!dt.Columns.Contains("ActionText"))
            {
                dt.Columns.Add("ActionText", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string code = row["ActionName"].ToString();
                    row["ActionText"] = code switch
                    {
                        "D" => "Xóa",
                        "E" => "Sửa",
                        "S" => "Bán hàng",
                        "A" => "Thêm",
                        _ => "Không rõ"
                    };
                }
            }

            // Set DataSource
            guna2DataGridView1.DataSource = dt;

            // Hide original ActionName
            guna2DataGridView1.Columns["ActionName"].Visible = false;

            // Add ActionText column if not bound properly
            if (!guna2DataGridView1.Columns.Contains("ActionText"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "ActionText",
                    HeaderText = "Hành động",
                    DataPropertyName = "ActionText",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    ReadOnly = true
                };
                guna2DataGridView1.Columns.Insert(2, col);
            }

            // Lock resizing
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.ColumnHeadersHeight = 35;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Fixed column widths
            void SetColWidth(string name, int width)
            {
                if (guna2DataGridView1.Columns.Contains(name))
                {
                    var col = guna2DataGridView1.Columns[name];
                    col.Width = width;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    col.Resizable = DataGridViewTriState.False;
                }
            }

            guna2DataGridView1.DataSource = dt;

            // Ensure the ActionText column is shown
            if (guna2DataGridView1.Columns.Contains("ActionText"))
            {
                guna2DataGridView1.Columns["ActionText"].Visible = true;
                guna2DataGridView1.Columns["ActionText"].DisplayIndex = 2; // put it after LoginName
            }
            SetColWidth("ActivityId", 50);
            SetColWidth("LoginName", 100);
            SetColWidth("ActionText", 90);
            SetColWidth("TimeRecord", 150);
            SetColWidth("Detail", 600);
            guna2DataGridView1.Columns["ActivityId"].HeaderText = "Mã";
            guna2DataGridView1.Columns["LoginName"].HeaderText = "Người dùng";
            guna2DataGridView1.Columns["ActionText"].HeaderText = "Hành động";
            guna2DataGridView1.Columns["TimeRecord"].HeaderText = "Thời gian";
            guna2DataGridView1.Columns["Detail"].HeaderText = "Chi tiết";
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
