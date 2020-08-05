using System;
using System.Windows.Forms;

namespace prjC
{
    public delegate void OnChange();
    public partial class ViewBillDetail : UserControl
    {
        public BillDetail billDetail { get; set; }
        public double Total { get; set; }
        private OnChange onChange;
        public ViewBillDetail(BillDetail b, OnChange callback)
        {
            InitializeComponent();
            this.billDetail = b;
            this.onChange = callback;
        }

        private void ViewBillDetail_Load(object sender, EventArgs e)
        {
            txtBillID.Text = billDetail.BillId.ToString();
            txtBookID.Text = billDetail.BookId;
            txtQuantity.Text = billDetail.Quantity.ToString();
            txtDiscount.Text = billDetail.Discount.ToString();
            txtPrice.Text = Utility.FormatMoney(billDetail.Price);
            double total = 0;
            if (txtDiscount.Text != "")
            {
                total = billDetail.Quantity* Convert.ToDouble(billDetail.Price) ;
            }
            else
            {
                total = billDetail.Quantity * Convert.ToDouble(billDetail.Price);
            }
            lblAmount.Text = Utility.FormatMoney(total);
            this.Total = total;
        }
    }
}
