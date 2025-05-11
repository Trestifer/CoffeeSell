namespace CoffeeSell
{
    partial class DoiMatKhau
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.White;
            label1.Location = new Point(155, 31);
            label1.Name = "label1";
            label1.Size = new Size(242, 41);
            label1.TabIndex = 1;
            label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 177);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(444, 40);
            textBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(37, 137);
            label2.Name = "label2";
            label2.Size = new Size(139, 28);
            label2.TabIndex = 12;
            label2.Text = "Mật khẩu mới";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 94, 165);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-5, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(526, 105);
            panel1.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(34, 288);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(444, 40);
            textBox2.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(37, 248);
            label3.Name = "label3";
            label3.Size = new Size(179, 28);
            label3.TabIndex = 16;
            label3.Text = "Nhập lại mật khẩu";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 94, 165);
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.White;
            button1.Location = new Point(151, 360);
            button1.Name = "button1";
            button1.Size = new Size(208, 61);
            button1.TabIndex = 14;
            button1.Text = "XÁC NHẬN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(512, 451);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "DoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DoiMatKhau";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
    }
}