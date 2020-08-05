namespace prjC
{
    partial class ImportBookForm
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
            this.groupBoxImportDetails = new System.Windows.Forms.GroupBox();
            this.labelImportUnitsMessage = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.textBoxImportUnits = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxUnitsInStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxBookDetails = new System.Windows.Forms.GroupBox();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxCategoriesName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxBookID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxImportDetails.SuspendLayout();
            this.groupBoxBookDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxImportDetails
            // 
            this.groupBoxImportDetails.Controls.Add(this.labelImportUnitsMessage);
            this.groupBoxImportDetails.Controls.Add(this.buttonImport);
            this.groupBoxImportDetails.Controls.Add(this.textBoxImportUnits);
            this.groupBoxImportDetails.Controls.Add(this.label11);
            this.groupBoxImportDetails.Controls.Add(this.textBoxUnitsInStock);
            this.groupBoxImportDetails.Controls.Add(this.label1);
            this.groupBoxImportDetails.Location = new System.Drawing.Point(438, 268);
            this.groupBoxImportDetails.Name = "groupBoxImportDetails";
            this.groupBoxImportDetails.Size = new System.Drawing.Size(200, 235);
            this.groupBoxImportDetails.TabIndex = 0;
            this.groupBoxImportDetails.TabStop = false;
            this.groupBoxImportDetails.Text = "Import Details";
            this.groupBoxImportDetails.Visible = false;
            // 
            // labelImportUnitsMessage
            // 
            this.labelImportUnitsMessage.ForeColor = System.Drawing.Color.Red;
            this.labelImportUnitsMessage.Location = new System.Drawing.Point(89, 67);
            this.labelImportUnitsMessage.Name = "labelImportUnitsMessage";
            this.labelImportUnitsMessage.Size = new System.Drawing.Size(111, 26);
            this.labelImportUnitsMessage.TabIndex = 6;
            this.labelImportUnitsMessage.Text = "Import Units is invalid";
            // 
            // buttonImport
            // 
            this.buttonImport.Enabled = false;
            this.buttonImport.Location = new System.Drawing.Point(9, 101);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(185, 23);
            this.buttonImport.TabIndex = 5;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // textBoxImportUnits
            // 
            this.textBoxImportUnits.Location = new System.Drawing.Point(89, 40);
            this.textBoxImportUnits.Name = "textBoxImportUnits";
            this.textBoxImportUnits.Size = new System.Drawing.Size(111, 20);
            this.textBoxImportUnits.TabIndex = 4;
            this.textBoxImportUnits.TextChanged += new System.EventHandler(this.TextBoxImportUnits_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Import Units:";
            // 
            // textBoxUnitsInStock
            // 
            this.textBoxUnitsInStock.Enabled = false;
            this.textBoxUnitsInStock.Location = new System.Drawing.Point(89, 13);
            this.textBoxUnitsInStock.Name = "textBoxUnitsInStock";
            this.textBoxUnitsInStock.Size = new System.Drawing.Size(111, 20);
            this.textBoxUnitsInStock.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Units In Stock:";
            // 
            // groupBoxBookDetails
            // 
            this.groupBoxBookDetails.Controls.Add(this.textBoxPublisher);
            this.groupBoxBookDetails.Controls.Add(this.textBoxAuthor);
            this.groupBoxBookDetails.Controls.Add(this.textBoxCategoriesName);
            this.groupBoxBookDetails.Controls.Add(this.label9);
            this.groupBoxBookDetails.Controls.Add(this.textBoxDescription);
            this.groupBoxBookDetails.Controls.Add(this.label7);
            this.groupBoxBookDetails.Controls.Add(this.textBoxUnitPrice);
            this.groupBoxBookDetails.Controls.Add(this.label6);
            this.groupBoxBookDetails.Controls.Add(this.label5);
            this.groupBoxBookDetails.Controls.Add(this.label4);
            this.groupBoxBookDetails.Controls.Add(this.label3);
            this.groupBoxBookDetails.Controls.Add(this.dateTimePickerPublicationDate);
            this.groupBoxBookDetails.Controls.Add(this.label8);
            this.groupBoxBookDetails.Controls.Add(this.textBoxTitle);
            this.groupBoxBookDetails.Controls.Add(this.textBoxBookID);
            this.groupBoxBookDetails.Controls.Add(this.label10);
            this.groupBoxBookDetails.Location = new System.Drawing.Point(12, 268);
            this.groupBoxBookDetails.Name = "groupBoxBookDetails";
            this.groupBoxBookDetails.Size = new System.Drawing.Size(420, 235);
            this.groupBoxBookDetails.TabIndex = 2;
            this.groupBoxBookDetails.TabStop = false;
            this.groupBoxBookDetails.Text = "Book Details";
            this.groupBoxBookDetails.Visible = false;
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Enabled = false;
            this.textBoxPublisher.Location = new System.Drawing.Point(101, 96);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(313, 20);
            this.textBoxPublisher.TabIndex = 20;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Enabled = false;
            this.textBoxAuthor.Location = new System.Drawing.Point(101, 69);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(313, 20);
            this.textBoxAuthor.TabIndex = 19;
            // 
            // textBoxCategoriesName
            // 
            this.textBoxCategoriesName.Enabled = false;
            this.textBoxCategoriesName.Location = new System.Drawing.Point(101, 152);
            this.textBoxCategoriesName.Name = "textBoxCategoriesName";
            this.textBoxCategoriesName.Size = new System.Drawing.Size(313, 20);
            this.textBoxCategoriesName.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Location = new System.Drawing.Point(101, 204);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(313, 20);
            this.textBoxDescription.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Unit Price:";
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.Enabled = false;
            this.textBoxUnitPrice.Location = new System.Drawing.Point(101, 178);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.Size = new System.Drawing.Size(313, 20);
            this.textBoxUnitPrice.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Categories:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Publisher:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Author:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title:";
            // 
            // dateTimePickerPublicationDate
            // 
            this.dateTimePickerPublicationDate.Enabled = false;
            this.dateTimePickerPublicationDate.Location = new System.Drawing.Point(101, 125);
            this.dateTimePickerPublicationDate.Name = "dateTimePickerPublicationDate";
            this.dateTimePickerPublicationDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPublicationDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Publication Date:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Location = new System.Drawing.Point(101, 43);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(313, 20);
            this.textBoxTitle.TabIndex = 2;
            // 
            // textBoxBookID
            // 
            this.textBoxBookID.Enabled = false;
            this.textBoxBookID.Location = new System.Drawing.Point(101, 17);
            this.textBoxBookID.Name = "textBoxBookID";
            this.textBoxBookID.Size = new System.Drawing.Size(313, 20);
            this.textBoxBookID.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Book ID:";
            // 
            // ImportBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 511);
            this.Controls.Add(this.groupBoxBookDetails);
            this.Controls.Add(this.groupBoxImportDetails);
            this.Name = "ImportBookForm";
            this.Text = "Import Book Form";
            this.Load += new System.EventHandler(this.ImportBookForm_Load);
            this.groupBoxImportDetails.ResumeLayout(false);
            this.groupBoxImportDetails.PerformLayout();
            this.groupBoxBookDetails.ResumeLayout(false);
            this.groupBoxBookDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxImportDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxBookDetails;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxCategoriesName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPublicationDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxBookID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TextBox textBoxImportUnits;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxUnitsInStock;
        private System.Windows.Forms.Label labelImportUnitsMessage;
    }
}