namespace CoffeeSell.PresentationLayer
{
    partial class CameraForm
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
            pictureBox1 = new PictureBox();
            takePhotoButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(57, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(966, 595);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // takePhotoButton
            // 
            takePhotoButton.Location = new Point(493, 700);
            takePhotoButton.Name = "takePhotoButton";
            takePhotoButton.Size = new Size(75, 25);
            takePhotoButton.TabIndex = 1;
            takePhotoButton.Text = "button1";
            takePhotoButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(351, 43);
            label1.Name = "label1";
            label1.Size = new Size(65, 28);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 774);
            Controls.Add(label1);
            Controls.Add(takePhotoButton);
            Controls.Add(pictureBox1);
            Name = "CameraForm";
            Text = "CameraForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button takePhotoButton;
        private Label label1;
    }
}