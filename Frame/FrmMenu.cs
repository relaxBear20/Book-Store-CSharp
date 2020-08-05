


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjC.Frame
{
    public partial class FrmMenu : Form
    {
        private Employee EMPLOYEE = null;
        private frmLogin parent = null;
        public FrmMenu(Employee employee , frmLogin login)
        {
            this.parent = login;
            this.EMPLOYEE = employee;
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            CheckPermission();
            Utility.SetAllControlsFont(this.Controls);
        }
       
        private void CheckPermission()
        {
            if (EMPLOYEE.checkPermissionByRole("Admin")) LoadNewForm(new DashBoard());
            if (EMPLOYEE.checkPermissionByRole("Store Manager")) LoadNewForm(new ViewBookForm(this.EMPLOYEE,this));
            if (EMPLOYEE.checkPermissionByRole("Cashier")) LoadNewForm(new CreateBillForm(this.EMPLOYEE, this));
            // if (!EMPLOYEE.checkPermissionByName("Account")) mniAccount.Enabled = false;
            if (!EMPLOYEE.checkPermissionByName("Bill")) mniOrder.Enabled = false;
            if (!EMPLOYEE.checkPermissionByName("Book")) mniStoreage.Enabled = false;
            if (!EMPLOYEE.checkPermissionByRole("Admin")) mniDashboard.Enabled = false;


            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Account", "Read")) mniAccountList.Enabled = false;
            //if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Account", "Create")) mniNewAccount.Enabled = false;

            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Bill" , "Create")) mniRetail.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Bill", "Read")) mniBills.Enabled = false;

            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Book", "Read")) mniBookView.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Book", "Import")) mniBookImport.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Book", "Create")) mniBookAdd.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Author", "View")) mniAuthors.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Publisher", "View")) mniPublisher.Enabled = false;



            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Account", "List")) mniAccountList.Enabled = false;
            if (!EMPLOYEE.checkPermissionByNameOfPermisstion("Account", "Create")) mniNewAccount.Enabled = false;
        }
        public void LoadNewForm(Form form)
        {
            pnlFormDisplay.Controls.Clear();
            
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            pnlFormDisplay.Controls.Add(form);

            form.Show();
        }


        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewForm(new ViewBookForm(this.EMPLOYEE, this));
        }

        private void mniBills_Click(object sender, EventArgs e)
        {
            LoadNewForm(new ViewBillsForm(this.EMPLOYEE));
        }

        private void mniRetail_Click(object sender, EventArgs e)
        {
            LoadNewForm(new CreateBillForm(this.EMPLOYEE,this));
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewForm(new frmAddAccount(this.EMPLOYEE));
        }

        private void mniMyAccount_Click(object sender, EventArgs e)
        {
            LoadNewForm(new frmAddAccount(this.EMPLOYEE, this.EMPLOYEE));
        }

        private void mniAccountList_Click(object sender, EventArgs e)
        {
            LoadNewForm(new frmAccountList(this.EMPLOYEE));
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            this.Close();
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Visible = true;
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewForm(new PublisherView(this.EMPLOYEE));
        }

        private void authorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadNewForm(new ViewAuthorDetail(this.EMPLOYEE));
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewForm(new DashBoard());
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewForm(new ImportBookForm(0));
        }

        private void mniBookAdd_Click(object sender, EventArgs e)
        {
            LoadNewForm(new AddBookForm(this.EMPLOYEE,this));
        }
    }
}
