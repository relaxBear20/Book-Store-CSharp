
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace prjC
{
    class BookDAO : DataAccess
    {

        public static int AddNewBook(string title, int authorID, int publisherID, DateTime publicationDate, List<int> categoriesID, decimal unitPrice, string description)
        {
            string sql = "insert into [Books]([Title],[AuthorID],[PublisherID],[PublicationDate],[UnitPrice],[UnitsInStock],[Description]) values\n" +
                "(@title, @authorID, @publisherID, @publicationDate, @unitPrice, 0, @description);\n" +
                "select SCOPE_IDENTITY();";
            SqlParameter parameter1 = new SqlParameter("@title", SqlDbType.NVarChar)
            {
                Value = title
            };
            SqlParameter parameter2 = new SqlParameter("@authorID", SqlDbType.Int)
            {
                Value = authorID
            };
            SqlParameter parameter3 = new SqlParameter("@publisherID", SqlDbType.Int)
            {
                Value = publisherID
            };
            SqlParameter parameter4 = new SqlParameter("@publicationDate", SqlDbType.Date)
            {
                Value = publicationDate
            };
            SqlParameter parameter5 = new SqlParameter("@unitPrice", SqlDbType.Decimal)
            {
                Value = unitPrice
            };
            SqlParameter parameter6 = new SqlParameter("@description", SqlDbType.NVarChar)
            {
                Value = description
            };
            int bookID = ExecuteScalar(sql, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
            foreach (int categoryID in categoriesID)
            {
                sql = "insert into [Book_Category]([BookID],[CategoryID])\n" +
                    "values (@bookID, @categoryID)";
                SqlParameter parameter7 = new SqlParameter("@bookID", SqlDbType.Int)
                {
                    Value = bookID
                };
                SqlParameter parameter8 = new SqlParameter("@categoryID", SqlDbType.Int)
                {
                    Value = categoryID
                };
                ExecuteNonQuery(sql, parameter7, parameter8);
            }
            return bookID;
        }
        public static List<string> SelectAllTitle()
        {
            List<string> booksTitle = new List<string>(0);
            string sql = "select [Title] from [Books];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                booksTitle.Add(dataRow["Title"].ToString());
            }
            return booksTitle;
        }
        public static DataTable GetAllAuthor()  
        {
            string sql = "SELECT * FROM Authors";
            return GetDataBySQL(sql);
        }
        public static DataTable GetCategories()
        {
            string sql = "SELECT * FROM Categories";
            return GetDataBySQL(sql);
        }
        public static DataTable GetPublishers()
        {
            string sql = "SELECT * FROM Publishers";
            return GetDataBySQL(sql);
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

        public static List<Category> SelectAllCategories()
        {
            List<Category> categories = new List<Category>(0);
            string sql = "select * from [Categories] order by [CategoryName];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Category category = new Category
                {
                    CategoryID = Convert.ToInt32(dataRow["CategoryID"].ToString()),
                    CategoryName = dataRow["CategoryName"].ToString(),
                    Description = dataRow["Description"].ToString()
                };
                categories.Add(category);
            }
            return categories;
        }
        public static int ImportBook(int bookID, int importUnits)
        {
            string sql = "update [Books] set [UnitsInStock] = [UnitsInStock] + @importUnits\n" +
                "where [BookID] = @bookID;";
            SqlParameter parameter1 = new SqlParameter("@importUnits", SqlDbType.Int)
            {
                Value = importUnits
            };
            SqlParameter parameter2 = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            return ExecuteNonQuery(sql, parameter1, parameter2);
        }

        public static List<Book> SearchBooks(string title, int authorID, int publisherID, List<int> categoriesID, PublicationDateCondition pdc)
        {
            List<Book> books = new List<Book>(0);
            string sql = "select [BookID],[Title],\n" +
                "([FirstName] + ' ' + [LastName]) AS [AuthorName],\n" +
                "[PublisherName],[PublicationDate],[UnitPrice],[UnitsInStock] from [Books]\n" +
                "inner join [Authors] on [Books].[AuthorID]=[Authors].[AuthorID]\n" +
                "inner join [Publishers] on [Books].[PublisherID]=[Publishers].[PublisherID]\n" +
                "where [Books].[Title] like '%' + @title + '%'\n";
            sql = AddAuthorConditionToSearchBookQuery(sql, authorID);
            sql = AddPublisherConditionToSearchBookQuery(sql, publisherID);
            sql = AddCategoryConditionToSearchBookQuery(sql, categoriesID);
            sql = AddPublicationDateConditionToSearchBookQuery(sql, pdc);
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar)
            {
                Value = title
            };
            SqlParameter param2 = new SqlParameter("@authorID", SqlDbType.Int)
            {
                Value = authorID
            };
            SqlParameter param3 = new SqlParameter("@publisherID", SqlDbType.Int)
            {
                Value = publisherID
            };
            SqlParameter param4 = new SqlParameter("@numCategory", SqlDbType.Int)
            {
                Value = categoriesID.Count
            };
            DataTable dataTable = ExecuteReader(sql, param1, param2, param3, param4);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Book book = new Book()
                {
                    BookID = Convert.ToInt32(dataRow["BookID"].ToString()),
                    Title = dataRow["Title"].ToString(),
                    AuthorName = dataRow["AuthorName"].ToString(),
                    PublisherName = dataRow["PublisherName"].ToString(),
                    PublicationDate = Convert.ToDateTime(dataRow["PublicationDate"].ToString()),
                    UnitPrice = Convert.ToDecimal(dataRow["UnitPrice"].ToString()),
                    UnitsInStock = Convert.ToInt32(dataRow["UnitsInStock"].ToString())
                };
                books.Add(book);
            }
            return books;
        }

        private static string AddAuthorConditionToSearchBookQuery(string sql, int authorID)
        {
            if (authorID == 0)
            {
                return sql;
            }
            return sql += "and [Books].[AuthorID] = @authorID\n";
        }

        private static string AddPublisherConditionToSearchBookQuery(string sql, int publisherID)
        {
            if (publisherID == 0)
            {
                return sql;
            }
            return sql += "and [Books].[PublisherID] = @publisherID\n";
        }

        private static string AddCategoryConditionToSearchBookQuery(string sql, List<int> categoriesID)
        {
            if (categoriesID.Count == 0)
            {
                return sql;
            }
            sql += "and [Books].[BookID] in\n" +
                "(select [BookID] from [Book_Category] where [CategoryID] in (\n";
            for (int index = 0; index < categoriesID.Count; index++)
            {
                if (index == categoriesID.Count - 1)
                {
                    sql += categoriesID[index];
                }
                else
                {
                    sql += categoriesID[index] + ",";
                }
            }
            return sql += ") group by [BookID] having count(*) = @numCategory)\n";
        }

        private static string AddPublicationDateConditionToSearchBookQuery(string sql, PublicationDateCondition pdc)
        {
            if (pdc == null)
            {
                return sql;
            }
            string condition = pdc.Condition;
            string firstDayOfMonth = "'" + pdc.Year + "-" + pdc.Month + "-01'";
            if (condition.Equals("During"))
            {
                string lastDayOfMonth = "EOMONTH(" + firstDayOfMonth + ")";
                sql += "and [PublicationDate] between " + firstDayOfMonth + " and " + lastDayOfMonth;
            }
            else if (condition.Equals("Before"))
            {
                sql += "and [PublicationDate] < " + firstDayOfMonth;
            }
            else if (condition.Equals("After"))
            {
                sql += "and [PublicationDate] >= " + firstDayOfMonth;
            }
            return sql += "\n";
        }

        public static int SelectMinPublicationYear()
        {
            string sql = "select year(min([PublicationDate])) AS [MinPublicationYear] from [Books];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return Convert.ToInt32(dataRow["MinPublicationYear"].ToString());
            }
            return 0;
        }

        public static int SelectMaxPublicationYear()
        {
            string sql = "select year(max([PublicationDate])) AS [MaxPublicationYear] from [Books];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return Convert.ToInt32(dataRow["MaxPublicationYear"].ToString());
            }
            return 0;
        }

        public static Book SelectBookByBookID(int bookID)
        {
            string sql = "select [BookID],[Title],\n" +
                "([FirstName] + ' ' + [LastName]) AS [AuthorName],\n" +
                "[PublisherName],[PublicationDate],[UnitPrice],[UnitsInStock] from [Books]\n" +
                "inner join [Authors] on [Books].[AuthorID]=[Authors].[AuthorID]\n" +
                "inner join [Publishers] on [Books].[PublisherID]=[Publishers].[PublisherID]\n" +
                "where [BookID]=@bookID;";
            SqlParameter param = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            DataTable dataTable = ExecuteReader(sql, param);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Book book = new Book()
                {
                    BookID = Convert.ToInt32(dataRow["BookID"].ToString()),
                    Title = dataRow["Title"].ToString(),
                    AuthorName = dataRow["AuthorName"].ToString(),
                    PublisherName = dataRow["PublisherName"].ToString(),
                    PublicationDate = Convert.ToDateTime(dataRow["PublicationDate"].ToString()),
                    UnitPrice = Convert.ToDecimal(dataRow["UnitPrice"].ToString()),
                    UnitsInStock = Convert.ToInt32(dataRow["UnitsInStock"].ToString())
                };
                return book;
            }
            return null;
        }

        public static void InsertBill(int employeeID)
        {
            string sql = "insert into [Bills]([BillDate],[EmployeeID]) values (getdate(), @employeeID);";
            SqlParameter param = new SqlParameter("@employeeID", SqlDbType.Int)
            {
                Value = employeeID
            };
            ExecuteNonQuery(sql, param);
        }

        public static int SelectMaxBillID()
        {
            string sql = "select max([BillID]) as [MaxBillID] from [Bills];";
            DataTable dataTable = ExecuteReader(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return Convert.ToInt32(dataRow["MaxBillID"].ToString());
            }
            return 0;
        }

        public static void InsertBillDetails(int billID, int bookID, int quantity, double unitPrice, double discount)
        {
            string sql = "insert into [Bill_Details]([BillID],[BookID],[Quantity],[UnitPrice],[Discount]) values\n" +
                "(@billID, @bookID, @quantity, @unitPrice, @discount);";
            SqlParameter param1 = new SqlParameter("@billID", SqlDbType.Int)
            {
                Value = billID
            };
            SqlParameter param2 = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            SqlParameter param3 = new SqlParameter("@quantity", SqlDbType.Int)
            {
                Value = quantity
            };
            SqlParameter param4 = new SqlParameter("@unitPrice", SqlDbType.Decimal)
            {
                Value = unitPrice
            };
            SqlParameter param5 = new SqlParameter("@discount", SqlDbType.Decimal)
            {
                Value = discount
            };
            ExecuteNonQuery(sql, param1, param2, param3, param4, param5);
        }

        public static int SelectUnitsInStock(int bookID)
        {
            string sql = "select [UnitsInStock] from [Books] where [BookID]=@bookID;";
            SqlParameter param = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            DataTable dataTable = ExecuteReader(sql, param);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                return Convert.ToInt32(dataRow["UnitsInStock"].ToString());
            }
            return 0;
        }

        public static void UpdateUnitsInStock(int bookID, int unitsInStock)
        {
            string sql = "update [Books] set [UnitsInStock]=@unitsInStock where [BookID]=@bookID;";
            SqlParameter param1 = new SqlParameter("@unitsInStock", SqlDbType.Int)
            {
                Value = unitsInStock
            };
            SqlParameter param2 = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            ExecuteNonQuery(sql, param1, param2);
        }

        public static List<Category> SelectCategoriesByBookID(int bookID)
        {
            List<Category> categories = new List<Category>(0);
            string sql = "select [Categories].[CategoryID],[CategoryName],[Description] from [Categories]\n" +
                "inner join [Book_Category] on [Categories].[CategoryID]=[Book_Category].[CategoryID]\n" +
                "where [BookID]=@bookID;";
            SqlParameter param = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            DataTable dataTable = ExecuteReader(sql, param);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Category category = new Category()
                {
                    CategoryID = Convert.ToInt32(dataRow["CategoryID"].ToString()),
                    CategoryName = dataRow["CategoryName"].ToString(),
                    Description = dataRow["Description"].ToString()
                };
                categories.Add(category);
            }
            return categories;
        }

        public static DataTable GetTopBookByMonth(string month) 
        {
            string sql =
                "select top 5  [Bill_Details].[BookID], [Books].[Title], count(*) as [UnitsSold]"
        + " from[Bill_Details]"
        +" inner join[Books] on[Bill_Details].[BookID] = [Books].[BookID]"
        +" inner join[Bills] on[Bill_Details].[BillID] = [Bills].BillID"
        +" where month([BillDate]) = @mon and year([BillDate]) = 2020"
        +" group by[Bill_Details].[BookID], [Books].[Title]"
        +" order by[UnitsSold] desc;";
            SqlParameter param = new SqlParameter("@mon", SqlDbType.NVarChar)
            {
                Value = month
            };
            return GetDataBySQL(sql , param);
        }
        public static int EditBook(string title, int authorID, int publisherID, DateTime publicationDate, List<int> categoriesID, decimal unitPrice, string description, int bookID)
        {
            UpdateBookData(title, authorID, publisherID, publicationDate, unitPrice, description, bookID);
            DeleteOldCategoriesByBookID(bookID);
            return InsertNewCategoriesByBookID(bookID, categoriesID);
        }

        private static void UpdateBookData(string title, int authorID, int publisherID, DateTime publicationDate, decimal unitPrice, string description, int bookID)
        {
            string sql = "update [Books] set\n" +
                "[Title]=@title,[AuthorID]=@authorID,[PublisherID]=@publisherID,[PublicationDate]=@publicationDate,[UnitPrice]=@unitPrice,[Description]=@description\n" +
                "where [BookID]=@bookID;";
            SqlParameter parameter1 = new SqlParameter("@title", SqlDbType.NVarChar)
            {
                Value = title
            };
            SqlParameter parameter2 = new SqlParameter("@authorID", SqlDbType.Int)
            {
                Value = authorID
            };
            SqlParameter parameter3 = new SqlParameter("@publisherID", SqlDbType.Int)
            {
                Value = publisherID
            };
            SqlParameter parameter4 = new SqlParameter("@publicationDate", SqlDbType.Date)
            {
                Value = publicationDate
            };
            SqlParameter parameter5 = new SqlParameter("@unitPrice", SqlDbType.Decimal)
            {
                Value = unitPrice
            };
            SqlParameter parameter6 = new SqlParameter("@description", SqlDbType.NVarChar)
            {
                Value = description
            };
            SqlParameter parameter7 = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            ExecuteNonQuery(sql, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7);
        }

        private static void DeleteOldCategoriesByBookID(int bookID)
        {
            string sql = "delete from [Book_Category] where [BookID] = @bookID;";
            SqlParameter parameter = new SqlParameter("@bookID", SqlDbType.Int)
            {
                Value = bookID
            };
            ExecuteNonQuery(sql, parameter);
        }

        private static int InsertNewCategoriesByBookID(int bookID, List<int> categoriesID)
        {
            string sql = "insert into [Book_Category]([BookID],[CategoryID]) values (@bookID, @categoryID);";
            int numRows = 0;
            foreach (int categoryID in categoriesID)
            {
                SqlParameter parameter1 = new SqlParameter("@bookID", SqlDbType.Int)
                {
                    Value = bookID
                };
                SqlParameter parameter2 = new SqlParameter("@categoryID", SqlDbType.Int)
                {
                    Value = categoryID
                };
                ExecuteNonQuery(sql, parameter1, parameter2);
                numRows++;
            }
            return numRows;
        }
    }
}
