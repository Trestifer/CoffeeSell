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
    public partial class KhuyenMaiSellect : Form
    {
        public DataTable ChoosenDiscount;

        public KhuyenMaiSellect(int CustomerId)
        {
            InitializeComponent();
            // Set the data source
            guna2DataGridView1.DataSource = BODiscount.GetDiscountForCustomer(CustomerId);

            // Set the data source

            // Prevent auto-generating all columns
            guna2DataGridView1.AutoGenerateColumns = false;
            guna2DataGridView1.Columns.Clear();

            // Add the checkbox column ("Chọn") — this is the only editable/selectable column
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Chọn";
            checkBoxColumn.Name = "Select";
            checkBoxColumn.ReadOnly = false; // allow editing
            guna2DataGridView1.Columns.Add(checkBoxColumn);

            // Add Discount Name column (read-only)
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Tên khuyến mãi";
            nameColumn.DataPropertyName = "NameDiscount"; // adjust if needed
            nameColumn.ReadOnly = true;
            guna2DataGridView1.Columns.Add(nameColumn);

            // Add Discount Percent column (read-only)
            DataGridViewTextBoxColumn percentColumn = new DataGridViewTextBoxColumn();
            percentColumn.HeaderText = "Giảm(%)";
            percentColumn.DataPropertyName = "DiscountPercent"; // adjust if needed
            percentColumn.ReadOnly = true;
            guna2DataGridView1.Columns.Add(percentColumn);

            // Optional: prevent selection highlight on read-only cells
            guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            guna2DataGridView1.ReadOnly = false; // must be false overall so the checkbox column is editable
            guna2DataGridView1.Columns[0].ReadOnly = false; // ensure checkbox column is editable
            guna2DataGridView1.AllowUserToAddRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the full data source (original DataTable)
            DataTable sourceTable = (DataTable)guna2DataGridView1.DataSource;

            // Clone the structure to hold selected rows
            ChoosenDiscount = sourceTable.Clone();

            // Loop through DataGridView rows
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                // Skip new row placeholder if it's visible
                if (row.IsNewRow) continue;

                // Check if checkbox is selected
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);

                if (isSelected)
                {
                    // Get the corresponding DataRowView
                    DataRowView dataRowView = row.DataBoundItem as DataRowView;

                    if (dataRowView != null)
                    {
                        ChoosenDiscount.ImportRow(dataRowView.Row);
                    }
                }
            }

            // Optionally close the dialog
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
