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
            pictureBox1.Location = new Point(65, 116);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1104, 793);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // takePhotoButton
            // 
            takePhotoButton.Location = new Point(563, 933);
            takePhotoButton.Margin = new Padding(3, 4, 3, 4);
            takePhotoButton.Name = "takePhotoButton";
            takePhotoButton.Size = new Size(86, 33);
            takePhotoButton.TabIndex = 1;
            takePhotoButton.Text = "button1";
            takePhotoButton.UseVisualStyleBackColor = true;
            takePhotoButton.Click += takePhotoButton_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(401, 57);
            label1.Name = "label1";
            label1.Size = new Size(81, 35);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 1032);
            Controls.Add(label1);
            Controls.Add(takePhotoButton);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
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