using Prj.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IAccountService _accountService;
        protected readonly IPermissionService _permissionService;

        public BaseController(IAccountService accountService, IPermissionService permissionService)
        {
            _accountService = accountService;
            _permissionService = permissionService;
        }
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