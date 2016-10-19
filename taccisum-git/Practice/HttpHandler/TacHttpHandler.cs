using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.HttpHandler
{
    public class TacHttpHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("i'm writed from htpp handler's ProcessRequest()<br/>");
        }

        public bool IsReusable { get; private set; }
    }
}