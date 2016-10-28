using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Global;
using IoC.Manager;
using Model.Common;
using Model.Entities;
using Service.Impl.Sys;
using Service.Interf.Sys;

namespace Practice.App_Start.Attributes.Filter
{
    public class BrowseHistoryFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }


        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result.GetType() == typeof(ViewResult))
            {
                ISysMenuService menuService = IoCManager.GetInstance().Create().Resolve<ISysMenuService>();


                var httpContext = filterContext.HttpContext;
                var urlReferrer = httpContext.Request.UrlReferrer == null ? "-" : httpContext.Request.UrlReferrer.ToString();
                var url = httpContext.Request.Url.ToString();
                var menu = menuService.GetMenuByUrl(httpContext.Request.Path);
                var user = new SysUserAuthorizationService().CurrentUser();


                var historyService = new PageBrowseHistoryService();
                historyService.InsertBrowseHistory(new PageBrowseHistory()
                {
                    UserId = user == null ? null : (Guid?) user.UserID,
                    UrlReferrer = urlReferrer,
                    Url = url,
                    RelativeMenuId = menu == null ? null : (Guid?) menu.ID,
                    IsAjaxRequest = httpContext.Request.IsAjaxRequest()
                });
            }
        }
    }
}