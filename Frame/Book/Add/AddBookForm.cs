using prjC.Frame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class AddBookForm : Form
    {
        private readonly Employee EMPLOYEE;
        private readonly FrmMenu menuForm;
        private List<Author> authors;
        private List<Publisher> publishers;
        private List<Category> categories;
        public AddBookForm(Employee e, FrmMenu menuForm)
        {
            this.EMPLOYEE = e;
            this.menuForm = menuForm;
            InitializeComponent();
            publishers = PublisherDAO.SelectAllPublishers();
            categories = CategoryDAO.SelectAllCategories();
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            comboBoxAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            UpdateComboBoxAuthors(0);
            comboBoxPublishers.DropDownStyle = ComboBoxStyle.DropDownList;
            UpdateComboBoxPublishers(0);
            checkedListBoxCategories.CheckOnClick = true;
            UpdateCheckedListBoxCategories(0);
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

        private void ButtonAddNewAuthor_Click(object sender, EventArgs e)
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

        private void ButtonAddNewPublisher_Click(object sender, EventArgs e)
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

        private void ButtonAddNewCategory_Click(object sender, EventArgs e)
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
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
            string description = textBoxDescription.Text.Trim();
            int bookID = BookDAO.AddNewBook(title, authorID, publisherID, publicationDate, categoriesID, unitPrice, description);
            if (bookID > 0)
            {
                MessageBox.Show("Book Added Successful!");
                if (MessageBox.Show("Do you want to import it now?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    menuForm.LoadNewForm(new ImportBookForm(bookID));
                }
                else
                {
                    ResetForm();
                }
            }
        }

        private void ResetForm()
        {
            textBoxTitle.Text = "";
            comboBoxAuthors.SelectedIndex = -1;
            comboBoxPublishers.SelectedIndex = -1;
            dateTimePickerPublicationDate.Value = DateTime.Today;
            for (int index = 0; index < checkedListBoxCategories.Items.Count; index++)
            {
                checkedListBoxCategories.SetItemChecked(index, false);
            }
            textBoxUnitPrice.Text = "";
            textBoxDescription.Text = "";
        }

        private bool IsReadyToAdd()
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
                UpdateAddButton();
                return;
            }
            List<string> booksTitle = BookDAO.SelectAllTitle();
            foreach (string titles in booksTitle)
            {
                if (titles.Equals(title))
                {
                    labelTitleMessage.ForeColor = Color.Red;
                    labelTitleMessage.Text = "Title already existed";
                    UpdateAddButton();
                    return;
                }
            }
            labelTitleMessage.ForeColor = Color.Green;
            labelTitleMessage.Text = "Title is OK";
            UpdateAddButton();
        }

        private void ComboBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxAuthors.SelectedIndex;
            if (selectedIndex == -1)
            {
                labelAuthorMessage.ForeColor = Color.Red;
                labelAuthorMessage.Text = "Please select an author";
                UpdateAddButton();
                return;
            }
            labelAuthorMessage.ForeColor = Color.Green;
            labelAuthorMessage.Text = "Author is selected";
            UpdateAddButton();
        }

        private void ComboBoxPublishers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxPublishers.SelectedIndex;
            if (selectedIndex == -1)
            {
                labelPublisherMessage.ForeColor = Color.Red;
                labelPublisherMessage.Text = "Please select a publisher";
                UpdateAddButton();
                return;
            }
            labelPublisherMessage.ForeColor = Color.Green;
            labelPublisherMessage.Text = "Publisher is selected";
            UpdateAddButton();
        }

        private void DateTimePickerPublicationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime publicationDate = dateTimePickerPublicationDate.Value;
            publicationDate = new DateTime(publicationDate.Year, publicationDate.Month, publicationDate.Day, 0, 0, 0);
            if (publicationDate > DateTime.Today)
            {
                labelPublicationDateMessage.ForeColor = Color.Red;
                labelPublicationDateMessage.Text = "Publication Date is invalid";
                UpdateAddButton();
                return;
            }
            labelPublicationDateMessage.ForeColor = Color.Green;
            labelPublicationDateMessage.Text = "Publication Date is OK";
            UpdateAddButton();
        }

        private void CheckedListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxCategories.CheckedItems.Count == 0)
            {
                labelCategoriesMessage.ForeColor = Color.Red;
                labelCategoriesMessage.Text = "Select at least 1 category";
                UpdateAddButton();
                return;
            }
            labelCategoriesMessage.ForeColor = Color.Green;
            labelCategoriesMessage.Text = "Categories is selected";
            UpdateAddButton();
        }

        private void TextBoxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            string unitPrice = textBoxUnitPrice.Text.Trim();
            if (unitPrice.Length == 0)
            {
                labelUnitPriceMessage.ForeColor = Color.Red;
                labelUnitPriceMessage.Text = "Unit Price is required";
                UpdateAddButton();
                return;
            }
            try
            {
                int result = int.Parse(unitPrice);
                if (result < 1000)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                labelUnitPriceMessage.ForeColor = Color.Red;
                labelUnitPriceMessage.Text = "Unit Price is invalid";
                UpdateAddButton();
                return;
            }
            labelUnitPriceMessage.ForeColor = Color.Green;
            labelUnitPriceMessage.Text = "Unit Price is OK";
            UpdateAddButton();
        }

        private void TextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text.Trim();
            if (description.Length == 0)
            {
                labelDescriptionMessage.ForeColor = Color.Green;
                labelDescriptionMessage.Text = "Description is not required";
                UpdateAddButton();
                return;
            }
            labelDescriptionMessage.ForeColor = Color.Green;
            labelDescriptionMessage.Text = "Description is OK";
            UpdateAddButton();
        }

        private void UpdateAddButton()
        {
            if (IsReadyToAdd())
            {
                buttonAdd.Enabled = true;
            }
            else
            {
                buttonAdd.Enabled = false;
            }
        }
    }
}
