using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Common.Tool.Units;
using log4net;

namespace Practice.Controllers.Attributes
{
    /// <summary>
    /// 记录请求信息filter
    /// </summary>
    public sealed class LogRequestFilterAttribute : ActionFilterAttribute
    {
        private bool isLogEnabled = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogEnabled">是否允许对Action的请求信息进行记录</param>
        public LogRequestFilterAttribute(bool isLogEnabled)
        {
            this.isLogEnabled = isLogEnabled;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (isLogEnabled)
            {
                var log = LogManager.GetLogger(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                var request = filterContext.HttpContext.Request;
                var sb = new StringBuilder();

                sb.Append("\r\naction: " + filterContext.ActionDescriptor.ActionName + " will be invoked\r\n");
                sb.Append("type: " + request.HttpMethod + "\r\n");
                if (!string.IsNullOrWhiteSpace(request.QueryString.ToString()))
                {
                    sb.Append("querystring: \r\n　　" + request.QueryString + "\r\n");
                }

                if (request.HttpMethod == "POST")
                {
                    var sr = new StreamReader(request.InputStream);
                    //todo:: 这里只是对post的字符串数据作了简单的处理，如果是其它mime格式的流可能会出问题
                    var temp = sr.ReadToEnd();
                    temp = HttpUtility.UrlDecode(temp, Encoding.UTF8);
                    sb.Append("post data(ContentType: " + request.ContentType + "): \r\n　　" + temp);
                    sr.Close();
                }
                log.Info(sb.ToString());
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (isLogEnabled)
            {
                var log = LogManager.GetLogger(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                var sb = new StringBuilder();

                sb.Append("\r\naction: " + filterContext.ActionDescriptor.ActionName + " has been invoked\r\n");
                sb.Append("result type: " + filterContext.Result.GetType().Name + "\r\n");

                if (filterContext.Result is JsonResult)
                {
                    sb.Append("result value: " + ((JsonResult) filterContext.Result).Data.ToString());
                }

                log.Info(sb.ToString());
            }

            base.OnActionExecuted(filterContext);
        }
    }
}