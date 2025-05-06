namespace CoffeeSell
{

    partial class QuanLyNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button5 = new Button();
            btnDelete = new Button();
            btnedit = new Button();
            btnAdd = new Button();
            panel2 = new Panel();
            label8 = new Label();
            txtAddress = new TextBox();
            txtPhoneNumber = new TextBox();
            txtName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label7 = new Label();
            dtgridNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            genderCheckBox = new CheckBox();
            checkBox2 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgridNhanVien).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(1292, 143);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(60, 26);
            button5.TabIndex = 40;
            button5.Text = "Làm mới";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1211, 143);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(60, 26);
            btnDelete.TabIndex = 39;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(1292, 91);
            btnedit.Margin = new Padding(3, 2, 3, 2);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(60, 26);
            btnedit.TabIndex = 38;
            btnedit.Text = "Sửa";
            btnedit.UseVisualStyleBackColor = true;
            btnedit.Click += btnedit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1211, 91);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(60, 26);
            btnAdd.TabIndex = 37;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Controls.Add(label8);
            panel2.Location = new Point(-25, 211);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1614, 45);
            panel2.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 15);
            label8.Name = "label8";
            label8.Size = new Size(117, 15);
            label8.TabIndex = 21;
            label8.Text = "Danh sách nhân viên";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(242, 112);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(157, 23);
            txtAddress.TabIndex = 33;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(588, 67);
            txtPhoneNumber.Margin = new Padding(3, 2, 3, 2);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(165, 23);
            txtPhoneNumber.TabIndex = 32;
            // 
            // txtName
            // 
            txtName.Location = new Point(242, 67);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(157, 23);
            txtName.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(500, 123);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 29;
            label5.Text = "Ngày sinh";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(533, 75);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 28;
            label4.Text = "SDT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(181, 162);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 27;
            label3.Text = "Giới tính";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 118);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 26;
            label2.Text = "Địa chỉ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 75);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 24;
            label1.Text = "Họ tên";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label7);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1614, 48);
            panel1.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(59, 14);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 20;
            label7.Text = "Nhân viên";
            label7.Click += label7_Click;
            // 
            // dtgridNhanVien
            // 
            dtgridNhanVien.AllowUserToAddRows = false;
            dtgridNhanVien.AllowUserToDeleteRows = false;
            dtgridNhanVien.AllowUserToResizeColumns = false;
            dtgridNhanVien.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgridNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgridNhanVien.BackgroundColor = Color.WhiteSmoke;
            dtgridNhanVien.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgridNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgridNhanVien.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgridNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dtgridNhanVien.GridColor = Color.FromArgb(231, 229, 255);
            dtgridNhanVien.Location = new Point(45, 305);
            dtgridNhanVien.Margin = new Padding(3, 2, 3, 2);
            dtgridNhanVien.MultiSelect = false;
            dtgridNhanVien.Name = "dtgridNhanVien";
            dtgridNhanVien.ReadOnly = true;
            dtgridNhanVien.RowHeadersVisible = false;
            dtgridNhanVien.RowHeadersWidth = 51;
            dtgridNhanVien.RowTemplate.Height = 29;
            dtgridNhanVien.Size = new Size(1507, 295);
            dtgridNhanVien.TabIndex = 22;
            dtgridNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgridNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgridNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgridNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgridNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgridNhanVien.ThemeStyle.BackColor = Color.WhiteSmoke;
            dtgridNhanVien.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgridNhanVien.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dtgridNhanVien.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgridNhanVien.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dtgridNhanVien.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgridNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgridNhanVien.ThemeStyle.HeaderStyle.Height = 4;
            dtgridNhanVien.ThemeStyle.ReadOnly = true;
            dtgridNhanVien.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgridNhanVien.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgridNhanVien.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dtgridNhanVien.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgridNhanVien.ThemeStyle.RowsStyle.Height = 29;
            dtgridNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgridNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgridNhanVien.CellClick += dtgridNhanVien_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(315, 278);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(84, 20);
            button1.TabIndex = 21;
            button1.Text = "tìm kiếm";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(45, 275);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 20;
            // 
            // genderCheckBox
            // 
            genderCheckBox.AutoSize = true;
            genderCheckBox.Location = new Point(242, 161);
            genderCheckBox.Name = "genderCheckBox";
            genderCheckBox.Size = new Size(52, 19);
            genderCheckBox.TabIndex = 41;
            genderCheckBox.Text = "Nam";
            genderCheckBox.UseVisualStyleBackColor = true;
            genderCheckBox.CheckedChanged += genderCheckBox_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(315, 162);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(42, 19);
            checkBox2.TabIndex = 42;
            checkBox2.Text = "Nữ";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(588, 118);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 43;
            // 
            // QuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1606, 625);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBox2);
            Controls.Add(genderCheckBox);
            Controls.Add(button5);
            Controls.Add(btnDelete);
            Controls.Add(btnedit);
            Controls.Add(btnAdd);
            Controls.Add(panel2);
            Controls.Add(txtAddress);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(dtgridNhanVien);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QuanLyNhanVien";
            Text = "QuanLyNhanVien";
            Load += QuanLyNhanVien_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgridNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button btnDelete;
        private Button btnedit;
        private Button btnAdd;
        private Panel panel2;
        private Label label8;
        private TextBox textBox7;
        private TextBox txtAddress;
        private TextBox txtPhoneNumber;
        private TextBox txtName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Label label7;
        private Guna.UI2.WinForms.Guna2DataGridView dtgridNhanVien;
        private Button button1;
        private TextBox textBox1;
        private CheckBox genderCheckBox;
        private CheckBox checkBox2;
        private DateTimePicker dateTimePicker1;
    }
}