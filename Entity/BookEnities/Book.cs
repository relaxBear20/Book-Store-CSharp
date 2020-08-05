
using System;
using System.Data;
using System.Data.SqlClient;

namespace prjC

{
    class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public DateTime PublicationDate { get; set; }
         public Book()
        {

        }
        public Book(int BookID, string Title, DateTime PublicationDate,
        decimal UnitPrice, int UnitsInStock, string Description)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.PublicationDate = PublicationDate;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.Description = Description;
        }
        public string CategoriesName
        {
            get
            {
                string categoriesName = "";
                string sql = "select [CategoryName] from [Categories]\n" +
                    "inner join [Book_Category] on [Categories].[CategoryID]=[Book_Category].[CategoryID]\n" +
                    "where [BookID]=@bookID;";
                SqlParameter param = new SqlParameter("@bookID", SqlDbType.Int)
                {
                    Value = BookID
                };
                DataTable dataTable = DataAccess.ExecuteReader(sql, param);
                for (int index = 0; index < dataTable.Rows.Count; index++)
                {
                    DataRow dataRow = dataTable.Rows[index];
                    if (index == dataTable.Rows.Count - 1)
                    {
                        categoriesName += dataRow["CategoryName"].ToString();
                    }
                    else
                    {
                        categoriesName += dataRow["CategoryName"].ToString() + ", ";
                    }
                }
                return categoriesName;
            }
            set { }
        }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Description { get; set; }
    }
}
