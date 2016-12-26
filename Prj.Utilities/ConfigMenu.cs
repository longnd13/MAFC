using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Utilities
{
  public class ConfigMenu
    {
        public static string ActviedMenu(string Group, string url)
        {        
            string active = "";

            // tài khoản
            if (Group == "Account" && (url.ToLower().Contains("/admin/account/index") ||
                                       url.ToLower().Contains("/admin/account/register")))
            {
                active = "active";
            }
            else if (Group == "AccountIndex" && url.ToLower().Contains("/admin/account/index"))
            {
                active = "active";
            }
            else if (Group == "AccountRegister" && url.ToLower().Contains("/admin/account/register"))
            {
                active = "active";
            }
            // phân quyền

            if (Group == "AccountIndex" && url.ToLower().Contains("/admin/account/index"))
            {
                active = "active";
            }
            else if (Group == "AccountRegister" && url.ToLower().Contains("/admin/account/register"))
            {
                active = "active";
            }
            else if (Group == "Account" && url.ToLower().Contains("/admin/account"))
            {
                active = "active";
            }
            else if (Group == "Permission" && (url.ToLower().Contains("/admin/permission") ||
                                           url.ToLower().Contains("/admin/featuregroup/index") ||
                                           url.ToLower().Contains("/admin/group") ||
                                           url.ToLower().Contains("/admin/feature/index")))
            {
                active = "active";
            }
            else if (Group == "PermissionGroup" && url.ToLower().Contains("/admin/group"))
            {
                active = "active";
            }
            else if (Group == "PermissionPer" && url.ToLower().Contains("/admin/permission"))
            {
                active = "active";
            }
            else if (Group == "PermissionFeature" && url.ToLower().Contains("/admin/feature/index"))
            {
                active = "active";
            }
            else if (Group == "PermissionFeatureGroup" && url.ToLower().Contains("/admin/featuregroup/index"))
            {
                active = "active";
            }
            // Branch

            if (Group == "Branch" && (url.ToLower().Contains("/admin/branch/index") ||
                                              url.ToLower().Contains("/admin/branch/create") ||
                                              url.ToLower().Contains("/admin/branch/update")))
            {
                active = "active";
            }
            else if (Group == "BranchIndex" && url.ToLower().Contains("/admin/branch/index"))
            {
                active = "active";
            }
            else if (Group == "BranchCreate" && url.ToLower().Contains("/admin/branch/create"))
            {
                active = "active";
            }
            
            return active;
        }
    }
}
