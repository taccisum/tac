using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.HttpModules
{
    public class TacHttpModule: IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }

        // 自己要针对一些事情进行处理的两个方法
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

            //response.Write("i'm write from HttpModule's BeginRequest<br />");
            //application.CompleteRequest();
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            //response.Write("i'm write from HttpModule's EndRequest<br />");
        }


        public void Dispose()
        {
            
        }
    }
}