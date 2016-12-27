using Prj.BusinessLogic.Interfaces;
using Prj.BusinessLogic.Models;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class AuthenController : BaseController
    {
       
       public AuthenController(IAccountService accountService, IPermissionService permissionService) : base(accountService, permissionService)
        {

        }
        // GET: Admin/Authen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "DashBoard", new { area = "Admin" });
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LogIn(AccountModel model)
        {
            var msgModel = _accountService.CheckLogin(model);
            if (msgModel.result.Equals(true))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                string sReturnUrl = Protector.String(Request.QueryString["ReturnUrl"]);
                if (sReturnUrl == "")
                {
                    return RedirectToAction("Index", "DashBoard", new { area = "Admin" });
                }
                return Redirect(sReturnUrl);
            }
            else
            {
                ViewBag.message = Globals.ErrorMessage("UserName or Password Incorrect.", msgModel.result);
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Authen", new { area = "Admin" });
        }
    }
}