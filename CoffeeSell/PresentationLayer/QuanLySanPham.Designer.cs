namespace CoffeeSell
{
    partial class QuanLySanPham
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dtgrid = new Guna.UI2.WinForms.Guna2DataGridView();
            textBox1 = new TextBox();
            comboBox3 = new ComboBox();
            button5 = new Button();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            label7 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtS = new TextBox();
            txtName = new TextBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            cbcDanhMuc = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            txtM = new TextBox();
            txtL = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgrid).BeginInit();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtgrid
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgrid.BackgroundColor = Color.Gray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgrid.ColumnHeadersHeight = 4;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgrid.DefaultCellStyle = dataGridViewCellStyle3;
            dtgrid.GridColor = Color.FromArgb(231, 229, 255);
            dtgrid.Location = new Point(27, 62);
            dtgrid.Margin = new Padding(3, 2, 3, 2);
            dtgrid.MultiSelect = false;
            dtgrid.Name = "dtgrid";
            dtgrid.ReadOnly = true;
            dtgrid.RowHeadersVisible = false;
            dtgrid.RowHeadersWidth = 51;
            dtgrid.RowTemplate.Height = 29;
            dtgrid.Size = new Size(663, 685);
            dtgrid.TabIndex = 0;
            dtgrid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            dtgrid.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgrid.ThemeStyle.BackColor = Color.Gray;
            dtgrid.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dtgrid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dtgrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgrid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dtgrid.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgrid.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgrid.ThemeStyle.HeaderStyle.Height = 4;
            dtgrid.ThemeStyle.ReadOnly = true;
            dtgrid.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtgrid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dtgrid.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dtgrid.ThemeStyle.RowsStyle.Height = 29;
            dtgrid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgrid.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgrid.CellClick += dtgrid_CellClick;
            dtgrid.CellContentClick += dtgrid_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 20);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm kiếm";
            textBox1.Size = new Size(292, 29);
            textBox1.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Mã SP", "Tên SP" });
            comboBox3.Location = new Point(348, 20);
            comboBox3.Margin = new Padding(3, 2, 3, 2);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(84, 23);
            comboBox3.TabIndex = 3;
            // 
            // button5
            // 
            button5.Location = new Point(476, 20);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(73, 28);
            button5.TabIndex = 4;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = true;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(label7);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges1;
            guna2CustomGradientPanel1.FillColor = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor3 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.Location = new Point(828, 0);
            guna2CustomGradientPanel1.Margin = new Padding(3, 2, 3, 2);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CustomGradientPanel1.Size = new Size(548, 41);
            guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(192, 7);
            label7.Name = "label7";
            label7.Size = new Size(166, 25);
            label7.TabIndex = 21;
            label7.Text = "Quản lý sản phẩm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 34);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Hình ảnh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 140);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 277);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 3;
            label4.Text = "Giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 348);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "Danh mục";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 390);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 5;
            // 
            // txtS
            // 
            txtS.Location = new Point(166, 274);
            txtS.Margin = new Padding(3, 2, 3, 2);
            txtS.Name = "txtS";
            txtS.Size = new Size(50, 23);
            txtS.TabIndex = 8;

            // 
            // txtName
            // 
            txtName.Location = new Point(166, 140);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(136, 23);
            txtName.TabIndex = 9;
            txtName.TextChanged += textBox4_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(166, 26);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(324, 26);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(72, 34);
            button1.TabIndex = 14;
            button1.Text = "Chọn ảnh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cbcDanhMuc
            // 
            cbcDanhMuc.FormattingEnabled = true;
            cbcDanhMuc.Location = new Point(164, 346);
            cbcDanhMuc.Margin = new Padding(3, 2, 3, 2);
            cbcDanhMuc.Name = "cbcDanhMuc";
            cbcDanhMuc.Size = new Size(139, 23);
            cbcDanhMuc.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(51, 458);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(94, 32);
            button2.TabIndex = 17;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(182, 458);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(94, 32);
            button3.TabIndex = 18;
            button3.Text = "Sửa ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(302, 458);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(94, 32);
            button4.TabIndex = 19;
            button4.Text = "Xóa";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtM);
            panel1.Controls.Add(txtL);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(cbcDanhMuc);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtS);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(828, 41);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(548, 706);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(146, 280);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 29;
            label11.Text = "S";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(228, 280);
            label10.Name = "label10";
            label10.Size = new Size(18, 15);
            label10.TabIndex = 28;
            label10.Text = "M";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(324, 280);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 27;
            label9.Text = "L";
            // 
            // txtM
            // 
            txtM.Location = new Point(252, 274);
            txtM.Margin = new Padding(3, 2, 3, 2);
            txtM.Name = "txtM";
            txtM.Size = new Size(50, 23);
            txtM.TabIndex = 25;
            // 
            // txtL
            // 
            txtL.Location = new Point(346, 274);
            txtL.Margin = new Padding(3, 2, 3, 2);
            txtL.Name = "txtL";
            txtL.Size = new Size(50, 23);
            txtL.TabIndex = 24;
            // 
            // QuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1487, 791);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(button5);
            Controls.Add(comboBox3);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(dtgrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QuanLySanPham";
            Text = "QuanLySanPham";
            ((System.ComponentModel.ISupportInitialize)dtgrid).EndInit();
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dtgrid;
        private TextBox textBox1;
        private ComboBox comboBox3;
        private Button button5;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Label label7;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtS;
        private TextBox txtName;
        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox cbcDanhMuc;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtM;
        private TextBox txtL;
    }
}