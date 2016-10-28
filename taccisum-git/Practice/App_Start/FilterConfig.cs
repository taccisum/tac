using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.App_Start.Attributes.Filter;
using Practice.Attributes;
using Practice.Attributes.Filter;

namespace Practice.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthenticationFilterAttribute());
            filters.Add(new HandleExceptionFilterAttribute());
            filters.Add(new LogRequestInfoFilterAttribute(true));
            filters.Add(new BrowseHistoryFilterAttribute());
        }
    }
}