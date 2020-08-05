using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace prjC
{
    class CategoryDAO : DataAccess
    {
        public static int AddNewCategory(Category category)
        {
            string sql = "insert into [Categories]([CategoryName],[Description]) values (@categoryName, @description);\n" +
                "select SCOPE_IDENTITY();";
            SqlParameter param1 = new SqlParameter("@categoryName", SqlDbType.NVarChar)
            {
                Value = category.CategoryName
            };
            SqlParameter param2 = new SqlParameter("@description", SqlDbType.NVarChar)
            {
                Value = (category.Description.Length == 0) ? (object) DBNull.Value : category.Description
            };
            int categoryID = ExecuteScalar(sql, param1, param2);
            return categoryID;
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
    }
}
