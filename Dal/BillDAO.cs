using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace prjC
{
    class BillDAO : DataAccess
    {
        //get All Bills

        public static DataTable SelectBillDetails1ByBillID(int billID)
        {
            string sql = "select [BillID],[BillDate],([FirstName] + ' ' + [LastName]) AS [EmployeeName],\n" +
                "CAST((select sum([Price]) from (select ([Quantity] * [Bill_Details].[UnitPrice] * (1 - [Discount])) AS [Price] from [Bill_Details] where [BillID]=@billID) AS [Price]) AS int) AS [TotalPrice]\n" +
                "from [Bills]\n" +
                "inner join [Employees] on [Bills].[EmployeeID] = [Employees].[EmployeeID]\n" +
                "where [BillID] = @billID;";
            SqlParameter param = new SqlParameter("@billID", SqlDbType.Int)
            {
                Value = billID
            };
            return ExecuteReader(sql, param);
        }

        public static DataTable SelectBillDetails2ByBillID(int billID)
        {
            string sql = "select CAST(ROW_NUMBER() OVER(ORDER BY [Books].[BookID]) AS int) AS [Index],\n" +
                "('Sách ' + [Title]) AS [Title],N'Quyển' AS [Unit],[Quantity],\n" +
                "CAST([Bill_Details].[UnitPrice] AS int) AS [UnitPrice],\n" +
                "CAST(([Discount] * 100) AS int) AS [Discount],\n" +
                "CAST(([Quantity] * [Bill_Details].[UnitPrice] * (1 - [Discount])) AS int) AS [Price]\n" +
                "from [Bills]\n" +
                "inner join [Bill_Details] on [Bills].[BillID] = [Bill_Details].[BillID]\n" +
                "inner join [Books] on [Bill_Details].[BookID] = [Books].[BookID]\n" +
                "where [Bills].[BillID] = @billID\n" +
                "group by [Books].[BookID],[Title],[Quantity],[Bill_Details].[UnitPrice],[Discount];";
            SqlParameter param = new SqlParameter("@billID", SqlDbType.Int)
            {
                Value = billID
            };
            return ExecuteReader(sql, param);
        }

        public static DataTable getAllBills()
        {
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees where Bills.EmployeeID =Employees.EmployeeID";
            return GetDataBySQL(sql);
        }

        // get Bills by Bill ID
        public static DataTable getBillByIDAndDate(string id,string dateFrom,string dateTo)
        {
           
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                where Bills.EmployeeID =Employees.EmployeeID
                and Bills.BillID = " + id+ " and Bills.BillDate between '"+dateFrom+"' and '"+dateTo+"'";
            return GetDataBySQL(sql);
        }

        // get Bills by employee Account Name
        public static DataTable getBillByEmployeeNameAndDate(string employeeName, string dateFrom, string dateTo)
        {
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                where Bills.EmployeeID =Employees.EmployeeID
                and Employees.FirstName like '" + employeeName + "%' and Bills.BillDate between '" + dateFrom + "' and '" + dateTo + "'";
            return GetDataBySQL(sql);
        }
        
        public static DataTable getBillByBillIdAndEmployeeNameAndDate(string id,string employeeName, string dateFrom, string dateTo)
        {
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                where Bills.EmployeeID =Employees.EmployeeID
                and Bills.BillID = " + id + " and Employees.FirstName like '" + employeeName + "%' and Bills.BillDate between '" + dateFrom + "' and '" + dateTo + "'";
            return GetDataBySQL(sql);
        }

        public static DataTable getBillByDate( string dateFrom, string dateTo)
        {
            string sql;
                 sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                where Bills.EmployeeID =Employees.EmployeeID
                and Bills.BillDate between '" + dateFrom + "' and '" + dateTo + "'";
           
            return GetDataBySQL(sql);
        }

        public static DataTable getBillById(string id)
        {
                string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                        where Bills.EmployeeID =Employees.EmployeeID
                        and Bills.BillID =" + id;
                return GetDataBySQL(sql);
            

        }

        public static DataTable getBillByName(string name)
        {
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                        where  Bills.EmployeeID =Employees.EmployeeID
                        and Employees.FirstName like '" + name +"%'";
            return GetDataBySQL(sql);
        }

        public static DataTable getBillByIdAndName(string id, string name)
        {
            string sql = @"select Bills.BillID,Bills.BillDate,Bills.EmployeeID,Employees.FirstName
                            from Bills,Employees
                        where Bills.EmployeeID =Employees.EmployeeID
                        and Bills.BillID =" + id + "and Employees.FirstName like '" + name +"%'";
            return GetDataBySQL(sql);
        }

        public static double getTotalByDate(string date)
        {
            string sql = "SELECT SUM(bd.Quantity * bd.UnitPrice) as total FROM Bills b , Bill_Details bd WHERE b.BillID = bd.BillID AND b.BillDate = @date";
            SqlParameter param0 = new SqlParameter("date", SqlDbType.NVarChar);
            param0.Value = date;
            DataTable dt = GetDataBySQL(sql, param0);
            foreach (DataRow dr in dt.Rows)
            {
                
                   try
                {
                    double re = Convert.ToDouble(dr["total"]);
                    return re;
                } catch (InvalidCastException)
                {
                    return 0;
                }
                
                
            }
            return 0;
        }
    }
    class BillDetailDAO : DataAccess
    {
        public static DataTable getBillDetailByBillId(string id)
        {
            string sql = @"select Bill_Details.BillID,Bill_Details.BookID,Bill_Details.Quantity,Bill_Details.Discount,Books.UnitPrice
                            from Bill_Details,Books
                            where Bill_Details.BookID = Books.BookID and Bill_Details.BillID =" + id;
            return GetDataBySQL(sql);
        }
    }
 }
