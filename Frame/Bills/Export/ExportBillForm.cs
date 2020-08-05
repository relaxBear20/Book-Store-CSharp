
using System;
using System.Data;
using System.Windows.Forms;

namespace prjC
{
    public partial class ExportBillForm : Form
    {
 
        private readonly int billID;
        public ExportBillForm( int billID)
        {
            InitializeComponent();

            this.billID = billID;
        }

        private void ExportBillForm_Load(object sender, EventArgs e)
        {
            BillDetailsCrystalReport billDetailsCrystalReport = new BillDetailsCrystalReport();
            DataTable dataTable1 = BillDAO.SelectBillDetails1ByBillID(billID);
            billDetailsCrystalReport.Database.Tables["Bill_Details_1"].SetDataSource(dataTable1);
            DataTable dataTable2 = BillDAO.SelectBillDetails2ByBillID(billID);
            billDetailsCrystalReport.Database.Tables["Bill_Details_2"].SetDataSource(dataTable2);
            crystalReportViewer.ReportSource = billDetailsCrystalReport;
        }

        private void ExportBillForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
