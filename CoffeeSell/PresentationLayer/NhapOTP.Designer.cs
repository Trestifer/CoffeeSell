namespace CoffeeSell
{
    partial class NhapOTP
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
            components = new System.ComponentModel.Container();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 94, 165);
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.ForeColor = Color.White;
            button2.Location = new Point(237, 318);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(181, 46);
            button2.TabIndex = 10;
            button2.Text = "XÁC NHẬN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 94, 165);
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.White;
            button1.Location = new Point(27, 318);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(182, 46);
            button1.TabIndex = 9;
            button1.Text = "GỬI YÊU CẦU";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 261);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(389, 31);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(27, 226);
            label2.Name = "label2";
            label2.Size = new Size(184, 21);
            label2.TabIndex = 7;
            label2.Text = "Nhập Mã OTP (6 chữ số)";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 94, 165);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-3, -1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(445, 74);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.White;
            label1.Location = new Point(121, 21);
            label1.Name = "label1";
            label1.Size = new Size(183, 32);
            label1.TabIndex = 1;
            label1.Text = "NHẬP MÃ OTP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(-200, 94);
            label3.Name = "label3";
            label3.Size = new Size(0, 21);
            label3.TabIndex = 11;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AllowDrop = true;
            label4.BackColor = Color.WhiteSmoke;
            label4.Location = new Point(30, 92);
            label4.Name = "label4";
            label4.Size = new Size(388, 40);
            label4.TabIndex = 12;
            label4.Text = "Chúng tôi đã gửi đến bạn 1 mã xác thực gồm 6 chữ số. Vui lòng kiểm tra email của bạn.";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 181);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(389, 31);
            textBox2.TabIndex = 13;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(27, 158);
            label5.Name = "label5";
            label5.Size = new Size(48, 21);
            label5.TabIndex = 14;
            label5.Text = "Email";
            label5.Click += label5_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // NhapOTP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(444, 409);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NhapOTP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NhapOTP";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}