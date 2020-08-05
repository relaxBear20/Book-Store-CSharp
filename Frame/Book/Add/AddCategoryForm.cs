using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class AddCategoryForm : Form
    {
        private readonly Form containerForm;
        public AddCategoryForm(Form containerForm)
        {
            InitializeComponent();
            this.containerForm = containerForm;
        }

        private void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            if (!ReadyToAdd())
            {
                return;
            }
            string categoryName = textBoxCategoryName.Text.Trim();
            string description = textBoxDescription.Text.Trim();
            Category category = new Category()
            {
                CategoryName = categoryName,
                Description = description
            };
            int categoryID = CategoryDAO.AddNewCategory(category);
            MessageBox.Show("Category Added Successful!");
            if (containerForm is AddBookForm addBookForm)
            {
                addBookForm.UpdateCheckedListBoxCategories(categoryID);
                addBookForm.ClearAddNewPanel();
            }
            else if (containerForm is EditBookForm editBookForm)
            {
                editBookForm.UpdateCheckedListBoxCategories(categoryID);
                editBookForm.ClearAddNewPanel();
            }
        }

        private bool ReadyToAdd()
        {
            return labelCategoryNameMessage.ForeColor == Color.Green
                && labelDescriptionMessage.ForeColor == Color.Green;
        }

        private void TextBoxCategoryName_TextChanged(object sender, EventArgs e)
        {
            string categoryName = textBoxCategoryName.Text.Trim();
            if (categoryName.Length == 0)
            {
                labelCategoryNameMessage.ForeColor = Color.Red;
                labelCategoryNameMessage.Text = "Category Name is required";
                return;
            }
            List<Category> categories = CategoryDAO.SelectAllCategories();
            foreach (Category category in categories)
            {
                if (category.CategoryName.Equals(categoryName))
                {
                    labelCategoryNameMessage.ForeColor = Color.Red;
                    labelCategoryNameMessage.Text = "Category Name already existed";
                    return;
                }
            }
            labelCategoryNameMessage.ForeColor = Color.Green;
            labelCategoryNameMessage.Text = "Category Name is OK";
        }

        private void TextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text.Trim();
            if (description.Length == 0)
            {
                labelDescriptionMessage.ForeColor = Color.Green;
                labelDescriptionMessage.Text = "Description is not required";
                return;
            }
            labelDescriptionMessage.ForeColor = Color.Green;
            labelDescriptionMessage.Text = "Description is OK";
        }
    }
}
