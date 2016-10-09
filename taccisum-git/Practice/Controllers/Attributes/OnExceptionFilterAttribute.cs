using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Practice.Controllers.Attributes
{
    public sealed class OnExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //var log = LogManager.GetLogger(typeof(OnExceptionFilterAttribute).Name);
            //log.Error("调用API的过程中发生了未经处理的异常", filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}