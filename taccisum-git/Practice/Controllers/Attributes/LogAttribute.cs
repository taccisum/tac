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
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            
            ILog log = Log4NetHelper.GetLogger(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
            var request = filterContext.HttpContext.Request;

            var sb = new StringBuilder();
            sb.Append("方法" + filterContext.ActionDescriptor.ActionName + "被调用，");
            sb.Append("请求方式：" + request.HttpMethod + "\r\n");
            sb.Append("请求参数：\r\nQueryString: " + request.QueryString + "\r\n");
            if (request.HttpMethod == "POST")
            {
                var sr  = new StreamReader(request.InputStream);

                var temp = sr.ReadToEnd();
                temp = HttpUtility.UrlDecode(temp, Encoding.UTF8);

                sb.Append("POST Data: " + temp);
                sr.Close();
            }

            log.Info(sb.ToString());

        }
    }
}