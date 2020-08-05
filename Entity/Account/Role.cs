using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace prjC
{
    public class Role
    {
        public string ID { get; set; }
        public string RoleName { get; set; }

        public List<Feature> Features { get; set; }

        public override bool Equals(object obj)
        {
            Role t = (Role)obj;
            return this.ID.Equals(t.ID);
        }

        public  static string InsertRole(string Name)
        {
            if (AccountDAO.RoleNameCheck(Name)) return "failed";
            string roleID = "";
            DataTable dt = AccountDAO.InsertRole(Name );
            foreach (DataRow dr in dt.Rows)
            {
                roleID = dr["RoleID"].ToString();
            }
            return roleID;
        }

       
    }
     public class RoleList 
    {
        public static List<Role> GetRoleByID(string ID)
        {
            List<Role> List = new List<Role>();
            DataTable dt = AccountDAO.GetRoleByID(ID);
            
            foreach (DataRow dr in dt.Rows)
            {
                Role e = new Role();
                    e.ID = dr["RoleID"].ToString();
                    e.RoleName = dr["RoleName"].ToString();
                e.Features = FeatureList.GetFeaturesByRoleID(e.ID);
                List.Add(e);
            }
            return List;
        }

        public static List<Role> GetRoles()
        {
            List<Role> List = new List<Role>();
            DataTable dt = AccountDAO.GetRoles();
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Role e = new Role();
                e.ID = dr["RoleID"].ToString();
                e.RoleName = dr["RoleName"].ToString();
                e.Features = FeatureList.GetFeaturesByRoleID(e.ID);
                List.Add(e);
            }
            return List;
        }
    }

}
