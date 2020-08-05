using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace prjC
{
    public class Feature
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public override bool Equals(object obj)
        {
            Feature f = (Feature)obj;

            return f.ID.Equals(this.ID);
        }
        
    }
    public class FeatureList
    {
        public static int InsertsFeaturesWithRoleID(string RoleID, List<Feature> Features)
        {
            
            int c = 0;
            foreach(Feature f in Features)
            {
                c += AccountDAO.InsertFeatureWithRoleID(RoleID , f);
               
            }
            return c;
        }
        public static List<Feature> GetFeatures()
        {
            List<Feature> e = new List<Feature>();
            DataTable dt = AccountDAO.GetFeatures();
            if (dt.Rows.Count == 0) return null;
            foreach (DataRow dr in dt.Rows)
            {
                Feature f = new Feature();
                f.ID = dr["FeatureID"].ToString();
                f.Name = dr["FeatureName"].ToString();
                f.Code = dr["FeatureCode"].ToString();
                f.DisplayName = f.Name +"_"+ f.Code;
                e.Add(f);
            }
            return e;
        }

        public static List<Feature> GetFeaturesByRoleID(string ID)
        {
            List<Feature> e = new List<Feature>();
            DataTable dt = AccountDAO.GetFeaturesByRoleID(ID);
           
            foreach (DataRow dr in dt.Rows)
            {
                Feature f = new Feature();
                f.ID = dr["FeatureID"].ToString();
                f.Name = dr["FeatureName"].ToString();
                f.Code = dr["FeatureCode"].ToString();
                f.DisplayName = f.Name + "_" + f.Code;

                e.Add(f);
            }
            return e;
        }

       


        public static List<Feature> GetFeaturesByListOfRole(List<Role> RoleList)
        {
            List<Feature> FeatureList = new List<Feature>();
            foreach(Role r in RoleList)
            {
                List<Feature> temp = GetFeaturesByRoleID(r.ID);
                foreach(Feature f in temp)
                {
                    if (!FeatureList.Contains(f)) FeatureList.Add(f);
                }
            }
            return FeatureList;
        }

        
    }
}
