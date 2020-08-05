namespace prjC
{
    partial class AddPublisherForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEmailMessage = new System.Windows.Forms.Label();
            this.labelFaxMessage = new System.Windows.Forms.Label();
            this.labelPhoneMessage = new System.Windows.Forms.Label();
            this.labelAddressMessage = new System.Windows.Forms.Label();
            this.labelPublisherNameMessage = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFax = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPublisherName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddPublisher = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEmailMessage);
            this.groupBox1.Controls.Add(this.labelFaxMessage);
            this.groupBox1.Controls.Add(this.labelPhoneMessage);
            this.groupBox1.Controls.Add(this.labelAddressMessage);
            this.groupBox1.Controls.Add(this.labelPublisherNameMessage);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxFax);
            this.groupBox1.Controls.Add(this.textBoxPhone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.textBoxPublisherName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Publisher Details";
            // 
            // labelEmailMessage
            // 
            this.labelEmailMessage.ForeColor = System.Drawing.Color.Green;
            this.labelEmailMessage.Location = new System.Drawing.Point(97, 264);
            this.labelEmailMessage.Name = "labelEmailMessage";
            this.labelEmailMessage.Size = new System.Drawing.Size(212, 26);
            this.labelEmailMessage.TabIndex = 14;
            this.labelEmailMessage.Text = "Email is not required";
            // 
            // labelFaxMessage
            // 
            this.labelFaxMessage.ForeColor = System.Drawing.Color.Green;
            this.labelFaxMessage.Location = new System.Drawing.Point(97, 208);
            this.labelFaxMessage.Name = "labelFaxMessage";
            this.labelFaxMessage.Size = new System.Drawing.Size(212, 26);
            this.labelFaxMessage.TabIndex = 13;
            this.labelFaxMessage.Text = "Fax is not required";
            // 
            // labelPhoneMessage
            // 
            this.labelPhoneMessage.ForeColor = System.Drawing.Color.Green;
            this.labelPhoneMessage.Location = new System.Drawing.Point(97, 152);
            this.labelPhoneMessage.Name = "labelPhoneMessage";
            this.labelPhoneMessage.Size = new System.Drawing.Size(212, 26);
            this.labelPhoneMessage.TabIndex = 12;
            this.labelPhoneMessage.Text = "Phone is not required";
            // 
            // labelAddressMessage
            // 
            this.labelAddressMessage.ForeColor = System.Drawing.Color.Red;
            this.labelAddressMessage.Location = new System.Drawing.Point(97, 96);
            this.labelAddressMessage.Name = "labelAddressMessage";
            this.labelAddressMessage.Size = new System.Drawing.Size(212, 26);
            this.labelAddressMessage.TabIndex = 11;
            this.labelAddressMessage.Text = "Address is required";
            // 
            // labelPublisherNameMessage
            // 
            this.labelPublisherNameMessage.AutoSize = true;
            this.labelPublisherNameMessage.ForeColor = System.Drawing.Color.Red;
            this.labelPublisherNameMessage.Location = new System.Drawing.Point(97, 40);
            this.labelPublisherNameMessage.Name = "labelPublisherNameMessage";
            this.labelPublisherNameMessage.Size = new System.Drawing.Size(132, 13);
            this.labelPublisherNameMessage.TabIndex = 10;
            this.labelPublisherNameMessage.Text = "Publisher Name is required";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(97, 237);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(212, 20);
            this.textBoxEmail.TabIndex = 9;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.TextBoxEmail_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fax:";
            // 
            // textBoxFax
            // 
            this.textBoxFax.Location = new System.Drawing.Point(97, 181);
            this.textBoxFax.Name = "textBoxFax";
            this.textBoxFax.Size = new System.Drawing.Size(212, 20);
            this.textBoxFax.TabIndex = 6;
            this.textBoxFax.TextChanged += new System.EventHandler(this.TextBoxFax_TextChanged);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(97, 125);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(212, 20);
            this.textBoxPhone.TabIndex = 5;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.TextBoxPhone_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phone:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(97, 69);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(212, 20);
            this.textBoxAddress.TabIndex = 3;
            this.textBoxAddress.TextChanged += new System.EventHandler(this.TextBoxAddress_TextChanged);
            // 
            // textBoxPublisherName
            // 
            this.textBoxPublisherName.Location = new System.Drawing.Point(97, 17);
            this.textBoxPublisherName.Name = "textBoxPublisherName";
            this.textBoxPublisherName.Size = new System.Drawing.Size(212, 20);
            this.textBoxPublisherName.TabIndex = 2;
            this.textBoxPublisherName.TextChanged += new System.EventHandler(this.TextBoxPublisherName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Publisher Name:";
            // 
            // buttonAddPublisher
            // 
            this.buttonAddPublisher.Location = new System.Drawing.Point(12, 318);
            this.buttonAddPublisher.Name = "buttonAddPublisher";
            this.buttonAddPublisher.Size = new System.Drawing.Size(316, 23);
            this.buttonAddPublisher.TabIndex = 10;
            this.buttonAddPublisher.Text = "Add Publisher";
            this.buttonAddPublisher.UseVisualStyleBackColor = true;
            this.buttonAddPublisher.Click += new System.EventHandler(this.ButtonAddPublisher_Click);
            // 
            // AddPublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 351);
            this.Controls.Add(this.buttonAddPublisher);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddPublisherForm";
            this.Text = "Add Publisher Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFax;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPublisherName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddPublisher;
        private System.Windows.Forms.Label labelEmailMessage;
        private System.Windows.Forms.Label labelFaxMessage;
        private System.Windows.Forms.Label labelPhoneMessage;
        private System.Windows.Forms.Label labelAddressMessage;
        private System.Windows.Forms.Label labelPublisherNameMessage;
    }
}