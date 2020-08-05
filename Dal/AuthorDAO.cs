
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace prjC
{
    class AuthorDAO : DataAccess
    {
        public List<Author> getAuthorsByName(string name)
        {
            List<Author> authors = new List<Author>();
            string sql = @"select * from Authors where CONCAT(FirstName, ' ' ,lastName) like @name";
            SqlParameter AuthorName = new SqlParameter("name", SqlDbType.NVarChar);
            AuthorName.Value = "%" + name + "%";
            DataTable dt = GetDataBySQL(sql, AuthorName);
            foreach(DataRow dr in dt.Rows)
            {
                authors.Add(new Author(Int32.Parse(dr["AuthorID"].ToString()), dr["FirstName"].ToString(), dr["LastName"].ToString(), ""));
            }
            return authors;
        }
        public List<Book> getBookByAuthorID(string id)
        {
            List<Book> books = new List<Book>();
            string sql = @"select * from Books where AuthorID = @id";
            SqlParameter AuthorID = new SqlParameter("id", SqlDbType.NVarChar);
            AuthorID.Value =  id ;
            DataTable dt = GetDataBySQL(sql, AuthorID);
            foreach (DataRow dr in dt.Rows)
            {
                books.Add(new Book(Int32.Parse(dr["BookID"].ToString()), 
                    dr["Title"].ToString(), 
                    Convert.ToDateTime(dr["PublicationDate"]), 
                    Convert.ToDecimal (dr["UnitPrice"].ToString()),
                    (Int32.Parse(dr["UnitsInStock"].ToString())),
                    ""));
            }
            return books;
        }
        public static int AddNewAuthor(Author author)
        {
            string sql = "insert into [Authors]([FirstName],[LastName],[BirthDate],[About]) values (@firstName, @lastName, @birthDate, @about);\n" +
                "select SCOPE_IDENTITY();";
            SqlParameter param1 = new SqlParameter("@firstName", SqlDbType.NVarChar)
            {
                Value = author.FirstName
            };
            SqlParameter param2 = new SqlParameter("@lastName", SqlDbType.NVarChar)
            {
                Value = (author.LastName.Length == 0) ? (object)DBNull.Value : author.LastName
            };
            SqlParameter param3 = new SqlParameter("@birthDate", SqlDbType.DateTime)
            {
                Value = author.BirthDate
            };
            SqlParameter param4 = new SqlParameter("@about", SqlDbType.NVarChar)
            {
                Value = (author.About.Length == 0) ? (object)DBNull.Value : author.About
            };
            int authorID = ExecuteScalar(sql, param1, param2, param3, param4);
            return authorID;
        }

        public static List<Author> SelectAllAuthors()
        {
            List<Author> authors = new List<Author>(0);
            string sql = "select * from [Authors] order by [FirstName];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Author author = new Author
                {
                    AuthorID = Convert.ToInt32(dataRow["AuthorID"].ToString()),
                    FirstName = dataRow["FirstName"].ToString(),
                    LastName = dataRow["LastName"].ToString(),
                    About = dataRow["About"].ToString()
                };
                authors.Add(author);
            }
            return authors;
        }

    }
}
