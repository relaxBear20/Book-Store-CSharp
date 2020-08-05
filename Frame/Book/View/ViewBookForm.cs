using prjC.Frame;
using System;
using System.Windows.Forms;

namespace prjC
{
    public partial class ViewBookForm : Form
    {
        private readonly Employee EMPLOYEE;
        private readonly FrmMenu menuForm;
        private readonly SearchBookPanel searchBookPanel;
        public ViewBookForm(Employee e, FrmMenu menuForm )
        {
            this.EMPLOYEE = e;
            this.menuForm = menuForm;
            InitializeComponent();
            this.searchBookPanel = new SearchBookPanel(this);
            panel1.Controls.Add(searchBookPanel);
        }

        public void DataGridViewSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var source = ((DataGridView)sender).Columns[e.ColumnIndex];
            if (source.Name.Equals("Detail"))
            {
                int bookID = Convert.ToInt32(searchBookPanel.dataGridViewSearchResult.Rows[e.RowIndex].Cells["BookID"].Value);
                UpdateGroupBoxBookDetails(bookID);
            }
            else if (source.Name.Equals("Edit"))
            {
                int bookID = Convert.ToInt32(searchBookPanel.dataGridViewSearchResult.Rows[e.RowIndex].Cells["BookID"].Value);
                menuForm.LoadNewForm(new EditBookForm(bookID, menuForm, EMPLOYEE));
            }
        }

        private void UpdateGroupBoxBookDetails(int bookID)
        {
            Book book = BookDAO.SelectBookByBookID(bookID);
            textBoxBookID.Text = book.BookID.ToString();
            textBoxTitle.Text = book.Title;
            textBoxAuthor.Text = book.AuthorName;
            textBoxPublisher.Text = book.PublisherName;
            dateTimePickerPublicationDate.Value = book.PublicationDate;
            textBoxCategoriesName.Text = book.CategoriesName;
            textBoxUnitPrice.Text = Utility.FormatMoney(book.UnitPrice);
            textBoxDescription.Text = book.Description;
            groupBoxBookDetails.Visible = true;
        }
    }
}
