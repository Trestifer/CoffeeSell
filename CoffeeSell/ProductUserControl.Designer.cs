namespace CoffeeSell
{
    partial class ProductUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductUserControl));
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel1 = new Panel();
            lblPrice = new Label();
            lblProductName = new Label();
            picProductImage = new PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(panel1);
            guna2ShadowPanel1.Controls.Add(picProductImage);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(3, 3);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(259, 243);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblProductName);
            panel1.Location = new Point(3, 157);
            panel1.Name = "panel1";
            panel1.Size = new Size(253, 83);
            panel1.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPrice.Location = new Point(20, 45);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 23);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Giá";
            
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblProductName.Location = new Point(20, 13);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(58, 23);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Tên sp";
            // 
            // picProductImage
            // 
            picProductImage.Image = (Image)resources.GetObject("picProductImage.Image");
            picProductImage.Location = new Point(3, 3);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(253, 148);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 0;
            picProductImage.TabStop = false;
            picProductImage.Click += pictureBox1_Click;
            // 
            // ProductUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Name = "ProductUserControl";
            Size = new Size(265, 246);
            guna2ShadowPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Panel panel1;
        private PictureBox picProductImage;
        private Label lblPrice;
        private Label lblProductName;
    }
}
