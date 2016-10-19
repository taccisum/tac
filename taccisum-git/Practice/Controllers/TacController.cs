using System.Web.Mvc;
using Practice.Controllers.Base;

namespace Practice.Controllers
{
    public class TacController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}