using System;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class AddAuthorForm : Form
    {
        private readonly Form containerForm;
        public AddAuthorForm(Form containerForm)
        {
            InitializeComponent();
            this.containerForm = containerForm;
        }

        private void ButtonAddAuthor_Click(object sender, EventArgs e)
        {
            if (!ReadyToAdd())
            {
                return;
            }
            Author author = new Author()
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                BirthDate = dateTimePickerBirthDate.Value,
                About = textBoxAbout.Text.Trim()
            };
            int authorID = AuthorDAO.AddNewAuthor(author);
            MessageBox.Show("Author Added Successful!");
            if (containerForm is AddBookForm addBookForm)
            {
                addBookForm.UpdateComboBoxAuthors(authorID);
                addBookForm.ClearAddNewPanel();
            }
            else if (containerForm is EditBookForm editBookForm)
            {
                editBookForm.UpdateComboBoxAuthors(authorID);
                editBookForm.ClearAddNewPanel();
            }
        }

        private bool ReadyToAdd()
        {
            return labelFirstNameMessage.ForeColor == Color.Green
                && labelLastNameMessage.ForeColor == Color.Green
                && labelBirthDateMessage.ForeColor == Color.Green
                && labelAboutMessage.ForeColor == Color.Green;
        }

        private void TextBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text.Trim();
            if (firstName.Length == 0)
            {
                labelFirstNameMessage.ForeColor = Color.Red;
                labelFirstNameMessage.Text = "First Name is required";
                return;
            }
            labelFirstNameMessage.ForeColor = Color.Green;
            labelFirstNameMessage.Text = "First Name is OK";
        }

        private void TextBoxLastName_TextChanged(object sender, EventArgs e)
        {
            string lastName = textBoxLastName.Text.Trim();
            if (lastName.Length == 0)
            {
                labelLastNameMessage.ForeColor = Color.Green;
                labelLastNameMessage.Text = "Last Name is not required";
            }
            labelLastNameMessage.ForeColor = Color.Green;
            labelLastNameMessage.Text = "Last Name is OK";
        }

        private void DateTimePickerBirthDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthDate = dateTimePickerBirthDate.Value;
            if (birthDate > DateTime.Today)
            {
                labelBirthDateMessage.ForeColor = Color.Red;
                labelBirthDateMessage.Text = "Birth Date is invalid";
            }
            labelBirthDateMessage.ForeColor = Color.Green;
            labelBirthDateMessage.Text = "Birth Date is OK";
        }

        private void TextBoxAbout_TextChanged(object sender, EventArgs e)
        {
            string about = textBoxAbout.Text.Trim();
            if (about.Length == 0)
            {
                labelAboutMessage.ForeColor = Color.Green;
                labelAboutMessage.Text = "About is not required";
            }
            labelAboutMessage.ForeColor = Color.Green;
            labelAboutMessage.Text = "About is OK";
        }
    }
}
