namespace CoffeeSell.PresentationLayer
{
    partial class ThoiTienForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblTienThoi = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(267, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(179, 41);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 1;
            label1.Text = "Tiền khách đưa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(116, 145);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 2;
            label2.Text = "Tiền thói: ";
            // 
            // lblTienThoi
            // 
            lblTienThoi.AutoSize = true;
            lblTienThoi.Location = new Point(214, 145);
            lblTienThoi.Name = "lblTienThoi";
            lblTienThoi.Size = new Size(74, 20);
            lblTienThoi.TabIndex = 3;
            lblTienThoi.Text = "Tiền thói: ";
            // 
            // button1
            // 
            button1.Location = new Point(179, 251);
            button1.Name = "button1";
            button1.Size = new Size(109, 33);
            button1.TabIndex = 4;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            // 
            // ThoiTienForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 315);
            Controls.Add(button1);
            Controls.Add(lblTienThoi);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "ThoiTienForm";
            Text = "ThoiTienForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label lblTienThoi;
        private Button button1;
    }
}