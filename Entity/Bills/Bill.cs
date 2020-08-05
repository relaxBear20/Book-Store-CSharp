
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace prjC
{

    public class Bill
    {
        public string billID { get; set; }
        public String dateOfBill
        {
            get { return _dateOfBill; }
            set {

                _dateOfBill = value; 
            }
        }
        private string _dateOfBill {get;set; }
        public int employeeID { get; set; } // public Employees e
        public string firstName { get; set; }

        public Bill() { }

        public Bill(string billID,String dateOfBill ,int employeeID)
        {
            this.billID = billID;
            this.dateOfBill = dateOfBill;
            this.employeeID = employeeID;
        }
    }
    public class BillList
    {
        public static List<Bill> GetAllBills()
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getAllBills();
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }

        public static List<Bill> getBillByIDAndDate(string id,string dateFrom,string dateTo)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByIDAndDate(id,dateFrom,dateTo);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }

        public static List<Bill> getBillByEmployeeNameAndDate(string employeeName, string dateFrom, string dateTo)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByEmployeeNameAndDate(employeeName, dateFrom, dateTo);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
        public static List<Bill> getBillByBillIdAndEmployeeNameAndDate(string id, string employeeName, string dateFrom, string dateTo)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByBillIdAndEmployeeNameAndDate(id,employeeName, dateFrom, dateTo);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
        public static List<Bill> getBillByDate( string dateFrom, string dateTo)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByDate( dateFrom, dateTo);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
        public static List<Bill> getBillById(string id)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillById(id);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
        public static List<Bill> getBillByName(string name)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByName(name);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
        public static List<Bill> getBillByIdAndName(string id, string name)
        {
            List<Bill> l = new List<Bill>();
            DataTable dt = BillDAO.getBillByIdAndName(id,name);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Bill a = new Bill();
                a.billID = dr["BillID"].ToString();
                a.dateOfBill = dr["BillDate"].ToString();
                a.employeeID = int.Parse(dr["EmployeeID"].ToString());
                a.firstName = dr["FirstName"].ToString();
                l.Add(a);
            }
            return l;
        }
    }
}

