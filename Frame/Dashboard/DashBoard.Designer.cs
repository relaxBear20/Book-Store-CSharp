namespace prjC
{
    partial class DashBoard
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
            this.flpDisplaySale = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSaleAver = new System.Windows.Forms.Label();
            this.lblSaleHighest = new System.Windows.Forms.Label();
            this.lblTotalAt = new System.Windows.Forms.Label();
            this.lblMonthsSale = new System.Windows.Forms.Label();
            this.cbxMonthsSale = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTopBook = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvTopEmployee = new System.Windows.Forms.DataGridView();
            this.lblLowest = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBook)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // flpDisplaySale
            // 
            this.flpDisplaySale.AutoSize = true;
            this.flpDisplaySale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpDisplaySale.Location = new System.Drawing.Point(327, 57);
            this.flpDisplaySale.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.flpDisplaySale.Name = "flpDisplaySale";
            this.flpDisplaySale.Size = new System.Drawing.Size(1080, 250);
            this.flpDisplaySale.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLowest);
            this.groupBox2.Controls.Add(this.lblSaleAver);
            this.groupBox2.Controls.Add(this.lblSaleHighest);
            this.groupBox2.Controls.Add(this.lblTotalAt);
            this.groupBox2.Controls.Add(this.lblMonthsSale);
            this.groupBox2.Controls.Add(this.cbxMonthsSale);
            this.groupBox2.Controls.Add(this.flpDisplaySale);
            this.groupBox2.Location = new System.Drawing.Point(12, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1355, 339);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sale";
            // 
            // lblSaleAver
            // 
            this.lblSaleAver.AutoSize = true;
            this.lblSaleAver.Location = new System.Drawing.Point(22, 217);
            this.lblSaleAver.Name = "lblSaleAver";
            this.lblSaleAver.Size = new System.Drawing.Size(69, 17);
            this.lblSaleAver.TabIndex = 7;
            this.lblSaleAver.Text = "Average: ";
            // 
            // lblSaleHighest
            // 
            this.lblSaleHighest.AutoSize = true;
            this.lblSaleHighest.Location = new System.Drawing.Point(22, 180);
            this.lblSaleHighest.Name = "lblSaleHighest";
            this.lblSaleHighest.Size = new System.Drawing.Size(92, 17);
            this.lblSaleHighest.TabIndex = 6;
            this.lblSaleHighest.Text = "Highest Sale:";
            // 
            // lblTotalAt
            // 
            this.lblTotalAt.AutoSize = true;
            this.lblTotalAt.Location = new System.Drawing.Point(324, 26);
            this.lblTotalAt.Name = "lblTotalAt";
            this.lblTotalAt.Size = new System.Drawing.Size(61, 17);
            this.lblTotalAt.TabIndex = 5;
            this.lblTotalAt.Text = "Total At:";
            this.lblTotalAt.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // lblMonthsSale
            // 
            this.lblMonthsSale.AutoSize = true;
            this.lblMonthsSale.Location = new System.Drawing.Point(22, 64);
            this.lblMonthsSale.Name = "lblMonthsSale";
            this.lblMonthsSale.Size = new System.Drawing.Size(58, 17);
            this.lblMonthsSale.TabIndex = 2;
            this.lblMonthsSale.Text = "Months:";
            // 
            // cbxMonthsSale
            // 
            this.cbxMonthsSale.FormattingEnabled = true;
            this.cbxMonthsSale.Location = new System.Drawing.Point(108, 57);
            this.cbxMonthsSale.Name = "cbxMonthsSale";
            this.cbxMonthsSale.Size = new System.Drawing.Size(133, 24);
            this.cbxMonthsSale.TabIndex = 1;
            this.cbxMonthsSale.SelectedIndexChanged += new System.EventHandler(this.cbxMonthsSale_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTopBook);
            this.groupBox1.Location = new System.Drawing.Point(12, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 235);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top 5 Book";
            // 
            // dgvTopBook
            // 
            this.dgvTopBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopBook.Location = new System.Drawing.Point(25, 37);
            this.dgvTopBook.Name = "dgvTopBook";
            this.dgvTopBook.RowHeadersWidth = 51;
            this.dgvTopBook.RowTemplate.Height = 24;
            this.dgvTopBook.Size = new System.Drawing.Size(614, 149);
            this.dgvTopBook.TabIndex = 9;
            this.dgvTopBook.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTopBook_DataBindingComplete);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvTopEmployee);
            this.groupBox4.Location = new System.Drawing.Point(739, 386);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(644, 235);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Top 5 Employee";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // dgvTopEmployee
            // 
            this.dgvTopEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopEmployee.Location = new System.Drawing.Point(28, 37);
            this.dgvTopEmployee.Name = "dgvTopEmployee";
            this.dgvTopEmployee.RowHeadersWidth = 51;
            this.dgvTopEmployee.RowTemplate.Height = 24;
            this.dgvTopEmployee.Size = new System.Drawing.Size(463, 149);
            this.dgvTopEmployee.TabIndex = 9;
            this.dgvTopEmployee.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTopEmployee_DataBindingComplete);
            // 
            // lblLowest
            // 
            this.lblLowest.AutoSize = true;
            this.lblLowest.Location = new System.Drawing.Point(22, 147);
            this.lblLowest.Name = "lblLowest";
            this.lblLowest.Size = new System.Drawing.Size(56, 17);
            this.lblLowest.TabIndex = 8;
            this.lblLowest.Text = "Lowest:";
            this.lblLowest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 671);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopBook)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDisplaySale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMonthsSale;
        private System.Windows.Forms.ComboBox cbxMonthsSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTopBook;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvTopEmployee;
        private System.Windows.Forms.Label lblSaleAver;
        private System.Windows.Forms.Label lblSaleHighest;
        private System.Windows.Forms.Label lblTotalAt;
        private System.Windows.Forms.Label lblLowest;
    }
}