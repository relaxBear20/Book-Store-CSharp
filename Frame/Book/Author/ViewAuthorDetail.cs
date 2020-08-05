

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
    public partial class ViewAuthorDetail : Form
    {
        private readonly Employee EMPLOYEE;
        public ViewAuthorDetail(Employee e)
        {
            this.EMPLOYEE = e;
            InitializeComponent();
            loadData();
        }

        private void tbAuthorName_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            dgvViewAuthor.Columns.Clear();
            dgvViewAuthor.DataSource = new AuthorDAO().getAuthorsByName(tbAuthorName.Text);
            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Detail",
                Name = "Detail"
            };
            dgvViewAuthor.Columns.Add(detailButtonColumn);
            dgvViewAuthor.Refresh();
        }

        int currentIndex = -1;

        private void dgvViewAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != currentIndex)
            {
                currentIndex = e.RowIndex;
                txtID.Text = dgvViewAuthor["AuthorID", e.RowIndex].Value.ToString();
                txtAbout.Text = dgvViewAuthor["About", e.RowIndex].Value.ToString();
                txtFirstName.Text = dgvViewAuthor["FirstName", e.RowIndex].Value.ToString();
                txtLastName.Text = dgvViewAuthor["LastName", e.RowIndex].Value.ToString();
                int count = new AuthorDAO().getBookByAuthorID(txtID.Text).Count;
                txtTotalOfBooks.Text = count.ToString();
                dgvBook.Refresh();
                List<Book> lst = new AuthorDAO().getBookByAuthorID(txtID.Text);
                
                dgvBook.DataSource = lst;
            }
        }

        private void btnViewBook_Click(object sender, EventArgs e)
        {
            if(txtID.Text.Trim().Length > 0)
            {
                
            }
        }

        private void ViewAuthorDetail_Load(object sender, EventArgs e)
        {

        }

        private void dgvViewAuthor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvViewAuthor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
