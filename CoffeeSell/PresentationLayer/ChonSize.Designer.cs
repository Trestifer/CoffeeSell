namespace CoffeeSell.PresentationLayer
{
    partial class ChonSize
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
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(94, 148, 255);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-6, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(428, 90);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(100, 28);
            label1.Name = "label1";
            label1.Size = new Size(233, 36);
            label1.TabIndex = 0;
            label1.Text = "Chọn Kích Thước";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            button1.Location = new Point(94, 104);
            button1.Name = "button1";
            button1.Size = new Size(214, 114);
            button1.TabIndex = 1;
            button1.Text = "Nhỏ";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            button2.Location = new Point(94, 245);
            button2.Name = "button2";
            button2.Size = new Size(214, 114);
            button2.TabIndex = 2;
            button2.Text = "Vừa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            button3.Location = new Point(94, 387);
            button3.Name = "button3";
            button3.Size = new Size(214, 114);
            button3.TabIndex = 3;
            button3.Text = "Lớn";
            button3.UseVisualStyleBackColor = true;
            // 
            // ChonSize
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 555);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "ChonSize";
            Text = "ChonSize";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}