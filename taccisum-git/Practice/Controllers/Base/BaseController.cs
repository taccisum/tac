using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using Common.CustomerException;
using Common.Global;
using Common.Tool.Extend;
using Common.Tool.Units;
using IoC.Manager;
using log4net;
using Model.Common;
using Model.Entity;
using Service.Interf.Sys;

namespace Practice.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        [Import]
        protected ISysUserService SysUserService { get; set; }

        private IIoC _ioc;
        protected IIoC IoC { get { return _ioc ?? (_ioc = IoCManager.GetInstance().Create()); } }

        private ILog _log;
        protected ILog Log { get { return _log ?? (_log = Log4NetHelper.GetLogger("Controller." + this.GetType().Name)); } }

        protected SysUser CurrentUser
        {
            get
            {
                var userId = CookiesHelper.Get(GlobalConfig.CURRENT_USER).ToGuid();
                return SysUserService.GetById(userId);
            }
        }


        protected BaseController() {}

        protected ApiResult Success(object data, string msg = "")
        {
            return ApiResult.SuccessResult(data, msg);
        }


        protected ApiResult Failure(string msg, string exception)
        {
            return ApiResult.FailedResult(msg, exception);
        }

        /// <summary>
        /// 封装TryCatch操作，返回统一格式内容，只适用于JsonResult
        /// </summary>
        /// <param name="func"></param>
        /// <param name="errMsg"></param>
        /// <param name="succMsg"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected JsonResult Try(Func<object> func, string errMsg, string succMsg,
            JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            object data;
            try
            {
                data = func();
            }
            catch (CommonException ce)
            {
                //业务异常，直接返回给前端
                //只返回异常描述，不返回堆栈track
                return Json(Failure(errMsg, ce.Message), behavior);
            }
            catch (Exception e)
            {
#if DEBUG
                //如果是debug模式，则将系统异常信息打印到输出窗口并直接返回给前端展示
                Debug.Write(this.GetType().Name + "在执行的过程中发生了异常: " + e.ToString());
                return Json(Failure(errMsg, e.ToString()), behavior);
#else
                Log.Error(e.ToString());        //如果是release，则只记录异常log。
                return Json(Failure(errMsg, "系统内部异常，详情请查看日志"), behavior);
#endif
            }

            return Json(Success(data, succMsg), behavior);
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                filterContext.ActionDescriptor.ActionName == "Login" && CurrentUser != null)
            {
                CookiesHelper.Remove(GlobalConfig.CURRENT_USER);
                CookiesHelper.Remove(GlobalConfig.AUTOLOGIN);
            }
            else if (CurrentUser == null && !(
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "User" &&
                (filterContext.ActionDescriptor.ActionName == "Verify" || filterContext.ActionDescriptor.ActionName == "Login")
                ))
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary(new {controller = "User", action = "Login"}));
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //todo:: 在这里编写语句修改发生异常时返回的内容

            Log.Error("调用API的过程中发生了未经处理的异常", filterContext.Exception);
        }
    }
}