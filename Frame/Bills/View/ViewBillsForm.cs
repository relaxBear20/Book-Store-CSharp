using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace prjC
{
    public partial class ViewBillsForm : Form
    {
        private readonly Employee EMPLOYEE;
        private double Amount { get; set; }
        public ViewBillsForm(Employee e)
        {
            this.EMPLOYEE = e;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnCheckDate.Checked == true)
            {
                if (dateFrom.Value >= dateTo.Value)
                {
                    MessageBox.Show("The To date must be after the From date");
                }
                else
                {
                    if (txtBillID.Text != "" && txtEmployeeName.Text == "")
                    {
                        int value;
                        if (int.TryParse(txtBillID.Text, out value))
                        {
                            dgvBills.DataSource = BillList.getBillByIDAndDate(txtBillID.Text, dateFrom.Value.ToString(), dateTo.Value.ToString());
                        }
                        else
                        {
                            dgvBills.DataSource = BillList.getBillByName("!");
                        }
                    }
                    if (txtEmployeeName.Text != "" && txtBillID.Text == "")
                    {
                        int value;
                        if (int.TryParse(txtBillID.Text, out value))
                        {
                            dgvBills.DataSource = BillList.getBillByEmployeeNameAndDate(txtEmployeeName.Text, dateFrom.Value.ToString(), dateTo.Value.ToString());
                        }
                        else
                        {
                            dgvBills.DataSource = BillList.getBillByName("!");
                        }
                    }
                    if (txtEmployeeName.Text != "" && txtBillID.Text != "")
                    {
                        dgvBills.DataSource = BillList.getBillByBillIdAndEmployeeNameAndDate(txtBillID.Text, txtEmployeeName.Text, dateFrom.Value.ToString(), dateTo.Value.ToString());
                    }
                    if (txtEmployeeName.Text == "" && txtBillID.Text == "")
                    {
                        dgvBills.DataSource = BillList.getBillByDate(dateFrom.Value.ToString(), dateTo.Value.ToString());
                    }
                }
            }
            else
            {
                if (txtBillID.Text == "" && txtEmployeeName.Text == "")
                {
                    dgvBills.DataSource = BillList.GetAllBills();
                }
                if (txtBillID.Text != "" && txtEmployeeName.Text == "")
                {
                    int value;
                    if (int.TryParse(txtBillID.Text, out value))
                    {
                        dgvBills.DataSource = BillList.getBillById(txtBillID.Text);
                    }
                    else
                    {
                        dgvBills.DataSource = BillList.getBillByName("!");
                    }
                }
                if (txtEmployeeName.Text != "" && txtBillID.Text == "")
                {
                    dgvBills.DataSource = BillList.getBillByName(txtEmployeeName.Text);

                }
                if (txtEmployeeName.Text != "" && txtBillID.Text != "")
                {
                    int value;
                    if (int.TryParse(txtBillID.Text, out value))
                    {
                        dgvBills.DataSource = BillList.getBillByIdAndName(txtBillID.Text, txtEmployeeName.Text);
                    }
                    else
                    {
                        dgvBills.DataSource = BillList.getBillByName("!");
                    }
                }
            }
        }

        private void ViewBills_Load(object sender, EventArgs e)
        {
            dgvBills.AutoGenerateColumns = false;
            dgvBills.Columns.Clear();

            // add(string nameColumn,string HeaderText)
            dgvBills.Columns.Add("id", "Bill ID");
            //id 1 - NameColumn id 2 - property of Member
            dgvBills.Columns["id"].DataPropertyName = "billID";

            dgvBills.Columns.Add("dateOfBill", "Bill Date");
            dgvBills.Columns["dateOfBill"].DataPropertyName = "dateOfBill";

            dgvBills.Columns.Add("employeeID", "Employee ID");
            dgvBills.Columns["employeeID"].DataPropertyName = "employeeID";

            dgvBills.Columns.Add("firstName", "Employee Name");
            dgvBills.Columns["firstName"].DataPropertyName = "firstName";

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Detail";
            btnColumn.Name = "detailButton";
            btnColumn.Text = "Detail";
            btnColumn.UseColumnTextForButtonValue = true;
            dgvBills.Columns.Add(btnColumn);

            DataGridViewButtonColumn exportButtonColumn = new DataGridViewButtonColumn();
            exportButtonColumn.HeaderText = "Export";
            exportButtonColumn.Name = "Export";
            exportButtonColumn.Text = "Export";
            exportButtonColumn.UseColumnTextForButtonValue = true;
            dgvBills.Columns.Add(exportButtonColumn);

            dgvBills.DataSource = BillList.GetAllBills();
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderObj = (DataGridView)sender;
            if (senderObj.Columns[e.ColumnIndex].Name == "detailButton" && e.RowIndex != -1)
            {
                flpBillDetail.Controls.Clear();
                string billID = ((List<Bill>)dgvBills.DataSource)[e.RowIndex].billID;
                List<BillDetail> listBillDetail = BillDetail.getBillDetailByBillId(billID);

                foreach (BillDetail b in listBillDetail)
                {
                    flpBillDetail.Controls.Add(new ViewBillDetail(b, () =>
                    {
                        loadAmount();
                    }));
                }
                loadAmount();
                btnClose.Visible = true;
            }
            else if (senderObj.Columns[e.ColumnIndex].Name == "Export" && e.RowIndex != -1)
            {
                var source = ((DataGridView)sender).Columns[e.ColumnIndex];
                if (source.Name.Equals("Export"))
                {
                    flpBillDetail.Controls.Clear();
                    int billID = Convert.ToInt32(senderObj.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    ExportBillForm ex = new ExportBillForm( billID);
                    ex.Show();
                }
            }
        }

        private void loadAmount()
        {
            Amount = 0;
            foreach (ViewBillDetail userControl1 in flpBillDetail.Controls)
            {
                Amount += userControl1.Total;
            }
            lblAmount.Text = string.Format("Total amount: {0}", Utility.FormatMoney(Amount));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            flpBillDetail.Controls.Clear();
            lblAmount.Text = "";
            btnClose.Visible = false;
        }
    }
}
