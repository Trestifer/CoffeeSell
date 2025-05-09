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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            panelcontent = new Panel();
            ((System.ComponentModel.ISupportInitialize)dtgrid).BeginInit();
            guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtgrid
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dtgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dtgrid.BackgroundColor = Color.Gray;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtgrid.ColumnHeadersHeight = 4;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dtgrid.DefaultCellStyle = dataGridViewCellStyle6;
            dtgrid.GridColor = Color.FromArgb(231, 229, 255);
            dtgrid.Location = new Point(31, 83);
            dtgrid.MultiSelect = false;
            dtgrid.Name = "dtgrid";
            dtgrid.ReadOnly = true;
            dtgrid.RowHeadersVisible = false;
            dtgrid.RowHeadersWidth = 51;
            dtgrid.Size = new Size(758, 913);
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
            textBox1.Location = new Point(31, 27);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Tìm kiếm";
            textBox1.Size = new Size(333, 37);
            textBox1.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Mã SP", "Tên SP" });
            comboBox3.Location = new Point(398, 27);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(95, 28);
            comboBox3.TabIndex = 3;
            // 
            // button5
            // 
            button5.Location = new Point(544, 27);
            button5.Name = "button5";
            button5.Size = new Size(83, 37);
            button5.TabIndex = 4;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = true;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(label7);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.FillColor = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor3 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.FillColor4 = Color.FromArgb(84, 125, 224);
            guna2CustomGradientPanel1.Location = new Point(801, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel1.Size = new Size(771, 64);
            guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(288, 9);
            label7.Name = "label7";
            label7.Size = new Size(199, 31);
            label7.TabIndex = 21;
            label7.Text = "Quản lý sản phẩm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 45);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Hình ảnh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 187);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(385, 122);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 3;
            label4.Text = "Giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 286);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 4;
            label5.Text = "Danh mục";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 342);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 5;
            // 
            // txtS
            // 
            txtS.Location = new Point(408, 187);
            txtS.Name = "txtS";
            txtS.Size = new Size(57, 27);
            txtS.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(190, 187);
            txtName.Name = "txtName";
            txtName.Size = new Size(155, 27);
            txtName.TabIndex = 9;
            txtName.TextChanged += textBox4_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(190, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(370, 35);
            button1.Name = "button1";
            button1.Size = new Size(82, 45);
            button1.TabIndex = 14;
            button1.Text = "Chọn ảnh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cbcDanhMuc
            // 
            cbcDanhMuc.FormattingEnabled = true;
            cbcDanhMuc.Location = new Point(187, 283);
            cbcDanhMuc.Name = "cbcDanhMuc";
            cbcDanhMuc.Size = new Size(158, 28);
            cbcDanhMuc.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(362, 331);
            button2.Name = "button2";
            button2.Size = new Size(107, 43);
            button2.TabIndex = 17;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(512, 331);
            button3.Name = "button3";
            button3.Size = new Size(107, 43);
            button3.TabIndex = 18;
            button3.Text = "Sửa ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(649, 331);
            button4.Name = "button4";
            button4.Size = new Size(107, 43);
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
            panel1.Location = new Point(801, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(771, 395);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(385, 195);
            label11.Name = "label11";
            label11.Size = new Size(17, 20);
            label11.TabIndex = 29;
            label11.Text = "S";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(479, 195);
            label10.Name = "label10";
            label10.Size = new Size(22, 20);
            label10.TabIndex = 28;
            label10.Text = "M";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(588, 195);
            label9.Name = "label9";
            label9.Size = new Size(16, 20);
            label9.TabIndex = 27;
            label9.Text = "L";
            // 
            // txtM
            // 
            txtM.Location = new Point(506, 187);
            txtM.Name = "txtM";
            txtM.Size = new Size(57, 27);
            txtM.TabIndex = 25;
            // 
            // txtL
            // 
            txtL.Location = new Point(613, 187);
            txtL.Name = "txtL";
            txtL.Size = new Size(57, 27);
            txtL.TabIndex = 24;
            // 
            // panelcontent
            // 
            panelcontent.Location = new Point(801, 456);
            panelcontent.Name = "panelcontent";
            panelcontent.Size = new Size(771, 439);
            panelcontent.TabIndex = 6;
            panelcontent.Paint += panelcontent_Paint;
            // 
            // QuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1699, 1055);
            Controls.Add(panelcontent);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(button5);
            Controls.Add(comboBox3);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(dtgrid);
            Name = "QuanLySanPham";
            Text = "QuanLySanPham";
            Load += QuanLySanPham_Load;
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
        private Panel panelcontent;
    }
}