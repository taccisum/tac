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
using Practice.Controllers.Attributes;
using Practice.Controllers.Base;
using Service.Interf.Sys;

namespace Practice.Controllers
{
    [Export]
    public class UserController : BaseController
    {
        [Import]
        protected ISysUserManagementService SysUserManagerService { get; set; }


        [LogRequestFilter(false)]
        public ActionResult Login()
        {
            return View();
        }

        [LogRequestFilter(false)]
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

        [LogRequestFilter(false)]
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

        [LogRequestFilter(false)]
        public ActionResult Logout()
        {
            CookiesHelper.Remove(GlobalConfig.CURRENT_USER);
            CookiesHelper.Remove(GlobalConfig.AUTOLOGIN);
            return View("Login");
        }
    }
}