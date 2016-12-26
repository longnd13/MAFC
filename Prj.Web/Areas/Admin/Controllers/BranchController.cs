using Prj.BusinessLogic.Interfaces;
using Prj.BusinessLogic.Models;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class BranchController : BaseController
    {
        IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;        
        }
        // GET: Admin/Branch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(int? Page)
        {

            int pageIndex = Protector.Int(Page, 1); // nếu page = 0 thì gán page = 1
            int pageSize = ConstantsHandler.PAGE_50;
            var model = new BranchModel();
            var list = _branchService.GetAll(model, pageIndex, pageSize);
            long lCount = list.Count;
            #region Paging
            if (lCount > 0)
            {

                ViewData["Stt"] = (pageIndex - 1) * pageSize + 1;
                if (Paging.GetUrl(this.Request.Url.PathAndQuery) == this.Request.Url.AbsolutePath)
                {
                    ViewData["Page"] = Paging.PagingAdmin(this.Request.Url.AbsolutePath, lCount, pageSize, pageIndex, 1);
                }
                else
                {
                    ViewData["Page"] = Paging.PagingAdmin(Paging.GetUrl(this.Request.Url.PathAndQuery), lCount, pageSize, pageIndex, 2);
                }
            }
            #endregion

            ViewBag.listBranch = list.List;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection fc)
        {
            return View();
        }
        public ActionResult Create()
        {
            try
            {
             
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult Create(BranchModel model)
        {
            try
            {
                var msg = new MessageModel();
                model.CreatedBy = AccountIsAuthenticated();
                model.ModifiedBy = AccountIsAuthenticated();
                msg = _branchService.Create(model);

                ViewBag.message = Globals.ErrorMessage(msg.message, msg.result);
                return View();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            if (id > 0)
            {

               var result = _branchService.GetById(id);
                return View(result);
            }
            else
            {
                return RedirectToAction("Index", "Branch", new { area = "Admin" });
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult Update(FormCollection fc, BranchModel model)
        {
            try
            {
                model.ModifiedBy = AccountIsAuthenticated();
                var msg = _branchService.Update(model);
                ViewBag.message = Globals.ErrorMessage(msg.message, msg.result);
                return View();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return View();
        }

        public JsonResult Delete(int id)
        {
            string msg = "";
            try
            {
                var result = _branchService.Delete(id);
                if (result == true)
                {
                    msg = "OK";
                }
                else
                {
                    msg = "ERROR";
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}