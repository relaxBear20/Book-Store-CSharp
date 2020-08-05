using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace prjC
{
    class AccountDAO : DataAccess
    {
        public static DataTable GetRoles()
        {
            string sql = "SELECT * FROM ROLES";
            return GetDataBySQL(sql);
        }
        public static DataTable GetFeatures()
        {
            string sql = "SELECT * FROM Features";
            return GetDataBySQL(sql);
        }
        
        public static int UpdateEmployee(string ID, string Accname, string AccPassword, string FirstName, string LastName, string Email, string Phone)
        {
            string sql = "UPDATE [dbo].[Employees] SET [AccountName] = @accName,[AccountPassword] = @AccPass,[FirstName] =  @FirstN,[LastName] = @LastN,[Phone] =  @Phone,[Email] = @Email WHERE EmployeeID = @ID";
            SqlParameter param0 = new SqlParameter("accName", System.Data.SqlDbType.NVarChar);
            param0.Value = Accname;
            SqlParameter param1 = new SqlParameter("AccPass", System.Data.SqlDbType.NVarChar);
            param1.Value = AccPassword;
            SqlParameter param2 = new SqlParameter("FirstN", System.Data.SqlDbType.NVarChar);
            param2.Value = FirstName;
            SqlParameter param3 = new SqlParameter("LastN", System.Data.SqlDbType.NVarChar);
            param3.Value = LastName;
            SqlParameter param4 = new SqlParameter("Phone", System.Data.SqlDbType.NVarChar);
            param4.Value = Email;
            SqlParameter param5 = new SqlParameter("Email", System.Data.SqlDbType.NVarChar);
            param5.Value = Phone;
            SqlParameter param6 = new SqlParameter("ID", System.Data.SqlDbType.NVarChar);
            param6.Value = ID;

            return ExecuteSQL(sql, param0, param1, param2, param3, param4, param5,param6);
        }


        public static DataTable InsertEmployee(string Accname, string AccPassword, string FirstName, string LastName, string Email, string Phone)
        {
            string sql = "INSERT INTO [dbo].[Employees]([AccountName] ,[AccountPassword] ,[FirstName] ,[LastName] ,[Phone] ,[Email])   VALUES (@accName,@AccPass,@FirstN,@LastN,@Phone,@Email) SELECT SCOPE_IDENTITY() AS AccID;";
            SqlParameter param0 = new SqlParameter("accName", System.Data.SqlDbType.NVarChar);
            param0.Value = Accname;
            SqlParameter param1 = new SqlParameter("AccPass", System.Data.SqlDbType.NVarChar);
            param1.Value = AccPassword;
            SqlParameter param2 = new SqlParameter("FirstN", System.Data.SqlDbType.NVarChar);
            param2.Value = FirstName;
            SqlParameter param3 = new SqlParameter("LastN", System.Data.SqlDbType.NVarChar);
            param3.Value = LastName;
            SqlParameter param4 = new SqlParameter("Phone", System.Data.SqlDbType.NVarChar);
            param4.Value = Email;
            SqlParameter param5 = new SqlParameter("Email", System.Data.SqlDbType.NVarChar);
            param5.Value = Phone;

            return GetDataBySQL(sql,param0,param1,param2,param3,param4,param5);
        }
        public static int InsertRolesWithAccID (string AccID, Role role)
        {
            string sql = "INSERT INTO [dbo].[Employee_Role]([EmployeeID] ,[RoleID])  VALUES (@AccID,@RoleID);";
            SqlParameter param0 = new SqlParameter("AccID", System.Data.SqlDbType.NVarChar);
            param0.Value = AccID;
            SqlParameter param1 = new SqlParameter("RoleID", System.Data.SqlDbType.NVarChar);
            param1.Value = role.ID;
            return ExecuteSQL(sql, param0, param1);
        }

        public static int DeleteRolesWithAccID(string AccID)
        {
            string sql = "DELETE FROM [dbo].[Employee_Role] WHERE EmployeeID = @AccID ";
            SqlParameter param0 = new SqlParameter("AccID", System.Data.SqlDbType.NVarChar);
            param0.Value = AccID;
            return ExecuteSQL(sql, param0);
        }
        public static int UpdateRolesWithAccID(string AccID, Role role)
        {
            string sql = "INSERT INTO [dbo].[Employee_Role]([EmployeeID] ,[RoleID])  VALUES (@AccID,@RoleID);";
            SqlParameter param0 = new SqlParameter("AccID", System.Data.SqlDbType.NVarChar);
            param0.Value = AccID;
            SqlParameter param1 = new SqlParameter("RoleID", System.Data.SqlDbType.NVarChar);
            param1.Value = role.ID;
            return ExecuteSQL(sql, param0, param1);
        }

        public static int InsertFeatureWithRoleID(string RoleID , Feature Features)
        {
            string sql = "INSERT INTO [dbo].[Role_Feature] ([RoleID],[FeatureID]) VALUES(@RoleID,@FID);";
            SqlParameter param0 = new SqlParameter("RoleID", System.Data.SqlDbType.NVarChar);
            param0.Value = RoleID;
            SqlParameter param1 = new SqlParameter("FID", System.Data.SqlDbType.NVarChar);
            param1.Value = Features.ID;
            return ExecuteSQL(sql,param0,param1);
        }
        public static bool RoleNameCheck (string Name)
        {
            string sql = "SELECT * FROM Roles WHERE RoleName = @Name";
            SqlParameter param0 = new SqlParameter("Name", System.Data.SqlDbType.NVarChar);
            param0.Value = Name;
            return GetDataBySQL(sql, param0).Rows.Count >= 1;
        }

        public static bool CheckEmployee(string Name)
        {
            string sql = "SELECT * FROM Employees WHERE AccountName = @Name";
            SqlParameter param0 = new SqlParameter("Name", System.Data.SqlDbType.NVarChar);
            param0.Value = Name;
            return GetDataBySQL(sql, param0).Rows.Count >= 1;
        }
        
        public static DataTable InsertRole(string Name)
        {
            string sql = "INSERT INTO [dbo].[Roles] ([RoleName])   VALUES (@Name) SELECT SCOPE_IDENTITY() AS RoleID";
            SqlParameter param0 = new SqlParameter("Name", System.Data.SqlDbType.NVarChar);
            param0.Value = Name;
            return GetDataBySQL(sql,param0);
        }

        

        public static DataTable GetRoleByID(string ID)
        {
            string sql = "SELECT DISTINCT * FROM Roles r , Employee_Role e WHERE e.EmployeeID = @id AND e.RoleID = r.RoleID";
            SqlParameter param0 = new SqlParameter("id", System.Data.SqlDbType.NVarChar);
            param0.Value = ID;
            return GetDataBySQL(sql, param0);
        }
        public static DataTable GetFeaturesByRoleID(string ID)
        {
            string sql = "SELECT * FROM Roles r , Role_Feature e,  Features f WHERE e.RoleID = @rid  AND e.RoleID = r.RoleID AND f.FeatureID = e.FeatureID";
            SqlParameter param0 = new SqlParameter("rid", System.Data.SqlDbType.NVarChar);
            param0.Value = ID;
            return GetDataBySQL(sql, param0);
        }
        public static DataTable GetAccountBy(string FName,string LName, string AccountName, string Phone, string Email, Role role)
        {
            string sql = "SELECT e.AccountPassword ,e.EmployeeID, e.AccountName ,e.FirstName ,e.LastName , e.Phone , e.Email,r.RoleName FROM Employees e , Employee_Role er, Roles r WHERE e.EmployeeID = er.EmployeeID AND r.RoleID = er.RoleID AND e.AccountName LIKE '%' + @AccountName + '%' AND e.FirstName LIKE '%' + @FristName + '%'  AND e.LastName LIKE '%' + @LastName + '%'  AND e.Email LIKE '%' + @Email + '%'  AND e.Phone LIKE '%' + @Phone + '%' ";
            SqlParameter param0 = new SqlParameter("FristName", System.Data.SqlDbType.NVarChar);
            param0.Value = FName;
            SqlParameter param4 = new SqlParameter("LastName", System.Data.SqlDbType.NVarChar);
            param4.Value = LName;
            SqlParameter param1 = new SqlParameter("AccountName", System.Data.SqlDbType.NVarChar);
            param1.Value = AccountName;
            SqlParameter param2 = new SqlParameter("Email", System.Data.SqlDbType.NVarChar);
            param2.Value = Phone;
            SqlParameter param3 = new SqlParameter("Phone", System.Data.SqlDbType.NVarChar);
            param3.Value = Email;
            if(role!= null)
            {
                sql += "AND r.RoleID = " + role.ID;
            }
            return GetDataBySQL(sql, param0, param1, param2, param3,param4);
        }
        public static DataTable GetTopEmployeeByMonth(string month)
        {
            string sql = "select top 5 [Employees].[EmployeeID], ([FirstName] + ' ' + [LastName]) as [EmployeeName], count(*) AS [BillsCreated]"
+ "from[Employees]"
+ "inner join[Bills] on[Employees].[EmployeeID] = [Bills].[EmployeeID]"
+ "where month([BillDate]) = @mon and year([BillDate]) = 2020"
+ "group by[Employees].[EmployeeID], [FirstName], [LastName]"
 + "       order by[BillsCreated] desc;";
            SqlParameter param0 = new SqlParameter("mon", System.Data.SqlDbType.NVarChar);
            param0.Value = month;
            return GetDataBySQL(sql, param0);
        }
    }
}
