using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Model.Common;
using Service.Impl.Sys;

namespace Practice.Attributes
{
    /// <summary>
    /// 验证用户登陆filter
    /// </summary>
    public class AuthenticationFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        /// <summary>
        /// 与登陆验证相关的actions
        /// </summary>
        private static readonly List<LimitedAction> loginActions = new List<LimitedAction>()
        {
            new LimitedAction("User", "Login"),
            new LimitedAction("User", "Verify"),
        };
        /// <summary>
        /// 无需身份验证的actions
        /// </summary>
        private static readonly List<LimitedAction> nonRequireAuthorizationActions = new List<LimitedAction>()
        {
            new LimitedAction("Tac")
        };

        private SysUserAuthorizationService authorizationService = new SysUserAuthorizationService();


        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (authorizationService.CurrentUser() == null)
            {
                if (!ActionIn(filterContext, loginActions))
                {
                    if (!ActionIn(filterContext, nonRequireAuthorizationActions))
                    {
                        if (filterContext.Controller.ControllerContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.Result = LoginTimeoutResult();
                        }
                        else
                        {
                            filterContext.Result = RedirectToLoginResult();
                        }
                    }
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            return;
        }

        private JsonResult LoginTimeoutResult()
        {
            return new JsonResult()
            {
                Data = ApiResult.FailedResult("登陆超时，请重新登陆", "登陆超时，请重新登陆")
            };
        }

        private RedirectToRouteResult RedirectToLoginResult()
        {
            return new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "User", action = "Login" }));
        }

        private bool ActionIn(AuthenticationContext filterContext, IEnumerable<LimitedAction> list)
        {
            foreach (var item in list)
            {
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == item.Controller)
                {
                    if (string.IsNullOrWhiteSpace(item.Action) || item.Action.Trim() == "*")
                    {
                        return true;
                    }
                    else
                    {
                        if (filterContext.ActionDescriptor.ActionName == item.Action)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        private class LimitedAction
        {
            public LimitedAction(string controllerName, string actionName = null)
            {
                Controller = controllerName;
                Action = actionName;
            }

            /// <summary>
            /// controller名称
            /// </summary>
            public string Controller { get; set; }
            /// <summary>
            /// action名称，null或空或*代表匹配controller下的所有action
            /// </summary>
            public string Action { get; set; }
        }

    }
}