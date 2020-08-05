using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace prjC
{

    public class Employee
    {
        public string AccName { get; set; }
        public string AccPassword { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
        

        public string getRolesToString()
        {
            string s = "";
            foreach (Role r in Roles)
            {
                s += r.RoleName + ", ";
            }
            return s.Substring(0, s.Length - 2);
        }
        public static string InsertEmployee(string Accname, string AccPassword, string FirstName, string LastName, string Email, string Phone)
        {

            string AccID = "";

            if (AccountDAO.CheckEmployee(Accname)) return "failed";

            DataTable dt = AccountDAO.InsertEmployee(Accname, AccPassword, FirstName, LastName, Email, Phone);
            foreach (DataRow dr in dt.Rows)
            {
                AccID = dr["AccID"].ToString();
            }
            return AccID;

        }

        public static int UpdateEmployee(string ID, string Accname, string AccPassword, string FirstName, string LastName, string Email, string Phone)
        {
            return AccountDAO.UpdateEmployee(ID, Accname, AccPassword, FirstName, LastName, Email, Phone);
        }



        public static int AddFeatures(string AccID, List<Role> Roles)
        {
            int c = 0;
            foreach (Role f in Roles)
            {
                c += AccountDAO.InsertRolesWithAccID(AccID, f);

            }
            return c;
        }
        public static int UpdateFeatures(string AccID, List<Role> Roles)
        {
            int c = 0;
            AccountDAO.DeleteRolesWithAccID(AccID);
            foreach (Role f in Roles)
            {
                c += AccountDAO.UpdateRolesWithAccID(AccID, f);

            }
            return c;
        }


        public static Employee getEmployeeByLogin(string Username, string Password)
        {

            DataTable dt = DataAccess.GetAccountByLogin(Username, Password);
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Employee e = new Employee();
                e.AccName = dr["AccountName"].ToString();
                e.AccPassword = dr["AccountPassword"].ToString();
                e.ID = dr["EmployeeID"].ToString();
                e.FirstName = dr["FirstName"].ToString();
                e.LastName = dr["LastName"].ToString();
                e.Email = dr["Email"].ToString();
                e.Phone = dr["Phone"].ToString();
                e.Roles = RoleList.GetRoleByID(e.ID);
                
                return e;
            }
            return null;
        }

        private List<Feature> GetFeatures()
        {
            List<Feature> lstFeatures = new List<Feature>();
            foreach(Role r in Roles)
            {
                lstFeatures.AddRange(r.Features);
            }
            return lstFeatures;
        }
        public Boolean checkPermissionByNameOfPermisstion(string name, string code)
        {
           List<Feature> Features = GetFeatures();
            Feature tempFeature = new Feature();
            string constructedFeature = name + "_" + code;
            tempFeature.DisplayName = constructedFeature;
            foreach (Feature f in Features)
            {
                if (f.DisplayName.Equals(tempFeature.DisplayName)) return true;
            }
            return false;
        }
        public Boolean checkPermissionByName(string name)
        {
            List<Feature> Features = GetFeatures();
            foreach (Feature f in Features)
            {
                if (f.Name.Equals(name)) return true;
            }
            return false;
        }

        public Boolean checkPermissionByRole(string name)
        {
            List<Role> Roles = this.Roles;
            foreach (Role r in Roles)
            {
                if (r.RoleName.Equals(name)) return true;
            }
            return false;
        }


        public override bool Equals(object obj)
        {
            Employee t = (Employee)obj;
            return t.ID.Equals(this.ID);
        }

    }
    class EmployeeList {
        public static List<Employee> GetAccountBy(string FName,string LName, string AccountName, string Phone, string Email, Role role)
        {
            List<Employee> lst = new List<Employee>();
            DataTable dt =  AccountDAO.GetAccountBy(FName,LName, AccountName, Phone, Email, role);
            foreach (DataRow dr in dt.Rows)
            {
                Employee e = new Employee();
                e.AccName = dr["AccountName"].ToString();
                e.AccPassword = dr["AccountPassword"].ToString();
                e.ID = dr["EmployeeID"].ToString();
                e.FirstName = dr["FirstName"].ToString();
                e.LastName = dr["LastName"].ToString();
                e.Email = dr["Email"].ToString();
                e.Phone = dr["Phone"].ToString();
                e.Roles = RoleList.GetRoleByID(e.ID);
                //e.Features = FeatureList.GetFeaturesByListOfRole(e.Roles);
               if(!lst.Contains(e)) lst.Add(e);
            }
            return lst;
        }

    }
}
