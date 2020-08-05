using prjC.Frame;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prjC
{
    public partial class frmLogin : Form
    {

        public Employee EMPLOYEE { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee emp = Employee.getEmployeeByLogin(txtUsername.Text, txtPassword.Text);
            if (emp == null) MessageBox.Show("Login Failed!");
            else
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
                EMPLOYEE = emp;
                
                FrmMenu a = new FrmMenu(emp, this);
                a.Show();
                this.Visible = false;
            }

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
