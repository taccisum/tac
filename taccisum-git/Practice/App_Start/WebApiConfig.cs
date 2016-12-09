using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Practice.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //默认路由配置
            //config.Filters.Add(new WebsiteExceptionFilterAttribute());
            RouteTable.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional });
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy/MM/dd HH:mm:ss";
        }
    }
}