using Prj.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj.Web.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        private ITestService _testSer;

        public TestController(ITestService testSer)
        {
            _testSer = testSer;
        }
        // GET: Admin/Test
        public ActionResult Index()
        {
            ViewBag.message = _testSer.AlertMessage();
            return View();
        }
    }
}