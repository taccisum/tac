using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Attributes;
using Practice.Attributes.Filter;
using Practice.Controllers.Base;
using Service.Interf.Sys;

namespace Practice.Controllers
{
    /// <summary>
    /// 系统框架提供的所有前端工具的使用演示demo页，新增的demo页请写在此路径下
    /// </summary>
    [Export]
    public class ToolDemoController : BaseController
    {
        [Import]
        protected Lazy<ISysUserManagementService> LazySysUserManagerService { get; set; }


        #region DataTables
        [LogRequestInfoFilter(false)]
        public ActionResult DataTables()
        {
            return View();
        }

        [LogRequestInfoFilter(false)]
        public ActionResult GetUserList(int pageindex)
        {
            if (Log.IsInfoEnabled)
                Log.Info("获取用户列表", new ApplicationException("hahaha"));


            var users = LazySysUserManagerService.Value.GetAll();
            var list = users.Select(u => new
            {
                u.ID,
                UserName = u.Uid,
                Password = u.Psd,
            });

            var tableData = new
            {
                draw = pageindex,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = list.OrderBy(u => u.UserName).Skip((pageindex - 1) * 10).Take(10)
            };

            if (Log.IsDebugEnabled)
                Log.Debug("获取列表数据成功，当前页：" + pageindex);

            //以下命名属性也可以
            //var tableData = new
            //{
            //    sEcho = pageindex,
            //    iTotalRecords = list.Count(),
            //    iTotalDisplayRecords = list.Count(),
            //    aaData = list.OrderBy(u => u.UserName).Skip((pageindex - 1) * 10).Take(10)
            //};

            return Json(
                tableData
                , JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AutoComplete
        [LogRequestInfoFilter(false)]
        public ActionResult AutoComplete()
        {
            return View();
        }
        #endregion

        #region Dialog
        [LogRequestInfoFilter(false)]
        public ActionResult Dialog()
        {
            return View();
        }

        [LogRequestInfoFilter(false)]
        public ActionResult D_Msgbox()
        {
            return View();
        }

        [LogRequestInfoFilter(false)]
        public ActionResult D_Dialog()
        {
            return View();
        }
        #endregion

        #region JCrop
        [LogRequestInfoFilter(false)]
        public ActionResult JCrop()
        {
            return View();
        }

        #endregion

        #region Gridster
        [LogRequestInfoFilter(false)]
        public ActionResult Gridster()
        {
            return View();
        }

        #endregion

        #region Sortable
        [LogRequestInfoFilter(false)]
        public ActionResult Sortable()
        {
            return View();
        }

        #endregion

        #region Gridly

        public ActionResult Gridly()
        {
            return View();
        }

        #endregion
    }
}