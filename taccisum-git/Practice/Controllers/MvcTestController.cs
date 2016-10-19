using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Controllers.Base;

namespace Practice.Controllers
{
    [Export]
    public class MvcTestController : BaseController
    {
        // GET: MvcTest
        public ActionResult Index()
        {
            return View();
        }

        public FilePathResult Png()
        {
            var path = Server.MapPath("../Image/alert_information_128px_1132500_easyicon.net.png");
            return new FilePathResult(path, "image/png");
        }

        public ActionResult Index1()
        {
            return HttpNotFound();
        }

        public JavaScriptResult Index2()
        {
            return JavaScript("<script>alert('javascript result')</scipt>");
        }

        public ActionResult Redirect()
        {
            return Redirect("/MvcTest/Index1");
        }

        public object NonActionResult()
        {
            return new
            {
                aa = "a",
                bb = "b"
            };
        }
        
        public JsonResult Aop()
        {
            return Json(new
            {
                tac = "hh"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}