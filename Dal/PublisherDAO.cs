

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace prjC
{
    class PublisherDAO : DataAccess
    {
        public static List<Publisher> getAllPublisher()
        {
            List<Publisher> listPublisher = new List<Publisher>(0);
            string sql = "select * from [Publishers] order by [PublisherID]";
            DataTable dataTable = DataAccess.GetDataBySQL(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Publisher P = new Publisher();
                P.PublisherID= int.Parse(dataRow["PublisherID"].ToString());
                P.PublisherName = dataRow["PublisherName"].ToString();
                P.Address = dataRow["Address"].ToString();
                P.Phone = dataRow["Phone"].ToString();
                P.Fax = dataRow["Fax"].ToString();
                P.Email = dataRow["Email"].ToString();
                listPublisher.Add(P);
            }
            return listPublisher;
        }
        public static List<Publisher> getPublisherByNameAndAddress(string PublisherName,string address)
        {
            List<Publisher> listPublisher = new List<Publisher>(0);
            string sql;
            if(PublisherName!= "" && address != "")
            {
                 sql = "select * from [Publishers] where Publishers.PublisherName like '" + PublisherName + "%' and Publishers.Address like '" + address + "%' order by [PublisherID]";
            }else if (PublisherName != "" && address == "")
            {
                 sql = "select * from [Publishers] where Publishers.PublisherName like '" + PublisherName + "%' order by [PublisherID]";
            }
            else
            {
                 sql = "select * from [Publishers] where Publishers.Address like '" + address + "%' order by [PublisherID]";
            }         
            DataTable dataTable = DataAccess.GetDataBySQL(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Publisher P = new Publisher();
                P.PublisherID = int.Parse(dataRow["PublisherID"].ToString());
                P.PublisherName = dataRow["PublisherName"].ToString();
                P.Address = dataRow["Address"].ToString();
                P.Phone = dataRow["Phone"].ToString();
                P.Fax = dataRow["Fax"].ToString();
                P.Email = dataRow["Email"].ToString();
                listPublisher.Add(P);
            }
            return listPublisher;
        }
        public static List<Book> getBookByPublisherID(int id)
        {
            List<Book> listBook = new List<Book>();
            string sql = @"select books.UnitsInStock,Title,Authors.LastName,PublicationDate,UnitPrice from books,Publishers,Authors
                            where books.PublisherID = Publishers.PublisherID and Books.AuthorID = Authors.AuthorID
                            and Publishers.PublisherID = " + id;
            DataTable dataTable = DataAccess.GetDataBySQL(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Book P = new Book();               
                P.Title = dataRow["Title"].ToString();
                P.AuthorName = dataRow["LastName"].ToString();
                P.PublicationDate = DateTime.Parse(dataRow["PublicationDate"].ToString());
               
                P.UnitPrice = decimal.Parse(dataRow["UnitPrice"].ToString().Substring(0, dataRow["UnitPrice"].ToString().Length-2));
                P.UnitsInStock = int.Parse(dataRow["UnitsInStock"].ToString());
                listBook.Add(P);
            }
            return listBook;
        }
        public static List<string> getListPublisherName()
        {
            List<string> list = new List<string>();
            string sql = "select PublisherName from Publishers";
            DataTable dt = DataAccess.GetDataBySQL(sql);
            foreach (DataRow dataRow in dt.Rows)
            {
                string a = dataRow["PublisherName"].ToString();            
                list.Add(a);
            }
            return list;
        }
        public static int insertPublisher(string name,string address,string phone,string fax ,string email) 
        {
            string sql = @" INSERT INTO Publishers( PublisherName, Address,Phone,Fax,Email)
                        VALUES ('"+name+"', '"+address+"','"+phone+"' ,'"+fax+"','"+email+"') ";
            return DataAccess.ExecuteSQL(sql);
        }

        public static List<Publisher> SelectAllPublishers()
        {
            List<Publisher> publishers = new List<Publisher>(0);
            string sql = "select * from [Publishers] order by [PublisherName];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Publisher publisher = new Publisher
                {
                    PublisherID = Convert.ToInt32(dataRow["PublisherID"].ToString()),
                    PublisherName = dataRow["PublisherName"].ToString(),
                    Address = dataRow["Address"].ToString(),
                    Phone = dataRow["Phone"].ToString(),
                    Fax = dataRow["Fax"].ToString(),
                    Email = dataRow["Email"].ToString()
                };
                publishers.Add(publisher);
            }
            return publishers;
        }

         public static int AddNewPublisher(Publisher publisher)
        {
            string sql = "insert into [Publishers]([PublisherName],[Address],[Phone],[Fax],[Email]) values (@publisherName, @address, @phone, @fax, @email);\n" +
                "select SCOPE_IDENTITY();";
            SqlParameter param1 = new SqlParameter("@publisherName", SqlDbType.NVarChar)
            {
                Value = publisher.PublisherName
            };
            SqlParameter param2 = new SqlParameter("@address", SqlDbType.NVarChar)
            {
                Value = publisher.Address
            };
            SqlParameter param3 = new SqlParameter("@phone", SqlDbType.NVarChar)
            {
                Value = (publisher.Phone.Length == 0) ? (object)DBNull.Value : publisher.Phone
            };
            SqlParameter param4 = new SqlParameter("@fax", SqlDbType.NVarChar)
            {
                Value = (publisher.Fax.Length == 0) ? (object)DBNull.Value : publisher.Fax
            };
            SqlParameter param5 = new SqlParameter("@email", SqlDbType.NVarChar)
            {
                Value = (publisher.Email.Length == 0) ? (object)DBNull.Value : publisher.Email
            };
            int publisherID = ExecuteScalar(sql, param1, param2, param3, param4, param5);
            return publisherID;
        }
    }
}
