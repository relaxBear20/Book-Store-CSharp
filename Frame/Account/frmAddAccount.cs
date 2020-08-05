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
    public partial class frmAddAccount : Form
    {
        private Employee EMPLOYEE;
        private Employee EditEmployee;
        private Boolean EditRoles = false;
        private string frmName = "Account";
        public frmAddAccount(Employee e)
        {
            this.EMPLOYEE = e;

            InitializeComponent();
            initAdd();
        }

        public frmAddAccount(Employee e, Employee EditEmployee)
        {
            this.EMPLOYEE = e;
            this.EditEmployee = EditEmployee;
            InitializeComponent();
            initEdit();
        }
        private void initEdit()
        {
            btnCreateRole.Hide();
            List<Role> roles = RoleList.GetRoleByID(EditEmployee.ID);
            lstRoles.DataSource = roles;
            lstRoles.DisplayMember = "RoleName";
            for (int i = 0; i < lstRoles.Items.Count; i++)
            {
                lstRoles.SetSelected(i, true);
            }


            txtAccName.Text = EditEmployee.AccName;
            txtAccPassword.Text = EditEmployee.AccPassword;
            txtEmail.Text = EditEmployee.Email;
            txtFirstName.Text = EditEmployee.FirstName;
            txtLastName.Text = EditEmployee.LastName;
            txtPhone.Text = EditEmployee.Phone;

            if (!EMPLOYEE.checkPermissionByNameOfPermisstion(this.frmName, "EditRole")){   btnNewRole.Enabled = false; btnEditRole.Enabled = false; }

            btnCreateAccount.Text = "Save";
            btnCreateAccount.Click += btnEdit_Click;
        }
        private void initAdd()
        {
            lstRoles.DataSource = RoleList.GetRoles();
            lstRoles.DisplayMember = "RoleName";
            lstRoles.SelectedItems.Clear();

            lstFeatures.DataSource = FeatureList.GetFeatures();
            lstFeatures.DisplayMember = "DisplayName";
            btnCreateAccount.Click += btnCreate_Click;

            btnEditRole.Hide();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            grbNewRole.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtRoleName.Text = "";
            lstFeatures.SelectedIndex = 0;
            grbNewRole.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Feature> features = new List<Feature>();
            foreach(object o in lstFeatures.SelectedItems)
            {
                Feature f = (Feature) o;
                features.Add(f);
            }
            string RoleID = Role.InsertRole(txtRoleName.Text);
            if(RoleID.Equals("failed"))
            {
                MessageBox.Show("Role Name existed!"); 
                return;
            }
            int result = FeatureList.InsertsFeaturesWithRoleID(RoleID, features);
            if (result != features.Count) { MessageBox.Show("Something went wrong! Cant add new Role"); return; }
            MessageBox.Show("Added \n Role: " + txtRoleName.Text + "\n RoleID: " + RoleID);

            List<Role> roles = RoleList.GetRoles();
            lstRoles.DataSource = roles;
            lstRoles.DisplayMember = "RoleName";
            lstRoles.Refresh();
        }

        private bool ValidCheck()
        {
            //TODO
            txtAccName.BackColor = Color.White;
            txtAccPassword.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtFirstName.BackColor = Color.White;
            txtLastName.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            bool result = true;
            if (txtAccName.Text.Trim().Equals(""))
            {
                txtAccName.BackColor = Color.Red;
                result = false;
            };
            if (txtAccPassword.Text.Trim().Equals(""))
            {
                txtAccPassword.BackColor = Color.Red;
                result = false;
            };
            if (txtEmail.Text.Trim().Equals(""))
            {
                txtEmail.BackColor = Color.Red;
                result = false;
            };
            if (txtFirstName.Text.Trim().Equals(""))
            {
                txtFirstName.BackColor = Color.Red;
                result = false;
            };
            if (txtLastName.Text.Trim().Equals(""))
            {
                txtLastName.BackColor = Color.Red;
                result = false;
            };
            if (txtPhone.Text.Trim().Equals(""))
            {
                txtPhone.BackColor = Color.Red;
                result = false;
            };
            return result;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(ValidCheck())
            {
                string AccName = txtAccName.Text.Trim();
                string AccPasswrod = txtAccPassword.Text.Trim();
                string AccEmail = txtEmail.Text.Trim();
                string FirstName = txtFirstName.Text.Trim();
                string LastName = txtLastName.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                List<Role> Roles = new List<Role>();
                foreach (object o in lstRoles.SelectedItems)
                {
                    Role f = (Role)o;
                    Roles.Add(f);
                }

                string AccID = Employee.InsertEmployee(AccName,AccPasswrod,FirstName,LastName,AccEmail,Phone);

                if(AccID.Equals("failed"))
                {
                    MessageBox.Show("ERROR \n Account Name existed!"); 
                    return;
                }
                int result = Employee.AddFeatures(AccID, Roles);
                if (result == 0) { MessageBox.Show("ERROR \n Insert failed"); return; }
                MessageBox.Show("SUCCESSFUL \n Account Added");
                txtAccName.Text = "";
                txtAccPassword.Text = "";
                txtEmail.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPhone.Text = "";
                txtRoleName.Text = "";
                lstRoles.SelectedItems.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidCheck())
            {
                string AccName = txtAccName.Text.Trim();
                string AccPasswrod = txtAccPassword.Text.Trim();
                string AccEmail = txtEmail.Text.Trim();
                string FirstName = txtFirstName.Text.Trim();
                string LastName = txtLastName.Text.Trim();
                string Phone = txtPhone.Text.Trim();
                List<Role> Roles = new List<Role>();
                if (!EMPLOYEE.checkPermissionByNameOfPermisstion(this.frmName, "EditRole")) Roles = EditEmployee.Roles;
                else
                {
                    foreach (object o in lstRoles.SelectedItems)
                    {
                        Role f = (Role)o;
                        Roles.Add(f);
                    }
                }
                

                int ResultEmployee =  Employee.UpdateEmployee(EditEmployee.ID, AccName, AccPasswrod, FirstName, LastName, AccEmail, Phone);
                int result =  Employee.UpdateFeatures(EditEmployee.ID, Roles);
                if (result == 0) MessageBox.Show("ERROR \n Edit failed");
                else MessageBox.Show("SUCCESSFUL \n Saved");
            }
        }
        private void btnCancelCreateAcc_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            fglFeaturesDisplay.Controls.Clear();
             

            List<Role> Roles = new List<Role>();
            foreach (object o in lstRoles.SelectedItems)
            {
                Role f = (Role) o;
                Roles.Add(f);
            }

            List<Feature> features = FeatureList.GetFeaturesByListOfRole(Roles);
            foreach (Feature f in features)
            {
                Label lb = new Label();
                lb.Text = f.Name + "_" + f.Code;
                lb.BackColor = Color.White;
                lb.AutoSize = true;
                fglFeaturesDisplay.Controls.Add(lb);
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {

            List<Role> roles = RoleList.GetRoles();
           
            
            lstRoles.DataSource = roles;
            lstRoles.DisplayMember = "RoleName";
            lstRoles.ClearSelected();
            foreach (Role item in EditEmployee.Roles)
            { 
                lstRoles.SetSelected( lstRoles.Items.IndexOf(item) , true );
            }

            lstRoles.Refresh();


        }
    }
}
