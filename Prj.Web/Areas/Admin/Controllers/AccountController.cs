using Prj.BusinessLogic.Interfaces;
using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj.Utilities;
namespace Prj.Web.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        IBranchService _branchService;
        IAccountService _accountService;
        public AccountController(IBranchService branchService, IAccountService accountService)
        {
            _branchService = branchService;
            _accountService = accountService;
        }
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult ChangePassword(AccountChangePassModel model)
        {
            //#region Permission
            //bool bPermission = _permissionService.PERMISSION(AccountIsAuthenticated(), ConfigPermission.ManagerAccount);
            //if (bPermission.Equals(false))
            //{
            //    return RedirectToAction("Index", "Mainternance", new { area = "Admin" });
            //}
            //#endregion
            model.ModifiedBy = AccountIsAuthenticated();
            model.UserName = AccountIsAuthenticated();

            MessageModel msg = _accountService.ChangePassword(model);
            ViewBag.message = Globals.ErrorMessage(msg.message, msg.result);
            return View();
        }

        public ActionResult CreateAccount()
        {
            ViewBag.listBranch = _branchService.GetBranch(true);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult CreateAccount(AccountModel model)
        {
            model.ModifiedBy = AccountIsAuthenticated();
            model.CreatedBy = AccountIsAuthenticated();
            model.bLock = true;

            MessageModel msg = _accountService.CreateAccount(model);
            if (msg.result == true)
            {
                return RedirectToAction("Index", "Account", new { area = "Admin" });
            }
            if (msg.code == -2)
            {
                msg.message = "UserName exist in system, please check again.";
            }

            ViewBag.message = Globals.ErrorMessage(msg.message, msg.result);
          
            return View();
        }
    }
}