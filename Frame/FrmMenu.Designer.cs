namespace prjC.Frame
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mniDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mniStoreage = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBook = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBookView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBookAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPublisher = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAuthors = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMyAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAccountList = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFormDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.mniBookImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniDashboard,
            this.mniOrder,
            this.mniStoreage,
            this.mniAccount,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mniDashboard
            // 
            this.mniDashboard.Name = "mniDashboard";
            this.mniDashboard.Size = new System.Drawing.Size(105, 24);
            this.mniDashboard.Text = "Dashboard";
            this.mniDashboard.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // mniOrder
            // 
            this.mniOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniRetail,
            this.mniBills});
            this.mniOrder.Name = "mniOrder";
            this.mniOrder.Size = new System.Drawing.Size(66, 24);
            this.mniOrder.Text = "Order";
            // 
            // mniRetail
            // 
            this.mniRetail.Name = "mniRetail";
            this.mniRetail.Size = new System.Drawing.Size(224, 26);
            this.mniRetail.Text = "Retail";
            this.mniRetail.Click += new System.EventHandler(this.mniRetail_Click);
            // 
            // mniBills
            // 
            this.mniBills.Name = "mniBills";
            this.mniBills.Size = new System.Drawing.Size(224, 26);
            this.mniBills.Text = "Bills";
            this.mniBills.Click += new System.EventHandler(this.mniBills_Click);
            // 
            // mniStoreage
            // 
            this.mniStoreage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniBook,
            this.mniPublisher,
            this.mniAuthors});
            this.mniStoreage.Name = "mniStoreage";
            this.mniStoreage.Size = new System.Drawing.Size(81, 24);
            this.mniStoreage.Text = "Storage";
            // 
            // mniBook
            // 
            this.mniBook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniBookView,
            this.mniBookAdd,
            this.mniBookImport});
            this.mniBook.Name = "mniBook";
            this.mniBook.Size = new System.Drawing.Size(224, 26);
            this.mniBook.Text = "Book";
            // 
            // mniBookView
            // 
            this.mniBookView.Name = "mniBookView";
            this.mniBookView.Size = new System.Drawing.Size(224, 26);
            this.mniBookView.Text = "View";
            this.mniBookView.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // mniBookAdd
            // 
            this.mniBookAdd.Name = "mniBookAdd";
            this.mniBookAdd.Size = new System.Drawing.Size(224, 26);
            this.mniBookAdd.Text = "Add";
            this.mniBookAdd.Click += new System.EventHandler(this.mniBookAdd_Click);
            // 
            // mniPublisher
            // 
            this.mniPublisher.Name = "mniPublisher";
            this.mniPublisher.Size = new System.Drawing.Size(224, 26);
            this.mniPublisher.Text = "Publishers";
            this.mniPublisher.Click += new System.EventHandler(this.authorsToolStripMenuItem_Click);
            // 
            // mniAuthors
            // 
            this.mniAuthors.Name = "mniAuthors";
            this.mniAuthors.Size = new System.Drawing.Size(224, 26);
            this.mniAuthors.Text = "Authors";
            this.mniAuthors.Click += new System.EventHandler(this.authorsToolStripMenuItem1_Click);
            // 
            // mniAccount
            // 
            this.mniAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniMyAccount,
            this.mniAccountList,
            this.mniNewAccount});
            this.mniAccount.Name = "mniAccount";
            this.mniAccount.Size = new System.Drawing.Size(84, 24);
            this.mniAccount.Text = "Account";
            // 
            // mniMyAccount
            // 
            this.mniMyAccount.Name = "mniMyAccount";
            this.mniMyAccount.Size = new System.Drawing.Size(224, 26);
            this.mniMyAccount.Text = "My Account";
            this.mniMyAccount.Click += new System.EventHandler(this.mniMyAccount_Click);
            // 
            // mniAccountList
            // 
            this.mniAccountList.Name = "mniAccountList";
            this.mniAccountList.Size = new System.Drawing.Size(224, 26);
            this.mniAccountList.Text = "Account List";
            this.mniAccountList.Click += new System.EventHandler(this.mniAccountList_Click);
            // 
            // mniNewAccount
            // 
            this.mniNewAccount.Name = "mniNewAccount";
            this.mniNewAccount.Size = new System.Drawing.Size(224, 26);
            this.mniNewAccount.Text = "New Account";
            this.mniNewAccount.Click += new System.EventHandler(this.newAccountToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // pnlFormDisplay
            // 
            this.pnlFormDisplay.AutoSize = true;
            this.pnlFormDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFormDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormDisplay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFormDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFormDisplay.Location = new System.Drawing.Point(0, 30);
            this.pnlFormDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFormDisplay.Name = "pnlFormDisplay";
            this.pnlFormDisplay.Size = new System.Drawing.Size(1924, 1025);
            this.pnlFormDisplay.TabIndex = 2;
            // 
            // mniBookImport
            // 
            this.mniBookImport.Name = "mniBookImport";
            this.mniBookImport.Size = new System.Drawing.Size(224, 26);
            this.mniBookImport.Text = "Import";
            this.mniBookImport.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnlFormDisplay);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMenu_FormClosed);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniOrder;
        private System.Windows.Forms.ToolStripMenuItem mniStoreage;
        private System.Windows.Forms.ToolStripMenuItem mniAccount;
        private System.Windows.Forms.ToolStripMenuItem mniRetail;
        private System.Windows.Forms.ToolStripMenuItem mniBills;
        private System.Windows.Forms.ToolStripMenuItem mniBook;
        private System.Windows.Forms.ToolStripMenuItem mniBookView;
        private System.Windows.Forms.ToolStripMenuItem mniBookAdd;
        private System.Windows.Forms.ToolStripMenuItem mniPublisher;
        private System.Windows.Forms.ToolStripMenuItem mniAuthors;
        private System.Windows.Forms.ToolStripMenuItem mniMyAccount;
        private System.Windows.Forms.ToolStripMenuItem mniAccountList;
        private System.Windows.Forms.ToolStripMenuItem mniNewAccount;
        private System.Windows.Forms.FlowLayoutPanel pnlFormDisplay;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniDashboard;
        private System.Windows.Forms.ToolStripMenuItem mniBookImport;
    }
}