using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Global;
using Common.Tool.Extend;
using Common.Tool.Units;
using IoC.Manager;
using log4net;
using Model.Common;
using Practice.Attributes;
using Practice.Attributes.Filter;
using Practice.Controllers.Base;
using Service.Interf.Sys;

namespace Practice.Controllers
{
    [Export]
    public class UserController : BaseController
    {
        [Import]
        protected ISysUserManagementService SysUserManagerService { get; set; }


        [LogRequestInfoFilter(false)]
        public ActionResult Login()
        {
            return View();
        }

        [LogRequestInfoFilter(false)]
        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Verify(string uid, string psd, bool remeber)
        {
            //todo::
            var valid = AuthorizationService.LoginVerify(uid, psd);

            if (valid)
            {
                if (remeber)
                {
                    //var token = _userBusiness.GenerateAutoLoginToken();
                    //CookiesHelper.Add(GlobalConfig.AUTOLOGIN.ToMD5(), token.ToString(), DateTime.Now.AddHours(2));
                }
            }
            else
            {
                Log.Info("用户\"" + uid + "\"登录失败");
            }


            return Json(valid, JsonRequestBehavior.DenyGet);
        }

        [LogRequestInfoFilter(false)]
        public ActionResult RegisterAccount(string uid, string psd, string rePsd)
        {
            if (psd != rePsd)
            {
                return Json(new ApiResult()
                {
                    Success = false,
                    Data = null,
                    Message = "两次输入的密码不相同"
                },JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(new ApiResult()
                {
                    Success = true,
                    Data = SysUserManagerService.Register(uid, psd),
                    Message = "注册成功"
                }, JsonRequestBehavior.DenyGet);
            }
        }

        [LogRequestInfoFilter(false)]
        public ActionResult Logout()
        {
            AuthorizationService.ClearSession();
            return Redirect("Login");
        }
    }
}