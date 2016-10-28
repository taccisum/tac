using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Common.CustomerException;
using Common.Global;
using Common.Tool.Extend;
using IoC.Manager;
using log4net;
using Model.Common;
using Model.Entity;
using Service.Impl.Sys;
using Service.Interf.Sys;
using WebGrease.Css.Extensions;

namespace Practice.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        #region Private Fields
        private IIoC _ioc;
        private ILog _log;
        #endregion

        #region Protected Fields
        protected readonly SysUserAuthorizationService AuthorizationService = new SysUserAuthorizationService();

        protected IIoC IoC { get { return _ioc ?? (_ioc = IoCManager.GetInstance().Create()); } }

        protected ILog Log { get { return _log ?? (_log = LogManager.GetLogger("Controller." + this.GetType().Name)); } }

        protected CurrentUserInfo CurrentUser { get { return AuthorizationService.CurrentUser(); } }
        #endregion

        #region Protected Constructor
        protected BaseController() { }
        #endregion

        #region Protected Methods
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
                CheckModelState();
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
                Debug.Write(this.GetType().Name + "在执行的过程中发生了异常: " + e.ToString());
                return Json(Failure(errMsg, e.ToString()), behavior);
#else
                return Json(Failure(errMsg, "系统内部异常，详情请查看日志"), behavior);
#endif
            }

            return Json(Success(data, succMsg), behavior);
        }


        private void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new CommonException(GetModelVerifyErrorMessage());
            }
        }

        private string GetModelVerifyErrorMessage()
        {
            return ModelState.Values.First(msv => msv.Errors.Count > 0).Errors.First().ErrorMessage;
        }
        #endregion
    }
}