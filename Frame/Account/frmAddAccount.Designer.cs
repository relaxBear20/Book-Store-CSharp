namespace prjC
{
    partial class frmAddAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbNewRole = new System.Windows.Forms.GroupBox();
            this.pnlNewRole = new System.Windows.Forms.Panel();
            this.btnCancelNewRole = new System.Windows.Forms.Button();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.lstFeatures = new System.Windows.Forms.ListBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fglFeaturesDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.txtAccPassword = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grbNewRole.SuspendLayout();
            this.pnlNewRole.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbNewRole);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1451, 480);
            this.panel1.TabIndex = 1444;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // grbNewRole
            // 
            this.grbNewRole.Controls.Add(this.pnlNewRole);
            this.grbNewRole.Location = new System.Drawing.Point(983, 32);
            this.grbNewRole.Name = "grbNewRole";
            this.grbNewRole.Size = new System.Drawing.Size(410, 384);
            this.grbNewRole.TabIndex = 6;
            this.grbNewRole.TabStop = false;
            this.grbNewRole.Text = "NewRole";
            this.grbNewRole.Visible = false;
            // 
            // pnlNewRole
            // 
            this.pnlNewRole.Controls.Add(this.btnCancelNewRole);
            this.pnlNewRole.Controls.Add(this.btnCreateRole);
            this.pnlNewRole.Controls.Add(this.lstFeatures);
            this.pnlNewRole.Controls.Add(this.txtRoleName);
            this.pnlNewRole.Controls.Add(this.label10);
            this.pnlNewRole.Controls.Add(this.label9);
            this.pnlNewRole.Location = new System.Drawing.Point(6, 30);
            this.pnlNewRole.Name = "pnlNewRole";
            this.pnlNewRole.Size = new System.Drawing.Size(375, 348);
            this.pnlNewRole.TabIndex = 8787;
            // 
            // btnCancelNewRole
            // 
            this.btnCancelNewRole.Location = new System.Drawing.Point(213, 225);
            this.btnCancelNewRole.Name = "btnCancelNewRole";
            this.btnCancelNewRole.Size = new System.Drawing.Size(142, 39);
            this.btnCancelNewRole.TabIndex = 15;
            this.btnCancelNewRole.Text = "Cancel";
            this.btnCancelNewRole.UseVisualStyleBackColor = true;
            this.btnCancelNewRole.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(83, 225);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(124, 39);
            this.btnCreateRole.TabIndex = 14;
            this.btnCreateRole.Text = "Create";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstFeatures
            // 
            this.lstFeatures.FormattingEnabled = true;
            this.lstFeatures.ItemHeight = 16;
            this.lstFeatures.Location = new System.Drawing.Point(122, 59);
            this.lstFeatures.Name = "lstFeatures";
            this.lstFeatures.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFeatures.Size = new System.Drawing.Size(233, 132);
            this.lstFeatures.TabIndex = 13;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(122, 26);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(233, 22);
            this.txtRoleName.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Features:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Role:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEditRole);
            this.groupBox3.Controls.Add(this.lstRoles);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.fglFeaturesDisplay);
            this.groupBox3.Controls.Add(this.btnNewRole);
            this.groupBox3.Location = new System.Drawing.Point(473, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 387);
            this.groupBox3.TabIndex = 87;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authorization";
            // 
            // btnEditRole
            // 
            this.btnEditRole.Location = new System.Drawing.Point(369, 121);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(128, 43);
            this.btnEditRole.TabIndex = 11;
            this.btnEditRole.Text = "Edit Role";
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.ItemHeight = 16;
            this.lstRoles.Location = new System.Drawing.Point(86, 64);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstRoles.Size = new System.Drawing.Size(246, 100);
            this.lstRoles.TabIndex = 6;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Role:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Features:";
            // 
            // fglFeaturesDisplay
            // 
            this.fglFeaturesDisplay.AutoScroll = true;
            this.fglFeaturesDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fglFeaturesDisplay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fglFeaturesDisplay.Location = new System.Drawing.Point(86, 190);
            this.fglFeaturesDisplay.Name = "fglFeaturesDisplay";
            this.fglFeaturesDisplay.Size = new System.Drawing.Size(246, 188);
            this.fglFeaturesDisplay.TabIndex = 5;
            // 
            // btnNewRole
            // 
            this.btnNewRole.Location = new System.Drawing.Point(369, 64);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(128, 43);
            this.btnNewRole.TabIndex = 10;
            this.btnNewRole.Text = "New";
            this.btnNewRole.UseVisualStyleBackColor = true;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAccName);
            this.groupBox1.Controls.Add(this.txtAccPassword);
            this.groupBox1.Controls.Add(this.btnCreateAccount);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 387);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Name: ";
            // 
            // txtAccName
            // 
            this.txtAccName.Location = new System.Drawing.Point(163, 67);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.Size = new System.Drawing.Size(250, 22);
            this.txtAccName.TabIndex = 0;
            // 
            // txtAccPassword
            // 
            this.txtAccPassword.Location = new System.Drawing.Point(163, 110);
            this.txtAccPassword.Name = "txtAccPassword";
            this.txtAccPassword.Size = new System.Drawing.Size(250, 22);
            this.txtAccPassword.TabIndex = 1;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(163, 328);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(250, 40);
            this.btnCreateAccount.TabIndex = 7;
            this.btnCreateAccount.Text = "Create";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(163, 149);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(250, 22);
            this.txtFirstName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Account Password:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(163, 188);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(250, 22);
            this.txtLastName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(163, 228);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 22);
            this.txtPhone.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(163, 278);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Phone: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "First Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Last Name:";
            // 
            // frmAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 504);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddAccount";
            this.Text = "frmAddAccount";
            this.Load += new System.EventHandler(this.frmAddAccount_Load);
            this.panel1.ResumeLayout(false);
            this.grbNewRole.ResumeLayout(false);
            this.pnlNewRole.ResumeLayout(false);
            this.pnlNewRole.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel fglFeaturesDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtAccPassword;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.GroupBox grbNewRole;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Panel pnlNewRole;
        private System.Windows.Forms.Button btnCancelNewRole;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.ListBox lstFeatures;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}