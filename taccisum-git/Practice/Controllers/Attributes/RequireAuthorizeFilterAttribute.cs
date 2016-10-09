using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Entity;

namespace Practice.Controllers.Attributes
{
    /// <summary>
    /// todo::not implement
    /// 验证用户登陆filter
    /// </summary>

    public sealed class RequireAuthorizeFilterAttribute : ActionFilterAttribute
    {
        private bool isRequireAuthorize;

        public RequireAuthorizeFilterAttribute(bool isRequireAuthorize)
        {
            this.isRequireAuthorize = isRequireAuthorize;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            if (isRequireAuthorize)
            {
                //todo:: 
            }

        }
    }
}