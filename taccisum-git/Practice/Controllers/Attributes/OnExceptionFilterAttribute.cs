using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using log4net;
using Model.Common;

namespace Practice.Controllers.Attributes
{
    public sealed class OnExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var log = LogManager.GetLogger("Filter." + typeof(OnExceptionFilterAttribute).Name);

            log.Error("执行请求的过程中发生了未经处理的异常", filterContext.Exception);
#if DEBUG
            filterContext.Result = new JsonResult()
            {
                Data = ApiResult.FailedResult("执行请求的过程中发生了未经处理的异常", filterContext.Exception.Message)
            };
#else
            filterContext.Result = new JsonResult()
            {
                Data = ApiResult.FailedResult("执行请求的过程中发生了未经处理的异常", "详情请查看日志")
            };
#endif
        }
    }
}