using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Practice.Attributes
{
    /// <summary>
    /// 记录请求信息filter
    /// </summary>
    public sealed class LogRequestInfoFilterAttribute : ActionFilterAttribute
    {
        private bool isLogEnabled = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLogEnabled">是否允许对Action的请求信息进行记录</param>
        public LogRequestInfoFilterAttribute(bool isLogEnabled)
        {
            this.isLogEnabled = isLogEnabled;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (isLogEnabled)
            {
                var log = LogManager.GetLogger("Filter." + typeof (LogRequestInfoFilterAttribute).Name);
                var request = filterContext.HttpContext.Request;
                var sb = new StringBuilder();

                sb.Append("action will be invoked. \r\n");
                sb.Append("controller: " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "\r\n");
                sb.Append("action: " + filterContext.ActionDescriptor.ActionName + "\r\n");
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
                log.Debug(sb.ToString());
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (isLogEnabled)
            {
                var log = LogManager.GetLogger("Filter." + typeof(LogRequestInfoFilterAttribute).Name);
                var sb = new StringBuilder();

                sb.Append("action has been invoked. \r\n");
                sb.Append("controller: " + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "\r\n");
                sb.Append("action: " + filterContext.ActionDescriptor.ActionName + "\r\n");
                sb.Append("result type: " + filterContext.Result.GetType().Name + "\r\n");

                if (filterContext.Result is JsonResult)
                {
                    sb.Append("result value: " + ((JsonResult) filterContext.Result).Data.ToString());
                }

                log.Debug(sb.ToString());
            }

            base.OnActionExecuted(filterContext);
        }
    }
}