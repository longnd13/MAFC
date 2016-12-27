using Prj.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class DashBoardController : BaseController
    {
       
        public DashBoardController(IAccountService accountService, IPermissionService permissionService) : base(accountService, permissionService)
        {
    
        }

        // GET: Admin/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}