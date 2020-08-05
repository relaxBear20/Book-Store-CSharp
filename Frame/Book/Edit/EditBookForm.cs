using prjC.Frame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class EditBookForm : Form
    {
        private readonly Employee EMPLOYEE;
        private readonly int bookID;
        private readonly FrmMenu frmMenu;
        private List<Author> authors;
        private List<Publisher> publishers;
        private List<Category> categories;
        public EditBookForm(int bookID,FrmMenu frmMenu  , Employee e)
        {
            InitializeComponent();
            this.bookID = bookID;
            this.frmMenu = frmMenu;
            EMPLOYEE = e;
            authors = AuthorDAO.SelectAllAuthors();
            publishers = PublisherDAO.SelectAllPublishers();
            categories = CategoryDAO.SelectAllCategories();
        }

        private void EditBookForm_Load(object sender, System.EventArgs e)
        {
            UpdateComboBoxAuthors(0);
            UpdateComboBoxPublishers(0);
            UpdateCheckedListBoxCategories(0);
            Book book = BookDAO.SelectBookByBookID(bookID);
            textBoxTitle.Text = book.Title;
            comboBoxAuthors.SelectedItem = book.AuthorName;
            comboBoxPublishers.SelectedItem = book.PublisherName;
            dateTimePickerPublicationDate.Value = book.PublicationDate;
            for (int index = 0; index < checkedListBoxCategories.Items.Count; index++)
            {
                checkedListBoxCategories.SetItemChecked(index, false);
            }
            List<Category> categories = CategoryDAO.SelectCategoriesByBookID(bookID);
            for (int index = 0; index < checkedListBoxCategories.Items.Count; index++)
            {
                string categoryName = checkedListBoxCategories.Items[index].ToString();
                foreach (Category category in categories)
                {
                    if (category.CategoryName.Equals(categoryName))
                    {
                        checkedListBoxCategories.SetItemChecked(index, true);
                        break;
                    }
                }
            }
            textBoxUnitPrice.Text = ((int)book.UnitPrice).ToString();
            textBoxDescription.Text = book.Description;
        }

        public void UpdateComboBoxAuthors(int authorID)
        {
            comboBoxAuthors.Items.Clear();
            authors = AuthorDAO.SelectAllAuthors();
            for (int index = 0; index < authors.Count; index++)
            {
                Author author = authors[index];
                comboBoxAuthors.Items.Add(author.FirstName + " " + author.LastName);
                if (author.AuthorID == authorID)
                {
                    comboBoxAuthors.SelectedIndex = index;
                }
            }
        }

        public void UpdateComboBoxPublishers(int publisherID)
        {
            comboBoxPublishers.Items.Clear();
            publishers = PublisherDAO.SelectAllPublishers();
            for (int index = 0; index < publishers.Count; index++)
            {
                Publisher publisher = publishers[index];
                comboBoxPublishers.Items.Add(publisher.PublisherName);
                if (publisher.PublisherID == publisherID)
                {
                    comboBoxPublishers.SelectedIndex = index;
                }
            }
        }

        public void UpdateCheckedListBoxCategories(int categoryID)
        {
            checkedListBoxCategories.Items.Clear();
            categories = CategoryDAO.SelectAllCategories();
            for (int index = 0; index < categories.Count; index++)
            {
                Category category = categories[index];
                checkedListBoxCategories.Items.Add(category.CategoryName);
                if (category.CategoryID == categoryID)
                {
                    checkedListBoxCategories.SetItemChecked(index, true);
                }
            }
        }

        public void ClearAddNewPanel()
        {
            panelAddNew.Controls.Clear();
        }

        private void ButtonAddNewAuthor_Click(object sender, System.EventArgs e)
        {
            panelAddNew.Controls.Clear();
            AddAuthorForm addAuthorForm = new AddAuthorForm(this)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None
            };
            panelAddNew.Controls.Add(addAuthorForm);
            addAuthorForm.Show();
        }

        private void ButtonAddNewPublisher_Click(object sender, System.EventArgs e)
        {
            panelAddNew.Controls.Clear();
            AddPublisherForm addPublisherForm = new AddPublisherForm(this)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None
            };
            panelAddNew.Controls.Add(addPublisherForm);
            addPublisherForm.Show();
        }

        private void ButtonAddNewCategory_Click(object sender, System.EventArgs e)
        {
            panelAddNew.Controls.Clear();
            AddCategoryForm addCategoryForm = new AddCategoryForm(this)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None
            };
            panelAddNew.Controls.Add(addCategoryForm);
            addCategoryForm.Show();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!IsReadyToEdit())
            {
                return;
            }
            string title = textBoxTitle.Text.Trim();
            int authorID = authors[comboBoxAuthors.SelectedIndex].AuthorID;
            int publisherID = publishers[comboBoxPublishers.SelectedIndex].PublisherID;
            DateTime publicationDate = dateTimePickerPublicationDate.Value;
            List<int> categoriesID = new List<int>(0);
            foreach (string categoryName in checkedListBoxCategories.CheckedItems)
            {
                int selectedCategoryID = categories[checkedListBoxCategories.Items.IndexOf(categoryName)].CategoryID;
                categoriesID.Add(selectedCategoryID);
            }
            decimal unitPrice = Convert.ToDecimal(textBoxUnitPrice.Text.Trim().ToString());
            string description = textBoxDescription.Text.ToString();
            int numRows = BookDAO.EditBook(title, authorID, publisherID, publicationDate, categoriesID, unitPrice, description, bookID);
            if (numRows == categoriesID.Count)
            {
                MessageBox.Show("Book Edited Successful!");
                frmMenu.LoadNewForm(new ViewBookForm(EMPLOYEE,frmMenu));
            }
        }

        private bool IsReadyToEdit()
        {
            return labelTitleMessage.ForeColor == Color.Green
                && labelAuthorMessage.ForeColor == Color.Green
                && labelPublisherMessage.ForeColor == Color.Green
                && labelPublicationDateMessage.ForeColor == Color.Green
                && labelCategoriesMessage.ForeColor == Color.Green
                && labelUnitPriceMessage.ForeColor == Color.Green
                && labelDescriptionMessage.ForeColor == Color.Green;
        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            if (title.Length == 0)
            {
                labelTitleMessage.ForeColor = Color.Red;
                labelTitleMessage.Text = "Title is required";
                UpdateButtonEdit();
                return;
            }
            labelTitleMessage.ForeColor = Color.Green;
            labelTitleMessage.Text = "Title is OK";
            UpdateButtonEdit();
        }

        private void ComboBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxAuthors.SelectedIndex;
            if (selectedIndex == -1)
            {
                labelAuthorMessage.ForeColor = Color.Red;
                labelAuthorMessage.Text = "Please select an author";
                UpdateButtonEdit();
                return;
            }
            labelAuthorMessage.ForeColor = Color.Green;
            labelAuthorMessage.Text = "Author is selected";
            UpdateButtonEdit();
        }

        private void ComboBoxPublishers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxPublishers.SelectedIndex;
            if (selectedIndex == -1)
            {
                labelPublisherMessage.ForeColor = Color.Red;
                labelPublisherMessage.Text = "Please select a publisher";
                UpdateButtonEdit();
                return;
            }
            labelPublisherMessage.ForeColor = Color.Green;
            labelPublisherMessage.Text = "Publisher is selected";
            UpdateButtonEdit();
        }

        private void DateTimePickerPublicationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime publicationDate = dateTimePickerPublicationDate.Value;
            publicationDate = new DateTime(publicationDate.Year, publicationDate.Month, publicationDate.Day, 0, 0, 0);
            if (publicationDate > DateTime.Today)
            {
                labelPublicationDateMessage.ForeColor = Color.Red;
                labelPublicationDateMessage.Text = "Publication Date is invalid";
                UpdateButtonEdit();
                return;
            }
            labelPublicationDateMessage.ForeColor = Color.Green;
            labelPublicationDateMessage.Text = "Publication Date is OK";
            UpdateButtonEdit();
        }

        private void CheckedListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxCategories.CheckedItems.Count == 0)
            {
                labelCategoriesMessage.ForeColor = Color.Red;
                labelCategoriesMessage.Text = "Select at least 1 category";
                UpdateButtonEdit();
                return;
            }
            labelCategoriesMessage.ForeColor = Color.Green;
            labelCategoriesMessage.Text = "Categories is selected";
            UpdateButtonEdit();
        }

        private void TextBoxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            string unitPrice = textBoxUnitPrice.Text.Trim();
            if (unitPrice.Length == 0)
            {
                labelUnitPriceMessage.ForeColor = Color.Red;
                labelUnitPriceMessage.Text = "Unit Price is required";
                UpdateButtonEdit();
                return;
            }
            try
            {
                int result = (int)decimal.Parse(unitPrice);
                if (result < 1000)
                {
                    throw new FormatException();
                }
            }
            catch (Exception)
            {
                labelUnitPriceMessage.ForeColor = Color.Red;
                labelUnitPriceMessage.Text = "Unit Price is invalid";
                UpdateButtonEdit();
                return;
            }
            labelUnitPriceMessage.ForeColor = Color.Green;
            labelUnitPriceMessage.Text = "Unit Price is OK";
            UpdateButtonEdit();
        }

        private void TextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text.Trim();
            if (description.Length == 0)
            {
                labelDescriptionMessage.ForeColor = Color.Green;
                labelDescriptionMessage.Text = "Description is not required";
                UpdateButtonEdit();
                return;
            }
            labelDescriptionMessage.ForeColor = Color.Green;
            labelDescriptionMessage.Text = "Description is OK";
            UpdateButtonEdit();
        }

        private void UpdateButtonEdit()
        {
            if (IsReadyToEdit())
            {
                buttonEdit.Enabled = true;
            }
            else
            {
                buttonEdit.Enabled = false;
            }
        }
    }
}
