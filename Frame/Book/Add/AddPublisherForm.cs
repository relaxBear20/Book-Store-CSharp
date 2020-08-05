using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace prjC
{
    public partial class AddPublisherForm : Form
    {
        private readonly Form containerForm;
        public AddPublisherForm(Form containerForm)
        {
            InitializeComponent();
            this.containerForm = containerForm;
        }

        private void ButtonAddPublisher_Click(object sender, EventArgs e)
        {
            if (!IsReadyForAdd())
            {
                return;
            }
            string publisherName = textBoxPublisherName.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string fax = textBoxFax.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            Publisher publisher = new Publisher()
            {
                PublisherName = publisherName,
                Address = address,
                Phone = phone,
                Fax = fax,
                Email = email
            };
            int publisherID = PublisherDAO.AddNewPublisher(publisher);
            MessageBox.Show("Publisher Added Successful!");
            if (containerForm is AddBookForm addBookForm)
            {
                addBookForm.UpdateComboBoxPublishers(publisherID);
                addBookForm.ClearAddNewPanel();
            }
            else if (containerForm is EditBookForm editBookForm)
            {
                editBookForm.UpdateComboBoxPublishers(publisherID);
                editBookForm.ClearAddNewPanel();
            }
        }

        private Boolean IsReadyForAdd()
        {
            return labelPublisherNameMessage.ForeColor == Color.Green &&
                labelAddressMessage.ForeColor == Color.Green &&
                labelPhoneMessage.ForeColor == Color.Green &&
                labelFaxMessage.ForeColor == Color.Green &&
                labelEmailMessage.ForeColor == Color.Green;
        }

        private void TextBoxPublisherName_TextChanged(object sender, EventArgs e)
        {
            string publisherName = textBoxPublisherName.Text.Trim();
            if (publisherName.Length == 0)
            {
                labelPublisherNameMessage.ForeColor = Color.Red;
                labelPublisherNameMessage.Text = "Publisher Name is required";
                return;
            }
            List<Publisher> publishers = PublisherDAO.SelectAllPublishers();
            foreach (Publisher publisher in publishers)
            {
                if (publisher.PublisherName.Equals(publisherName))
                {
                    labelPublisherNameMessage.ForeColor = Color.Red;
                    labelPublisherNameMessage.Text = "Publisher Name already existed";
                    return;
                }
            }
            labelPublisherNameMessage.ForeColor = Color.Green;
            labelPublisherNameMessage.Text = "Publisher Name is OK";
        }

        private void TextBoxAddress_TextChanged(object sender, EventArgs e)
        {
            string address = textBoxAddress.Text.Trim();
            if (address.Length == 0)
            {
                labelAddressMessage.ForeColor = Color.Red;
                labelAddressMessage.Text = "Address is required";
                return;
            }
            labelAddressMessage.ForeColor = Color.Green;
            labelAddressMessage.Text = "Address is OK";
        }

        private void TextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = textBoxPhone.Text.Trim();
            if (phone.Length == 0)
            {
                labelPhoneMessage.ForeColor = Color.Green;
                labelPhoneMessage.Text = "Phone is not required";
                return;
            }
            if (!Utility.IsPhone(phone))
            {
                labelPhoneMessage.ForeColor = Color.Red;
                labelPhoneMessage.Text = "Phone is invalid";
                return;
            }
            labelPhoneMessage.ForeColor = Color.Green;
            labelPhoneMessage.Text = "Phone is OK";
        }

        private void TextBoxFax_TextChanged(object sender, EventArgs e)
        {
            string fax = textBoxFax.Text.Trim();
            if (fax.Length == 0)
            {
                labelFaxMessage.ForeColor = Color.Green;
                labelFaxMessage.Text = "Fax is not required";
                return;
            }
            if (!Utility.IsFax(fax))
            {
                labelFaxMessage.ForeColor = Color.Red;
                labelFaxMessage.Text = "Fax is invalid";
                return;
            }
            labelFaxMessage.ForeColor = Color.Green;
            labelFaxMessage.Text = "Fax is OK";
        }

        private void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            if (email.Length == 0)
            {
                labelEmailMessage.ForeColor = Color.Green;
                labelEmailMessage.Text = "Email is not required";
                return;
            }
            if (!Utility.IsEmail(email))
            {
                labelEmailMessage.ForeColor = Color.Red;
                labelEmailMessage.Text = "Email is invalid";
                return;
            }
            labelEmailMessage.ForeColor = Color.Green;
            labelEmailMessage.Text = "Email is OK";
        }
    }
}
