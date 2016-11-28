using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers.Base.PhotoUpload
{
    public class PhotoUploadController : Controller
    {
        public JsonResult CutAndUpload()
        {
            var resolver = GetContextResolver();
            var context = resolver.Resolve();
            var handler = HandlerFactory.Create(context.Type);
            var result = handler.Upload(context);

            return Json(result, JsonRequestBehavior.DenyGet);
        }


        private AbstractContextResolver GetContextResolver()
        {
            ContextResolver type = GetContextResolverType();
            return ResolverFactory.Create(type);
        }

        private ContextResolver GetContextResolverType()
        {
            throw new NotImplementedException();
        }
    }
}