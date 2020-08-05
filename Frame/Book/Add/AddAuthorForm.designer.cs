namespace prjC
{
    partial class AddAuthorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAbout = new System.Windows.Forms.TextBox();
            this.groupBoxAddNewAuthor = new System.Windows.Forms.GroupBox();
            this.labelAboutMessage = new System.Windows.Forms.Label();
            this.labelBirthDateMessage = new System.Windows.Forms.Label();
            this.labelLastNameMessage = new System.Windows.Forms.Label();
            this.labelFirstNameMessage = new System.Windows.Forms.Label();
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.groupBoxAddNewAuthor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(76, 19);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(231, 20);
            this.textBoxFirstName.TabIndex = 2;
            this.textBoxFirstName.TextChanged += new System.EventHandler(this.TextBoxFirstName_TextChanged);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(76, 71);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(231, 20);
            this.textBoxLastName.TabIndex = 3;
            this.textBoxLastName.TextChanged += new System.EventHandler(this.TextBoxLastName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Birth Date:";
            // 
            // dateTimePickerBirthDate
            // 
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(76, 127);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBirthDate.TabIndex = 5;
            this.dateTimePickerBirthDate.ValueChanged += new System.EventHandler(this.DateTimePickerBirthDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "About:";
            // 
            // textBoxAbout
            // 
            this.textBoxAbout.Location = new System.Drawing.Point(76, 183);
            this.textBoxAbout.Name = "textBoxAbout";
            this.textBoxAbout.Size = new System.Drawing.Size(231, 20);
            this.textBoxAbout.TabIndex = 7;
            this.textBoxAbout.TextChanged += new System.EventHandler(this.TextBoxAbout_TextChanged);
            // 
            // groupBoxAddNewAuthor
            // 
            this.groupBoxAddNewAuthor.Controls.Add(this.labelAboutMessage);
            this.groupBoxAddNewAuthor.Controls.Add(this.labelBirthDateMessage);
            this.groupBoxAddNewAuthor.Controls.Add(this.labelLastNameMessage);
            this.groupBoxAddNewAuthor.Controls.Add(this.labelFirstNameMessage);
            this.groupBoxAddNewAuthor.Controls.Add(this.label1);
            this.groupBoxAddNewAuthor.Controls.Add(this.label4);
            this.groupBoxAddNewAuthor.Controls.Add(this.textBoxAbout);
            this.groupBoxAddNewAuthor.Controls.Add(this.textBoxFirstName);
            this.groupBoxAddNewAuthor.Controls.Add(this.textBoxLastName);
            this.groupBoxAddNewAuthor.Controls.Add(this.label3);
            this.groupBoxAddNewAuthor.Controls.Add(this.dateTimePickerBirthDate);
            this.groupBoxAddNewAuthor.Controls.Add(this.label2);
            this.groupBoxAddNewAuthor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAddNewAuthor.Name = "groupBoxAddNewAuthor";
            this.groupBoxAddNewAuthor.Size = new System.Drawing.Size(310, 298);
            this.groupBoxAddNewAuthor.TabIndex = 8;
            this.groupBoxAddNewAuthor.TabStop = false;
            this.groupBoxAddNewAuthor.Text = "Author Details";
            // 
            // labelAboutMessage
            // 
            this.labelAboutMessage.ForeColor = System.Drawing.Color.Green;
            this.labelAboutMessage.Location = new System.Drawing.Point(76, 210);
            this.labelAboutMessage.Name = "labelAboutMessage";
            this.labelAboutMessage.Size = new System.Drawing.Size(231, 26);
            this.labelAboutMessage.TabIndex = 11;
            this.labelAboutMessage.Text = "About is not required";
            // 
            // labelBirthDateMessage
            // 
            this.labelBirthDateMessage.ForeColor = System.Drawing.Color.Red;
            this.labelBirthDateMessage.Location = new System.Drawing.Point(76, 154);
            this.labelBirthDateMessage.Name = "labelBirthDateMessage";
            this.labelBirthDateMessage.Size = new System.Drawing.Size(231, 26);
            this.labelBirthDateMessage.TabIndex = 10;
            this.labelBirthDateMessage.Text = "Birth Date is invalid";
            // 
            // labelLastNameMessage
            // 
            this.labelLastNameMessage.ForeColor = System.Drawing.Color.Green;
            this.labelLastNameMessage.Location = new System.Drawing.Point(76, 98);
            this.labelLastNameMessage.Name = "labelLastNameMessage";
            this.labelLastNameMessage.Size = new System.Drawing.Size(231, 26);
            this.labelLastNameMessage.TabIndex = 9;
            this.labelLastNameMessage.Text = "Last Name is not required";
            // 
            // labelFirstNameMessage
            // 
            this.labelFirstNameMessage.ForeColor = System.Drawing.Color.Red;
            this.labelFirstNameMessage.Location = new System.Drawing.Point(76, 42);
            this.labelFirstNameMessage.Name = "labelFirstNameMessage";
            this.labelFirstNameMessage.Size = new System.Drawing.Size(231, 26);
            this.labelFirstNameMessage.TabIndex = 8;
            this.labelFirstNameMessage.Text = "First Name is required";
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.Location = new System.Drawing.Point(10, 316);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(312, 23);
            this.buttonAddAuthor.TabIndex = 9;
            this.buttonAddAuthor.Text = "Add Author";
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.ButtonAddAuthor_Click);
            // 
            // AddAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 351);
            this.Controls.Add(this.buttonAddAuthor);
            this.Controls.Add(this.groupBoxAddNewAuthor);
            this.Name = "AddAuthorForm";
            this.Text = "Add Author Form";
            this.groupBoxAddNewAuthor.ResumeLayout(false);
            this.groupBoxAddNewAuthor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAbout;
        private System.Windows.Forms.GroupBox groupBoxAddNewAuthor;
        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.Label labelFirstNameMessage;
        private System.Windows.Forms.Label labelBirthDateMessage;
        private System.Windows.Forms.Label labelLastNameMessage;
        private System.Windows.Forms.Label labelAboutMessage;
    }
}