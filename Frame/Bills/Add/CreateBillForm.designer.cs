namespace prjC
{
    partial class CreateBillForm
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
            this.dataGridViewBillDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxBillDetails = new System.Windows.Forms.GroupBox();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.buttonCreateBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillDetails)).BeginInit();
            this.groupBoxBillDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBillDetails
            // 
            this.dataGridViewBillDetails.AllowUserToAddRows = false;
            this.dataGridViewBillDetails.AllowUserToDeleteRows = false;
            this.dataGridViewBillDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBillDetails.Location = new System.Drawing.Point(4, 19);
            this.dataGridViewBillDetails.Name = "dataGridViewBillDetails";
            this.dataGridViewBillDetails.ReadOnly = true;
            this.dataGridViewBillDetails.Size = new System.Drawing.Size(650, 150);
            this.dataGridViewBillDetails.TabIndex = 4;
            this.dataGridViewBillDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBillDetails_CellContentClick);
            // 
            // groupBoxBillDetails
            // 
            this.groupBoxBillDetails.Controls.Add(this.labelTotalPrice);
            this.groupBoxBillDetails.Controls.Add(this.dataGridViewBillDetails);
            this.groupBoxBillDetails.Location = new System.Drawing.Point(12, 268);
            this.groupBoxBillDetails.Name = "groupBoxBillDetails";
            this.groupBoxBillDetails.Size = new System.Drawing.Size(660, 195);
            this.groupBoxBillDetails.TabIndex = 5;
            this.groupBoxBillDetails.TabStop = false;
            this.groupBoxBillDetails.Text = "Bill Details";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(7, 176);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(70, 13);
            this.labelTotalPrice.TabIndex = 5;
            this.labelTotalPrice.Text = "Total Price: 0";
            // 
            // buttonCreateBill
            // 
            this.buttonCreateBill.Enabled = false;
            this.buttonCreateBill.Location = new System.Drawing.Point(12, 469);
            this.buttonCreateBill.Name = "buttonCreateBill";
            this.buttonCreateBill.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateBill.TabIndex = 6;
            this.buttonCreateBill.Text = "Create Bill";
            this.buttonCreateBill.UseVisualStyleBackColor = true;
            this.buttonCreateBill.Click += new System.EventHandler(this.ButtonCreateBill_Click);
            // 
            // CreateBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 506);
            this.Controls.Add(this.buttonCreateBill);
            this.Controls.Add(this.groupBoxBillDetails);
            this.Name = "CreateBillForm";
            this.Text = "Create Bill Form";
            this.Load += new System.EventHandler(this.CreateBillForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBillDetails)).EndInit();
            this.groupBoxBillDetails.ResumeLayout(false);
            this.groupBoxBillDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewBillDetails;
        private System.Windows.Forms.GroupBox groupBoxBillDetails;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Button buttonCreateBill;
    }
}

