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
            pbPriceL = new PictureBox();
            pbPriceM = new PictureBox();
            pbPriceS = new PictureBox();
            lblPriceL = new Label();
            lblPriceM = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblPriceS = new Label();
            lblProductName = new Label();
            picProductImage = new PictureBox();
            guna2ShadowPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPriceL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPriceM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPriceS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(panel1);
            guna2ShadowPanel1.Controls.Add(picProductImage);
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 3);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(261, 333);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(pbPriceL);
            panel1.Controls.Add(pbPriceM);
            panel1.Controls.Add(pbPriceS);
            panel1.Controls.Add(lblPriceL);
            panel1.Controls.Add(lblPriceM);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblPriceS);
            panel1.Controls.Add(lblProductName);
            panel1.Location = new Point(3, 152);
            panel1.Name = "panel1";
            panel1.Size = new Size(253, 176);
            panel1.TabIndex = 1;
            // 
            // pbPriceL
            // 
            pbPriceL.Image = Properties.Resources.plus;
            pbPriceL.Location = new Point(172, 124);
            pbPriceL.Name = "pbPriceL";
            pbPriceL.Size = new Size(41, 36);
            pbPriceL.SizeMode = PictureBoxSizeMode.Zoom;
            pbPriceL.TabIndex = 9;
            pbPriceL.TabStop = false;
            pbPriceL.Click += pbPriceL_Click;
            
            // 
            // pbPriceM
            // 
            pbPriceM.Image = Properties.Resources.plus;
            pbPriceM.Location = new Point(172, 78);
            pbPriceM.Name = "pbPriceM";
            pbPriceM.Size = new Size(41, 36);
            pbPriceM.SizeMode = PictureBoxSizeMode.Zoom;
            pbPriceM.TabIndex = 8;
            pbPriceM.TabStop = false;
            pbPriceM.Click += pbPriceM_Click;
            
            // 
            // pbPriceS
            // 
            pbPriceS.Image = Properties.Resources.plus;
            pbPriceS.Location = new Point(172, 35);
            pbPriceS.Name = "pbPriceS";
            pbPriceS.Size = new Size(41, 36);
            pbPriceS.SizeMode = PictureBoxSizeMode.Zoom;
            pbPriceS.TabIndex = 7;
            pbPriceS.TabStop = false;
            pbPriceS.Click += pbPriceS_Click;
            
            // 
            // lblPriceL
            // 
            lblPriceL.AutoSize = true;
            lblPriceL.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPriceL.Location = new Point(84, 124);
            lblPriceL.Name = "lblPriceL";
            lblPriceL.Size = new Size(58, 23);
            lblPriceL.TabIndex = 6;
            lblPriceL.Text = "Size S:";
            // 
            // lblPriceM
            // 
            lblPriceM.AutoSize = true;
            lblPriceM.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPriceM.Location = new Point(84, 78);
            lblPriceM.Name = "lblPriceM";
            lblPriceM.Size = new Size(58, 23);
            lblPriceM.TabIndex = 5;
            lblPriceM.Text = "Size S:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(21, 124);
            label3.Name = "label3";
            label3.Size = new Size(57, 23);
            label3.TabIndex = 4;
            label3.Text = "Size L:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(20, 78);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 3;
            label2.Text = "Size M:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(20, 35);
            label1.Name = "label1";
            label1.Size = new Size(58, 23);
            label1.TabIndex = 2;
            label1.Text = "Size S:";
            // 
            // lblPriceS
            // 
            lblPriceS.AutoSize = true;
            lblPriceS.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblPriceS.Location = new Point(84, 35);
            lblPriceS.Name = "lblPriceS";
            lblPriceS.Size = new Size(58, 23);
            lblPriceS.TabIndex = 1;
            lblPriceS.Text = "Size S:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblProductName.Location = new Point(20, 4);
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
            Size = new Size(260, 338);
            guna2ShadowPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPriceL).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPriceM).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPriceS).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Panel panel1;
        private PictureBox picProductImage;
        private Label lblPriceS;
        private Label lblProductName;
        private Label label2;
        private Label label1;
        private Label lblPriceL;
        private Label lblPriceM;
        private Label label3;
        private PictureBox pbPriceM;
        private PictureBox pbPriceS;
        private PictureBox pbPriceL;
    }
}
