﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Attributes;

namespace Practice.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogRequestInfoFilterAttribute(true));
            filters.Add(new AuthenticationFilterAttribute());
            filters.Add(new HandleExceptionFilterAttribute());
        }
    }
}