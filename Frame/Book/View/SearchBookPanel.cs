using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    class SearchBookPanel : Panel
    {
        public readonly DataGridView dataGridViewSearchResult;

        private readonly GroupBox groupBox;
        private readonly Label labelTitle;
        private readonly TextBox textBoxTitle;
        private readonly Label labelAuthor;
        private readonly ComboBox comboBoxAuthors;
        private readonly Label labelPublisher;
        private readonly ComboBox comboBoxPublishers;
        private readonly Label labelCategories;
        private readonly CheckedListBox checkedListBoxCategories;
        private readonly Label labelPublicationDate;
        private readonly ComboBox comboBoxPublicationDate;
        private readonly Label labelMonth;
        private readonly ComboBox comboBoxMonth;
        private readonly Label labelYear;
        private readonly NumericUpDown numericUpDownYear;
        private readonly Label labelSearchResult;

        private readonly Form containerForm;
        private readonly List<Author> authors;
        private readonly List<Publisher> publishers;
        private readonly List<Category> categories;
        public SearchBookPanel(Form containerForm)
        {
            this.containerForm = containerForm;
            authors = AuthorDAO.SelectAllAuthors();
            publishers = PublisherDAO.SelectAllPublishers();
            categories = CategoryDAO.SelectAllCategories();
            Size = new Size(1205, 265);
            groupBox = new GroupBox()
            {
                Text = "Search Book",
                Location = new Point(12, 12),
                Size = new Size(1190, 250)
            };
            labelTitle = new Label()
            {
                Text = "Title",
                AutoSize = true,
                Location = new Point(6, 23),
                Size = new Size(27, 13)
            };
            textBoxTitle = new TextBox()
            {
                Location = new Point(69, 19),
                Size = new Size(175, 20)
            };
            labelAuthor = new Label()
            {
                Text = "Author",
                AutoSize = true,
                Location = new Point(6, 49),
                Size = new Size(38, 13)
            };
            comboBoxAuthors = new ComboBox()
            {
                Location = new Point(69, 46),
                Size = new Size(175, 21)
            };
            labelPublisher = new Label()
            {
                Text = "Publisher",
                AutoSize = true,
                Location = new Point(6, 76),
                Size = new Size(30, 13)
            };
            comboBoxPublishers = new ComboBox()
            {
                Location = new Point(69, 73),
                Size = new Size(175, 21)
            };
            labelCategories = new Label()
            {
                Text = "Categories",
                AutoSize = true,
                Location = new Point(6, 103),
                Size = new Size(57, 13)
            };
            checkedListBoxCategories = new CheckedListBox()
            {
                ScrollAlwaysVisible = true,
                Location = new Point(69, 103),
                Size = new Size(175, 94)
            };
            labelPublicationDate = new Label()
            {
                Text = "Publication Date",
                AutoSize = true,
                Location = new Point(6, 204),
                Size = new Size(85, 13)
            };
            comboBoxPublicationDate = new ComboBox()
            {
                Location = new Point(9, 221),
                Size = new Size(82, 21)
            };
            labelMonth = new Label()
            {
                Text = "Month",
                AutoSize = true,
                Location = new Point(97, 204),
                Size = new Size(37, 13)
            };
            comboBoxMonth = new ComboBox()
            {
                Location = new Point(97, 221),
                Size = new Size(72, 21)
            };
            labelYear = new Label()
            {
                Text = "Year",
                AutoSize = true,
                Location = new Point(172, 204),
                Size = new Size(29, 13)
            };
            numericUpDownYear = new NumericUpDown()
            {
                Location = new Point(175, 222),
                Size = new Size(69, 20)
            };
            labelSearchResult = new Label()
            {
                Text = "Search Result",
                AutoSize = true,
                Location = new Point(250, 16),
                Size = new Size(74, 13)
            };
            dataGridViewSearchResult = new DataGridView()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                Location = new Point(253, 32),
                Size = new Size(600, 210)
            };
            AddControls();
            AddItemsToComboBoxAuthors();
            AddItemsToComboBoxPublishers();
            AddItemsToCheckedListBoxCategories();
            AddItemsToComboBoxPublicationDate();
            AddItemsToComboBoxMonth();
            AddItemsToNumericUpDownYear();
            AddEventsToControls();
            UpdateDataGridViewSearchResult();
        }

        private void AddControls()
        {
            AddGroupBox();
        }

        private void AddGroupBox()
        {
            AddControlsToGroupBox(groupBox);
            Controls.Add(groupBox);
        }

        private void AddControlsToGroupBox(GroupBox groupBox)
        {
            groupBox.Controls.Add(labelTitle);
            groupBox.Controls.Add(textBoxTitle);
            groupBox.Controls.Add(labelAuthor);
            groupBox.Controls.Add(comboBoxAuthors);
            groupBox.Controls.Add(labelPublisher);
            groupBox.Controls.Add(comboBoxPublishers);
            groupBox.Controls.Add(labelCategories);
            groupBox.Controls.Add(checkedListBoxCategories);
            groupBox.Controls.Add(labelPublicationDate);
            groupBox.Controls.Add(comboBoxPublicationDate);
            groupBox.Controls.Add(labelMonth);
            groupBox.Controls.Add(comboBoxMonth);
            groupBox.Controls.Add(labelYear);
            groupBox.Controls.Add(numericUpDownYear);
            groupBox.Controls.Add(labelSearchResult);
            groupBox.Controls.Add(dataGridViewSearchResult);
        }

        private void AddItemsToComboBoxAuthors()
        {
            comboBoxAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAuthors.Items.Add("All Authors");
            foreach (Author author in authors)
            {
                comboBoxAuthors.Items.Add(author.FirstName + " " + author.LastName);
            }
            comboBoxAuthors.SelectedIndex = 0;
        }

        private void AddItemsToComboBoxPublishers()
        {
            comboBoxPublishers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPublishers.Items.Add("All Publishers");
            foreach (Publisher publisher in publishers)
            {
                comboBoxPublishers.Items.Add(publisher.PublisherName);
            }
            comboBoxPublishers.SelectedIndex = 0;
        }

        private void AddItemsToCheckedListBoxCategories()
        {
            checkedListBoxCategories.CheckOnClick = true;
            foreach (Category category in categories)
            {
                checkedListBoxCategories.Items.Add(category.CategoryName);
            }
        }

        private void AddItemsToComboBoxPublicationDate()
        {
            comboBoxPublicationDate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPublicationDate.Items.Add("All Dates");
            comboBoxPublicationDate.Items.Add("During");
            comboBoxPublicationDate.Items.Add("Before");
            comboBoxPublicationDate.Items.Add("After");
            comboBoxPublicationDate.SelectedIndex = 0;
        }

        private void AddItemsToComboBoxMonth()
        {
            comboBoxMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMonth.Items.AddRange(new[] { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            comboBoxMonth.SelectedIndex = 0;
        }

        private void AddItemsToNumericUpDownYear()
        {
            numericUpDownYear.Minimum = BookDAO.SelectMinPublicationYear();
            numericUpDownYear.Maximum = BookDAO.SelectMaxPublicationYear();
            numericUpDownYear.Value = numericUpDownYear.Maximum;
            numericUpDownYear.ReadOnly = true;
        }


        private void UpdateDataGridViewSearchResult()
        {
            dataGridViewSearchResult.DataSource = null;
            dataGridViewSearchResult.Rows.Clear();
            dataGridViewSearchResult.Columns.Clear();
            dataGridViewSearchResult.AutoGenerateColumns = false;
            AddColumnsToDataGridViewSearchResult();
            string title = textBoxTitle.Text.Trim();
            int authorID = GetSelectedAuthorID();
            int publisherID = GetSelectedPublisherID();
            List<int> categoriesID = GetSelectedCategoriesID();
            PublicationDateCondition pdc = GetPublicationDateCondition();
            List<Book> books = BookDAO.SearchBooks(title, authorID, publisherID, categoriesID, pdc);
            dataGridViewSearchResult.DataSource = books;
        }

        private void AddColumnsToDataGridViewSearchResult()
        {
            dataGridViewSearchResult.Columns.Add("BookID", "BookID");
            dataGridViewSearchResult.Columns["BookID"].DataPropertyName = "BookID";
            dataGridViewSearchResult.Columns["BookID"].Visible = false;
            dataGridViewSearchResult.Columns.Add("Title", "Title");
            dataGridViewSearchResult.Columns["Title"].DataPropertyName = "Title";
            dataGridViewSearchResult.Columns.Add("AuthorName", "AuthorName");
            dataGridViewSearchResult.Columns["AuthorName"].DataPropertyName = "AuthorName";
            dataGridViewSearchResult.Columns.Add("PublisherName", "PublisherName");
            dataGridViewSearchResult.Columns["PublisherName"].DataPropertyName = "PublisherName";
            dataGridViewSearchResult.Columns.Add("CategoriesName", "CategoriesName");
            dataGridViewSearchResult.Columns["CategoriesName"].DataPropertyName = "CategoriesName";
            dataGridViewSearchResult.Columns.Add("PublicationDate", "PublicationDate");
            dataGridViewSearchResult.Columns["PublicationDate"].DataPropertyName = "PublicationDate";
            dataGridViewSearchResult.Columns["PublicationDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DataGridViewButtonColumn addButtonColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Add",
                Name = "Add"
            };
            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Detail",
                Name = "Detail"
            };
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Edit",
                Name = "Edit"
            };
            DataGridViewButtonColumn importButtonColumn = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Text = "Import",
                Name = "Import"
            };
            if (containerForm is ViewBookForm)
            {
                dataGridViewSearchResult.Columns.Add(detailButtonColumn);
                dataGridViewSearchResult.Columns.Add(editButtonColumn);
            }
            else if (containerForm is CreateBillForm)
            {
                dataGridViewSearchResult.Columns.Add(addButtonColumn);
            }
            else if (containerForm is ImportBookForm)
            {
                dataGridViewSearchResult.Columns.Add(importButtonColumn);
            }
        }

        private int GetSelectedAuthorID()
        {
            if (comboBoxAuthors.SelectedIndex <= 0)
            {
                return 0;
            }
            return authors[comboBoxAuthors.SelectedIndex - 1].AuthorID;
        }

        private int GetSelectedPublisherID()
        {
            if (comboBoxPublishers.SelectedIndex <= 0)
            {
                return 0;
            }
            return publishers[comboBoxPublishers.SelectedIndex - 1].PublisherID;
        }

        private List<int> GetSelectedCategoriesID()
        {
            List<int> selectedCategoriesID = new List<int>(0);
            foreach (string categoryName in checkedListBoxCategories.CheckedItems)
            {
                int selectedCategoryID = categories[checkedListBoxCategories.Items.IndexOf(categoryName)].CategoryID;
                selectedCategoriesID.Add(selectedCategoryID);
            }
            return selectedCategoriesID;
        }

        private PublicationDateCondition GetPublicationDateCondition()
        {
            if (comboBoxPublicationDate.SelectedItem == null)
            {
                return null;
            }
            PublicationDateCondition pdc = new PublicationDateCondition
            {
                Condition = comboBoxPublicationDate.SelectedItem.ToString(),
                Month = comboBoxMonth.SelectedIndex + 1,
                Year = Convert.ToInt32(numericUpDownYear.Value.ToString())
            };
            return pdc;
        }

        private void AddEventsToControls()
        {
            textBoxTitle.TextChanged += new EventHandler(this.TextBoxTitle_TextChanged);
            comboBoxAuthors.SelectedIndexChanged += new EventHandler(this.ComboBoxAuthors_SelectedIndexChanged);
            comboBoxPublishers.SelectedIndexChanged += new EventHandler(this.ComboBoxPublishers_SelectedIndexChanged);
            checkedListBoxCategories.SelectedIndexChanged += new EventHandler(this.ComboBoxPublishers_SelectedIndexChanged);
            comboBoxPublicationDate.SelectedIndexChanged += new EventHandler(this.ComboBoxPublicationDate_SelectedIndexChanged);
            comboBoxMonth.SelectedIndexChanged += new EventHandler(this.ComboBoxMonth_SelectedIndexChanged);
            numericUpDownYear.ValueChanged += new EventHandler(this.NumericUpDownYear_ValueChanged);
            dataGridViewSearchResult.CellContentClick += new DataGridViewCellEventHandler(this.DataGridViewSearchResult_CellContentClick);
        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewSearchResult();
        }

        private void ComboBoxAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewSearchResult();
        }

        private void ComboBoxPublishers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewSearchResult();
        }

        private void CheckedListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewSearchResult();
        }

        private void ComboBoxPublicationDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewSearchResult();
        }

        private void ComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPublicationDate.SelectedIndex == 0)
            {
                return;
            }
            UpdateDataGridViewSearchResult();
        }

        private void NumericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            if (comboBoxPublicationDate.SelectedIndex == 0)
            {
                return;
            }
            UpdateDataGridViewSearchResult();
        }

        private void DataGridViewSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (containerForm is ViewBookForm viewBookForm)
            {
                viewBookForm.DataGridViewSearchResult_CellContentClick(sender, e);
            }
            else if (containerForm is CreateBillForm createBillForm)
            {
                createBillForm.DataGridViewSearchResult_CellContentClick(sender, e);
            }
            else if (containerForm is ImportBookForm importBookForm)
            {
                importBookForm.DataGridViewSearchResult_CellContentClick(sender, e);
            }
        }
    }
}
