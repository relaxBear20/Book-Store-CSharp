
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
    public partial class PublisherView : Form
    {
        private readonly Employee EMPLOYEE;
        public PublisherView(Employee e)
        {
            this.EMPLOYEE = e;
            InitializeComponent();
        }


        private void Publisher_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            

            // add(string nameColumn,string HeaderText)
            dataGridView1.Columns.Add("id", "Publisher ID");
            //id 1 - NameColumn id 2 - property of Member
            dataGridView1.Columns["id"].DataPropertyName = "PublisherID";

            dataGridView1.Columns.Add("name", "Publisher Name");
            dataGridView1.Columns["name"].DataPropertyName = "PublisherName";
                   
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns["Address"].DataPropertyName = "Address";

            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns["Phone"].DataPropertyName = "Phone";
            dataGridView1.Columns.Add("Fax", "Fax");
            dataGridView1.Columns["Fax"].DataPropertyName = "Fax";
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns["Email"].DataPropertyName = "Email";
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "View book";
            btnColumn.Name = "btnviewBook";
            btnColumn.Text = "View book";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnColumn);
            dataGridView1.DataSource = PublisherDAO.getAllPublisher();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text == "" && txtSearchAddress.Text == ""){
                dataGridView1.DataSource = PublisherDAO.getAllPublisher();
            }
            else
            {
                dataGridView1.DataSource = PublisherDAO.getPublisherByNameAndAddress(txtSearchName.Text, txtSearchAddress.Text);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderObj = (DataGridView)sender;
            if (senderObj.Columns[e.ColumnIndex].Name == "btnviewBook" && e.RowIndex != -1)
            {               
                int id= (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;            
                dataGridView2.Visible = true;

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns.Clear();

                dataGridView2.Columns.Add("Title", "Title");
                dataGridView2.Columns["Title"].DataPropertyName = "Title";
                dataGridView2.Columns.Add("AuthorName", "Author Name");
                dataGridView2.Columns["AuthorName"].DataPropertyName = "AuthorName";
                dataGridView2.Columns.Add("PublicationDate", "Publication Date");
                dataGridView2.Columns["PublicationDate"].DataPropertyName = "PublicationDate";
                dataGridView2.Columns.Add("UnitPrice", "UnitPrice");
                dataGridView2.Columns["UnitPrice"].DataPropertyName = "UnitPrice";
                // add(string nameColumn,string HeaderText)
                dataGridView2.Columns.Add("UnitsInStock", "UnitsInStock");
                //id 1 - NameColumn id 2 - property of Member
                dataGridView2.Columns["UnitsInStock"].DataPropertyName = "UnitsInStock";

                dataGridView2.DataSource = PublisherDAO.getBookByPublisherID(id);
           
   
            }
        }

    
        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
    
        }

        private void btnOpenCreate_Click(object sender, EventArgs e)
        {        
            groupBox1.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            List<string> listNameInSQL = PublisherDAO.getListPublisherName();
            if( txtName.Text == "" || txtAddress.Text =="")
            {
                MessageBox.Show("Name, Address aren't blank. ");
            }
            else
            {
                Boolean flag = true;
                foreach (string name in listNameInSQL)
                {
                    if (txtName.Text == name)
                    {
                        MessageBox.Show("Publisher name existed. ");
                        flag = false;
                        break;
                    }
                }
                if(flag == true)
                {
                    int check = PublisherDAO.insertPublisher(txtName.Text, txtAddress.Text, txtPhone.Text, txtFax.Text, txtEmail.Text);
                    if (check>0)
                    {
                        MessageBox.Show("Add new Publisher successfull.");
                        dataGridView1.DataSource = PublisherDAO.getAllPublisher();
                        txtName.Text = "";
                        txtAddress.Text = "";
                        txtEmail.Text = "";
                        txtPhone.Text = "";
                        txtFax.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Add error.");
                    }
                }
            }     
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
