using System;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class ImportBookForm : Form
    {
        private readonly int bookID;
        private readonly SearchBookPanel searchBookPanel;
        public ImportBookForm(int bookID)
        {
            InitializeComponent();
            this.bookID = bookID;
            searchBookPanel = new SearchBookPanel(this);
            Controls.Add(searchBookPanel);
        }

        private void ImportBookForm_Load(object sender, EventArgs e)
        {
            if (bookID != 0)
            {
                UpdateGroupBoxBookDetails(bookID);
                UpdateGroupBoxImportDetails(bookID);
            }
        }

        public void DataGridViewSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var source = ((DataGridView)sender).Columns[e.ColumnIndex];
            if (source.Name.Equals("Import"))
            {
                int bookID = Convert.ToInt32(searchBookPanel.dataGridViewSearchResult.Rows[e.RowIndex].Cells["BookID"].Value);
                UpdateGroupBoxBookDetails(bookID);
                UpdateGroupBoxImportDetails(bookID);
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

        private void UpdateGroupBoxImportDetails(int bookID)
        {
            int unitsInStock = BookDAO.SelectUnitsInStock(bookID);
            textBoxUnitsInStock.Text = unitsInStock.ToString();
            groupBoxImportDetails.Visible = true;
        }

        private void TextBoxImportUnits_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int importUnits = int.Parse(textBoxImportUnits.Text.Trim());
                if (importUnits <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                labelImportUnitsMessage.ForeColor = Color.Red;
                labelImportUnitsMessage.Text = "Import Units is invalid";
                UpdateButtonImport();
                return;
            }
            labelImportUnitsMessage.ForeColor = Color.Green;
            labelImportUnitsMessage.Text = "Import Units is OK";
            UpdateButtonImport();
        }

        private void UpdateButtonImport()
        {
            if (IsReadyToImport())
            {
                buttonImport.Enabled = true;
            }
            else
            {
                buttonImport.Enabled = false;
            }
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            int bookID = Convert.ToInt32(textBoxBookID.Text.Trim());
            int importUnits = Convert.ToInt32(textBoxImportUnits.Text.Trim());
            int numRows = BookDAO.ImportBook(bookID, importUnits);
            if (numRows == 1)
            {
                MessageBox.Show("Book Imported Successful!");
            }
            textBoxImportUnits.Text = "";
            UpdateGroupBoxImportDetails(bookID);
        }

        private bool IsReadyToImport()
        {
            return labelImportUnitsMessage.ForeColor == Color.Green;
        }
    }
}
