using prjC.Frame.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjC
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
          
            InitializeComponent();
            Utility.SetAllControlsFont(this.Controls);
           
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            string[] monthsName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            lblMonthsSale.Text = "Months:";
            List<string> months = new List<string>();
            for (int i = 0; i < DateTime.Now.Month; i++)
            {
                months.Add(monthsName[i]);

            }
            cbxMonthsSale.DataSource = months;


            Utility.SetAllControlsFont(this.Controls);
        }
        List<double> lstTotalByDate = new List<double>();
        private void DrawSaleChart()
        {
            string[] monthsName = { "January","February","March","April","May","June","July","August","September","October" ,"November","December"};
            lstTotalByDate.Clear();
            string month = (cbxMonthsSale.SelectedIndex+1).ToString();
            dgvTopBook.DataSource = BookDAO.GetTopBookByMonth(month);
            dgvTopEmployee.DataSource = AccountDAO.GetTopEmployeeByMonth(month);

            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year,Convert.ToInt32(month)) ; i++)
            {
                string year = "2020";
                
                string date = (i + 1).ToString();
                string conDate = year + "-" + month + "-" + date;

                try
                {
                    DateTime dt = Convert.ToDateTime(conDate);
                    double value = BillDAO.getTotalByDate(conDate);
                    lstTotalByDate.Add(value);
                } catch (FormatException)
                {
                    lstTotalByDate.Add(0);

                }

            }
            int basehei = 200;
            double maxVal = 0;
            double minVal = 0;
            foreach (double d in lstTotalByDate)
            {
                if (d > maxVal) maxVal = d;
            }
             minVal = maxVal;
            foreach (double d in lstTotalByDate)
            {
                if (d < minVal) minVal = d;
            }
            flpDisplaySale.Controls.Clear();
            for (int i = 0; i < lstTotalByDate.Count; i++)
            {

                int height = CalToCol(basehei, maxVal, lstTotalByDate[i]);

                MyLabel l = new MyLabel();
                l.Height = height;
                l.BackColor = Color.Gray;
                l.Months = i ;
                l.MouseHover += L_MouseHover;
                l.MouseLeave += L_MouseLeave;
                MyLabel l2 = new MyLabel();
                l2.Text = (i + 1).ToString();
                l2.Height = 25;
                FlowLayoutPanel fl1 = new FlowLayoutPanel();
                fl1.Width = 30;
                fl1.Height = 300;
                fl1.FlowDirection = FlowDirection.BottomUp;
                fl1.Controls.Add(l2);
                fl1.Controls.Add(l);
                
               
                flpDisplaySale.Controls.Add(fl1);
            }
            lblSaleHighest.Text =  String.Format("Heightest Of"+monthsName[Convert.ToInt32(month)-1]+": {0:n0} VND ", maxVal);
            lblLowest.Text = String.Format("Lowest Of" + monthsName[Convert.ToInt32(month) - 1] + ": {0:n0} VND ", minVal);
            double aver = 0;
            foreach(double d in lstTotalByDate)
            {
                aver += d;
            }
            lblSaleAver.Text = String.Format("Average : {0:n0} VND / Day", (aver / lstTotalByDate.Count)); 
        }

        private void L_MouseLeave(object sender, EventArgs e)
        {
            MyLabel l = (MyLabel)sender;
            l.BackColor = Color.Gray;
            lblTotalAt.Text = String.Format("Total At : ");
        }

        private void L_MouseHover(object sender, EventArgs e)
        {
            MyLabel l = (MyLabel)sender;
            l.BackColor = Color.White;
            lblTotalAt.Text = String.Format("Total At : {0:n0} VND ", lstTotalByDate[l.Months]);
        }

        private int CalToCol(int basehei, double maxVal, double value)
        {
            try
            {
                double percentage = value / maxVal;
                int result = Convert.ToInt32(Math.Floor(basehei * percentage));
                return result;
            } catch (OverflowException)
            {
                return 0;
            }
            
        }
        private void cbxSearchBySale_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMonthsSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSaleChart();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dgvTopBook_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTopBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopBook.Refresh();
        }

        private void dgvTopEmployee_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTopEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopEmployee.Refresh();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
