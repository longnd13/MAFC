using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/BAse
        public string AccountIsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
            {
                return User.Identity.Name;
            }
            else
            {
                return null;
            }
        }
    }
}