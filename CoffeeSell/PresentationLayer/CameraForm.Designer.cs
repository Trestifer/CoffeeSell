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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(46, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(966, 595);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // takePhotoButton
            // 
            takePhotoButton.Location = new Point(493, 686);
            takePhotoButton.Name = "takePhotoButton";
            takePhotoButton.Size = new Size(75, 25);
            takePhotoButton.TabIndex = 1;
            takePhotoButton.Text = "button1";
            takePhotoButton.UseVisualStyleBackColor = true;
            // 
            // CameraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 774);
            Controls.Add(takePhotoButton);
            Controls.Add(pictureBox1);
            Name = "CameraForm";
            Text = "CameraForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button takePhotoButton;
    }
}