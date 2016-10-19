using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Attributes;

namespace Practice.Controllers
{
    public class RedisDemoController : Controller
    {
        [LogRequestInfoFilter(false)]
        public ActionResult Index()
        {
            return View();
        }
    }
}