namespace CoffeeSell.PresentationLayer
{
    partial class QuenMatKhau
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
            textBox2 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(46, 202);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(381, 29);
            textBox2.TabIndex = 14;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(46, 130);
            label1.Name = "label1";
            label1.Size = new Size(148, 28);
            label1.TabIndex = 15;
            label1.Text = "Tên đăng nhập";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 94, 165);
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(125, 278);
            button1.Name = "button1";
            button1.Size = new Size(202, 65);
            button1.TabIndex = 16;
            button1.Text = "XÁC NHẬN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 94, 165);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 72);
            panel1.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.White;
            label2.Location = new Point(125, 22);
            label2.Name = "label2";
            label2.Size = new Size(213, 31);
            label2.TabIndex = 18;
            label2.Text = "QUÊN MẬT KHẨU ";
            // 
            // QuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(465, 408);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "QuenMatKhau";
            Text = "QuenMatKhau";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private Label label1;
        private Button button1;
        private Panel panel1;
        private Label label2;
    }
}