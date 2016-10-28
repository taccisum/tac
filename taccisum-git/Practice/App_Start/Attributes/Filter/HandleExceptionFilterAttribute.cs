using System.Web.Mvc;
using log4net;
using Model.Common;

namespace Practice.Attributes.Filter
{
    public sealed class HandleExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var log = LogManager.GetLogger("Filter." + typeof(HandleExceptionFilterAttribute).Name);

            log.Error("执行请求的过程中发生了未经处理的异常", filterContext.Exception);
#if DEBUG
            filterContext.Result = new JsonResult()
            {
                Data = ApiResult.FailedResult("执行请求的过程中发生了未经处理的异常", filterContext.Exception.Message),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
#else
            filterContext.Result = new JsonResult()
            {
                Data = ApiResult.FailedResult("执行请求的过程中发生了未经处理的异常", "详情请查看日志")
            };
#endif
            filterContext.ExceptionHandled = true;
        }
    }
}