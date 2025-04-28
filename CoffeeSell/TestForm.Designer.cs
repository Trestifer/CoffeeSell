namespace CoffeeSell
{
    partial class TestForm
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
            dtgridTest = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgridTest).BeginInit();
            SuspendLayout();
            // 
            // dtgridTest
            // 
            dtgridTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgridTest.Location = new Point(133, 71);
            dtgridTest.Name = "dtgridTest";
            dtgridTest.Size = new Size(705, 394);
            dtgridTest.TabIndex = 0;
            dtgridTest.CellContentClick += dtgridTest_CellContentClick;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 531);
            Controls.Add(dtgridTest);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ((System.ComponentModel.ISupportInitialize)dtgridTest).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgridTest;
    }
}