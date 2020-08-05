using prjC.Frame;
using System;
using System.Windows.Forms;

namespace prjC
{
    public partial class CreateBillForm : Form
    {
        private readonly Employee EMPLOYEE;

        private readonly SearchBookPanel searchBookPanel;
        private readonly FrmMenu container;
        public CreateBillForm(Employee e, FrmMenu container)
        {
            EMPLOYEE = e;
            this.container = container;
            InitializeComponent();
            searchBookPanel = new SearchBookPanel(this);
            Controls.Add(searchBookPanel);
        }

        private void CreateBillForm_Load(object sender, EventArgs e)
        {
            AddItemsToDataGridViewBillDetails();
        }

        private void AddItemsToDataGridViewBillDetails()
        {
            dataGridViewBillDetails.Columns.Add("BookID", "BookID");
            dataGridViewBillDetails.Columns["BookID"].Visible = false;
            dataGridViewBillDetails.Columns.Add("Title", "Title");
            dataGridViewBillDetails.Columns.Add("UnitPrice", "UnitPrice");
            dataGridViewBillDetails.Columns.Add("Quantity", "Quantity");
            dataGridViewBillDetails.Columns.Add("Discount", "Discount");
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn
            {
                UseColumnTextForButtonValue = true,
                Text = "Remove",
                Name = "Remove"
            };
            dataGridViewBillDetails.Columns.Add(removeButtonColumn);
        }

        public void DataGridViewSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var source = ((DataGridView)sender).Columns[e.ColumnIndex];
            if (source.Name.Equals("Add"))
            {
                int bookID = Convert.ToInt32(searchBookPanel.dataGridViewSearchResult.Rows[e.RowIndex].Cells["BookID"].Value);
                Book book = BookDAO.SelectBookByBookID(bookID);
                if (book.UnitsInStock == 0)
                {
                    MessageBox.Show("UnitsInStock == 0");
                    return;
                }
                UpdateDataGridViewBillDetails(bookID);
                UpdateLabelTotalPrice();
                UpdateButtonCreateBill();
            }
        }

        private void UpdateDataGridViewBillDetails(int bookID)
        {
            Book book = BookDAO.SelectBookByBookID(bookID);
            for (int index = 0; index < dataGridViewBillDetails.Rows.Count; index++)
            {
                int existedBookID = Convert.ToInt32(dataGridViewBillDetails.Rows[index].Cells["BookID"].Value.ToString());
                if (bookID == existedBookID)
                {
                    DataGridViewCell quantityCell = dataGridViewBillDetails.Rows[index].Cells["Quantity"];
                    int oldQuantity = Convert.ToInt32(quantityCell.Value.ToString());
                    int unitsInStock = BookDAO.SelectUnitsInStock(bookID);
                    if (oldQuantity == unitsInStock)
                    {
                        MessageBox.Show("Quantity <= UnitsInStock");
                        return;
                    }
                    quantityCell.Value = oldQuantity + 1;
                    return;
                }
            }
            dataGridViewBillDetails.Rows.Add(book.BookID, book.Title, Utility.FormatMoney(book.UnitPrice), 1, 0);
        }

        private void UpdateLabelTotalPrice()
        {
            double totalPrice = CalculateTotalPrice();
            labelTotalPrice.Text = "Total Price: " + Utility.FormatMoney(totalPrice);
        }

        private double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (DataGridViewRow dataGridViewRow in dataGridViewBillDetails.Rows)
            {
                double unitPrice = double.Parse(dataGridViewRow.Cells["UnitPrice"].Value.ToString());
                int quantity = int.Parse(dataGridViewRow.Cells["Quantity"].Value.ToString());
                totalPrice += unitPrice * quantity;
            }
            return totalPrice;
        }

        private void DataGridViewBillDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var source = ((DataGridView)sender).Columns[e.ColumnIndex];
            if (source.Name.Equals("Remove"))
            {
                DataGridViewRow selectedRow = dataGridViewBillDetails.Rows[e.RowIndex];
                dataGridViewBillDetails.Rows.Remove(selectedRow);
                UpdateLabelTotalPrice();
                UpdateButtonCreateBill();
            }
        }

        private void UpdateButtonCreateBill()
        {
            double totalPrice = CalculateTotalPrice();
            if (totalPrice == 0)
            {
                buttonCreateBill.Enabled = false;
            }
            else
            {
                buttonCreateBill.Enabled = true;
            }
        }

        private void ButtonCreateBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create This Order?", "Create Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int employeeID = Convert.ToInt32(EMPLOYEE.ID);
            BookDAO.InsertBill(employeeID);
            int billID = BookDAO.SelectMaxBillID();
            foreach (DataGridViewRow dataGridViewRow in dataGridViewBillDetails.Rows)
            {
                int bookID = Convert.ToInt32(dataGridViewRow.Cells["BookID"].Value.ToString());
                int quantity = Convert.ToInt32(dataGridViewRow.Cells["Quantity"].Value.ToString());
                double unitPrice = Convert.ToDouble(dataGridViewRow.Cells["UnitPrice"].Value.ToString());
                double discount = Convert.ToDouble(dataGridViewRow.Cells["Discount"].Value.ToString());
                BookDAO.InsertBillDetails(billID, bookID, quantity, unitPrice, discount);
                int oldUnitsInStock = BookDAO.SelectUnitsInStock(bookID);
                int newUnitsInStock = oldUnitsInStock - quantity;
                BookDAO.UpdateUnitsInStock(bookID, newUnitsInStock);
            }
            MessageBox.Show("Bill Created Succesful");
            container.LoadNewForm(new ExportBillForm(billID));
        }
    }
}
