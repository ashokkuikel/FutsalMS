namespace Banepa_Futsal
{
    partial class frmPackageView
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
            this.dgvPackageView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPackageView
            // 
            this.dgvPackageView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPackageView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackageView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.dgvPackageView.Location = new System.Drawing.Point(12, 22);
            this.dgvPackageView.Name = "dgvPackageView";
            this.dgvPackageView.Size = new System.Drawing.Size(420, 239);
            this.dgvPackageView.TabIndex = 0;
            this.dgvPackageView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPackageView_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Package";
            this.Column2.HeaderText = "Package Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Rate";
            this.Column3.HeaderText = "Amount";
            this.Column3.Name = "Column3";
            // 
            // frmPackageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 288);
            this.Controls.Add(this.dgvPackageView);
            this.Name = "frmPackageView";
            this.Text = "Package Details";
            this.Load += new System.EventHandler(this.PackageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPackageView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}