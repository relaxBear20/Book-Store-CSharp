
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace prjC
{
    public class BillDetail
    {
        public string BillId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public string Discount { get; set; }
        public string Price { get; set; }

        public BillDetail() { }

        public static List<BillDetail> getBillDetailByBillId(string id)
        {
            List<BillDetail> list = new List<BillDetail>();
            DataTable dt = BillDetailDAO.getBillDetailByBillId(id);
            foreach (DataRow dr in dt.Rows)
            {
                BillDetail a = new BillDetail();
                a.BillId = dr["BillID"].ToString();
                a.BookId = dr["BookID"].ToString();
                a.Quantity = int.Parse(dr["Quantity"].ToString());
                a.Discount = dr["Discount"].ToString();
                a.Price = dr["UnitPrice"].ToString();
                list.Add(a);
            }
            return list;
        }
    }
}
