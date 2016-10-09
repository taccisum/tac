using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Controllers.Attributes;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        [LogRequestFilter(false)]
        public ActionResult Index()
        {
            return View();
        }

        [LogRequestFilter(false)]
        public ActionResult Test()
        {
            return View();
        }
    }
}