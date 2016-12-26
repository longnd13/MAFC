using Prj.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class DepartmentController : BaseController
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: Admin/Department
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDepartment(int branchId)
        {
            var list = _departmentService.GetDepartment(true, branchId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}