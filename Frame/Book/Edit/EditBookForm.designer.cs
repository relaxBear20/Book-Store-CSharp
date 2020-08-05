namespace prjC
{
    partial class EditBookForm
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
            this.panelAddNew = new System.Windows.Forms.Panel();
            this.groupBoxBookDetails = new System.Windows.Forms.GroupBox();
            this.labelDescriptionMessage = new System.Windows.Forms.Label();
            this.labelUnitPriceMessage = new System.Windows.Forms.Label();
            this.labelCategoriesMessage = new System.Windows.Forms.Label();
            this.labelPublicationDateMessage = new System.Windows.Forms.Label();
            this.labelPublisherMessage = new System.Windows.Forms.Label();
            this.labelAuthorMessage = new System.Windows.Forms.Label();
            this.labelTitleMessage = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddNewCategory = new System.Windows.Forms.Button();
            this.buttonAddNewPublisher = new System.Windows.Forms.Button();
            this.buttonAddNewAuthor = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkedListBoxCategories = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPublishers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAuthors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.groupBoxBookDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAddNew
            // 
            this.panelAddNew.Location = new System.Drawing.Point(438, 12);
            this.panelAddNew.Name = "panelAddNew";
            this.panelAddNew.Size = new System.Drawing.Size(350, 390);
            this.panelAddNew.TabIndex = 2;
            // 
            // groupBoxBookDetails
            // 
            this.groupBoxBookDetails.Controls.Add(this.labelDescriptionMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelUnitPriceMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelCategoriesMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelPublicationDateMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelPublisherMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelAuthorMessage);
            this.groupBoxBookDetails.Controls.Add(this.labelTitleMessage);
            this.groupBoxBookDetails.Controls.Add(this.buttonEdit);
            this.groupBoxBookDetails.Controls.Add(this.buttonAddNewCategory);
            this.groupBoxBookDetails.Controls.Add(this.buttonAddNewPublisher);
            this.groupBoxBookDetails.Controls.Add(this.buttonAddNewAuthor);
            this.groupBoxBookDetails.Controls.Add(this.label9);
            this.groupBoxBookDetails.Controls.Add(this.textBoxDescription);
            this.groupBoxBookDetails.Controls.Add(this.label7);
            this.groupBoxBookDetails.Controls.Add(this.textBoxUnitPrice);
            this.groupBoxBookDetails.Controls.Add(this.label6);
            this.groupBoxBookDetails.Controls.Add(this.checkedListBoxCategories);
            this.groupBoxBookDetails.Controls.Add(this.label5);
            this.groupBoxBookDetails.Controls.Add(this.comboBoxPublishers);
            this.groupBoxBookDetails.Controls.Add(this.label4);
            this.groupBoxBookDetails.Controls.Add(this.comboBoxAuthors);
            this.groupBoxBookDetails.Controls.Add(this.label3);
            this.groupBoxBookDetails.Controls.Add(this.dateTimePickerPublicationDate);
            this.groupBoxBookDetails.Controls.Add(this.label2);
            this.groupBoxBookDetails.Controls.Add(this.textBoxTitle);
            this.groupBoxBookDetails.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBookDetails.Name = "groupBoxBookDetails";
            this.groupBoxBookDetails.Size = new System.Drawing.Size(420, 520);
            this.groupBoxBookDetails.TabIndex = 3;
            this.groupBoxBookDetails.TabStop = false;
            this.groupBoxBookDetails.Text = "Book Details";
            // 
            // labelDescriptionMessage
            // 
            this.labelDescriptionMessage.ForeColor = System.Drawing.Color.Green;
            this.labelDescriptionMessage.Location = new System.Drawing.Point(101, 458);
            this.labelDescriptionMessage.Name = "labelDescriptionMessage";
            this.labelDescriptionMessage.Size = new System.Drawing.Size(313, 26);
            this.labelDescriptionMessage.TabIndex = 28;
            this.labelDescriptionMessage.Text = "Description is not required";
            // 
            // labelUnitPriceMessage
            // 
            this.labelUnitPriceMessage.ForeColor = System.Drawing.Color.Green;
            this.labelUnitPriceMessage.Location = new System.Drawing.Point(101, 402);
            this.labelUnitPriceMessage.Name = "labelUnitPriceMessage";
            this.labelUnitPriceMessage.Size = new System.Drawing.Size(313, 26);
            this.labelUnitPriceMessage.TabIndex = 27;
            this.labelUnitPriceMessage.Text = "Unit Price is OK";
            // 
            // labelCategoriesMessage
            // 
            this.labelCategoriesMessage.ForeColor = System.Drawing.Color.Green;
            this.labelCategoriesMessage.Location = new System.Drawing.Point(101, 346);
            this.labelCategoriesMessage.Name = "labelCategoriesMessage";
            this.labelCategoriesMessage.Size = new System.Drawing.Size(200, 26);
            this.labelCategoriesMessage.TabIndex = 26;
            this.labelCategoriesMessage.Text = "Categories is selected";
            // 
            // labelPublicationDateMessage
            // 
            this.labelPublicationDateMessage.ForeColor = System.Drawing.Color.Green;
            this.labelPublicationDateMessage.Location = new System.Drawing.Point(101, 216);
            this.labelPublicationDateMessage.Name = "labelPublicationDateMessage";
            this.labelPublicationDateMessage.Size = new System.Drawing.Size(196, 26);
            this.labelPublicationDateMessage.TabIndex = 25;
            this.labelPublicationDateMessage.Text = "Publication Date is OK";
            // 
            // labelPublisherMessage
            // 
            this.labelPublisherMessage.ForeColor = System.Drawing.Color.Green;
            this.labelPublisherMessage.Location = new System.Drawing.Point(101, 160);
            this.labelPublisherMessage.Name = "labelPublisherMessage";
            this.labelPublisherMessage.Size = new System.Drawing.Size(196, 26);
            this.labelPublisherMessage.TabIndex = 24;
            this.labelPublisherMessage.Text = "Publisher is selected";
            // 
            // labelAuthorMessage
            // 
            this.labelAuthorMessage.ForeColor = System.Drawing.Color.Green;
            this.labelAuthorMessage.Location = new System.Drawing.Point(101, 103);
            this.labelAuthorMessage.Name = "labelAuthorMessage";
            this.labelAuthorMessage.Size = new System.Drawing.Size(196, 26);
            this.labelAuthorMessage.TabIndex = 23;
            this.labelAuthorMessage.Text = "Author is selected";
            // 
            // labelTitleMessage
            // 
            this.labelTitleMessage.ForeColor = System.Drawing.Color.Green;
            this.labelTitleMessage.Location = new System.Drawing.Point(101, 46);
            this.labelTitleMessage.Name = "labelTitleMessage";
            this.labelTitleMessage.Size = new System.Drawing.Size(309, 26);
            this.labelTitleMessage.TabIndex = 22;
            this.labelTitleMessage.Text = "Title is OK";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(10, 487);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(404, 23);
            this.buttonEdit.TabIndex = 21;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonAddNewCategory
            // 
            this.buttonAddNewCategory.AutoSize = true;
            this.buttonAddNewCategory.Location = new System.Drawing.Point(308, 245);
            this.buttonAddNewCategory.Name = "buttonAddNewCategory";
            this.buttonAddNewCategory.Size = new System.Drawing.Size(106, 23);
            this.buttonAddNewCategory.TabIndex = 20;
            this.buttonAddNewCategory.Text = "Add New Category";
            this.buttonAddNewCategory.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewPublisher
            // 
            this.buttonAddNewPublisher.AutoSize = true;
            this.buttonAddNewPublisher.Location = new System.Drawing.Point(308, 130);
            this.buttonAddNewPublisher.Name = "buttonAddNewPublisher";
            this.buttonAddNewPublisher.Size = new System.Drawing.Size(107, 23);
            this.buttonAddNewPublisher.TabIndex = 19;
            this.buttonAddNewPublisher.Text = "Add New Publisher";
            this.buttonAddNewPublisher.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewAuthor
            // 
            this.buttonAddNewAuthor.AutoSize = true;
            this.buttonAddNewAuthor.Location = new System.Drawing.Point(308, 73);
            this.buttonAddNewAuthor.Name = "buttonAddNewAuthor";
            this.buttonAddNewAuthor.Size = new System.Drawing.Size(106, 23);
            this.buttonAddNewAuthor.TabIndex = 18;
            this.buttonAddNewAuthor.Text = "Add New Author";
            this.buttonAddNewAuthor.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(101, 431);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(313, 20);
            this.textBoxDescription.TabIndex = 16;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.TextBoxDescription_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Unit Price:";
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.Location = new System.Drawing.Point(101, 375);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.Size = new System.Drawing.Size(313, 20);
            this.textBoxUnitPrice.TabIndex = 12;
            this.textBoxUnitPrice.TextChanged += new System.EventHandler(this.TextBoxUnitPrice_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Categories:";
            // 
            // checkedListBoxCategories
            // 
            this.checkedListBoxCategories.CheckOnClick = true;
            this.checkedListBoxCategories.FormattingEnabled = true;
            this.checkedListBoxCategories.Location = new System.Drawing.Point(101, 245);
            this.checkedListBoxCategories.Name = "checkedListBoxCategories";
            this.checkedListBoxCategories.Size = new System.Drawing.Size(200, 94);
            this.checkedListBoxCategories.TabIndex = 10;
            this.checkedListBoxCategories.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxCategories_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Publisher:";
            // 
            // comboBoxPublishers
            // 
            this.comboBoxPublishers.FormattingEnabled = true;
            this.comboBoxPublishers.Location = new System.Drawing.Point(101, 132);
            this.comboBoxPublishers.Name = "comboBoxPublishers";
            this.comboBoxPublishers.Size = new System.Drawing.Size(196, 21);
            this.comboBoxPublishers.TabIndex = 8;
            this.comboBoxPublishers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPublishers_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Author:";
            // 
            // comboBoxAuthors
            // 
            this.comboBoxAuthors.FormattingEnabled = true;
            this.comboBoxAuthors.Location = new System.Drawing.Point(101, 75);
            this.comboBoxAuthors.Name = "comboBoxAuthors";
            this.comboBoxAuthors.Size = new System.Drawing.Size(196, 21);
            this.comboBoxAuthors.TabIndex = 6;
            this.comboBoxAuthors.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAuthors_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Title:";
            // 
            // dateTimePickerPublicationDate
            // 
            this.dateTimePickerPublicationDate.Location = new System.Drawing.Point(101, 189);
            this.dateTimePickerPublicationDate.Name = "dateTimePickerPublicationDate";
            this.dateTimePickerPublicationDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPublicationDate.TabIndex = 4;
            this.dateTimePickerPublicationDate.ValueChanged += new System.EventHandler(this.DateTimePickerPublicationDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Publication Date:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(101, 19);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(313, 20);
            this.textBoxTitle.TabIndex = 2;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxTitle_TextChanged);
            // 
            // EditBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 541);
            this.Controls.Add(this.groupBoxBookDetails);
            this.Controls.Add(this.panelAddNew);
            this.Name = "EditBookForm";
            this.Text = "Edit Book Form";
            this.Load += new System.EventHandler(this.EditBookForm_Load);
            this.groupBoxBookDetails.ResumeLayout(false);
            this.groupBoxBookDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelAddNew;
        private System.Windows.Forms.GroupBox groupBoxBookDetails;
        private System.Windows.Forms.Label labelDescriptionMessage;
        private System.Windows.Forms.Label labelUnitPriceMessage;
        private System.Windows.Forms.Label labelCategoriesMessage;
        private System.Windows.Forms.Label labelPublicationDateMessage;
        private System.Windows.Forms.Label labelPublisherMessage;
        private System.Windows.Forms.Label labelAuthorMessage;
        private System.Windows.Forms.Label labelTitleMessage;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAddNewCategory;
        private System.Windows.Forms.Button buttonAddNewPublisher;
        private System.Windows.Forms.Button buttonAddNewAuthor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkedListBoxCategories;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPublishers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAuthors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPublicationDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTitle;
    }
}