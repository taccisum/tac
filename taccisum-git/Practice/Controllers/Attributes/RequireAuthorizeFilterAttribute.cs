using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.Common;
using Model.Entity;
using Service.Impl.Sys;
using Service.Interf.Sys;

namespace Practice.Controllers.Attributes
{
    /// <summary>
    /// todo::not implement
    /// 验证用户登陆filter
    /// </summary>
    public class RequireAuthorizeFilterAttribute : AuthorizeAttribute
    {
        private bool isRequireAuthorize;

        private SysUserAuthorizationService authorizationService = new SysUserAuthorizationService(); 

        public RequireAuthorizeFilterAttribute(bool isRequireAuthorize)
        {
            this.isRequireAuthorize = isRequireAuthorize;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            if (isRequireAuthorize)
            {
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                    filterContext.ActionDescriptor.ActionName == "Login" && authorizationService.CurrentUser() != null)
                {
                    authorizationService.ClearSession();
                }
                else if (authorizationService.CurrentUser() == null && !(
                    filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                    (filterContext.ActionDescriptor.ActionName == "Verify" ||
                     filterContext.ActionDescriptor.ActionName == "Login")
                    ))
                {
                    if (filterContext.Controller.ControllerContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult()
                        {
                            Data = ApiResult.FailedResult("登陆超时，请重新登陆", "登陆超时，请重新登陆")
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult("Default",
                            new RouteValueDictionary(new { controller = "User", action = "Login" }));
                    }
                }
            }
        }

    }
}