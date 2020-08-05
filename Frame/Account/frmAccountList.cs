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
    public partial class frmAccountList : Form
    {
        private Employee EMPLOYEE;
        private List<Employee> DataGridData = new List<Employee>();
        public frmAccountList(Employee e)
        {
            this.EMPLOYEE = e;
            InitializeComponent();
            
            DataTable dt = AccountDAO.GetRoles();
            DataRow dr = dt.NewRow();
            dr["RoleName"] = "--All--";
            dt.Rows.InsertAt(dr, 0); 
            cbxRole.DataSource = dt;
            cbxRole.DisplayMember = "RoleName";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            SearchForAccount();
        }

        private void txtAccName_TextChanged(object sender, EventArgs e)
        {
            SearchForAccount();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            SearchForAccount();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            SearchForAccount();
        }
        private void cbxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchForAccount();
        }
        private void SearchForAccount()
        {
            string FName = txtFirstName.Text.Trim();
            string LName = txtLastName.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string AccountName = txtAccName.Text.Trim();
            Role role = new Role();
            if (cbxRole.SelectedIndex != 0)
            {
                DataTable dtable = (DataTable)cbxRole.DataSource;
                role.ID = dtable.Rows[cbxRole.SelectedIndex][0].ToString();
                role.RoleName = dtable.Rows[cbxRole.SelectedIndex][1].ToString();
            }
            else role = null;
            List<Employee> lst = EmployeeList.GetAccountBy(FName, LName, AccountName, Email, Phone, role);

            DataGridData = lst;
            var bind = lst.Select(i => new {AccountName = i.AccName , Name = i.FirstName + " " + i.LastName , PhoneNumber = i.Phone , Email = i.Email , Roles = i.getRolesToString()  });

            dgvResult.Columns.Clear();
            dgvResult.DataSource = bind.ToList() ;
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Detail";
            btnEdit.Name = "detailButton";
            btnEdit.Text = "Detail";
            btnEdit.UseColumnTextForButtonValue = true;
            dgvResult.Columns.Add(btnEdit);

           
            dgvResult.Refresh();
        }
        private void LoadNewForm(Form form)
        {
            pnlDisplay.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            pnlDisplay.Controls.Add(form);

            form.Show();
        }
        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderObj = (DataGridView)sender;
            if (senderObj.Columns[e.ColumnIndex].Name == "detailButton" && e.RowIndex != -1)
            {
                Employee current = DataGridData[e.RowIndex];

                frmAddAccount frmDetail = new frmAddAccount(this.EMPLOYEE, current);
                LoadNewForm(frmDetail);
               
            }

            
        }

        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.dgvResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResult.AutoResizeColumns();
        }
    }
}
