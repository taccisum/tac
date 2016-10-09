using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practice.Controllers.Attributes;
using Practice.Controllers.Base;

namespace Practice.Controllers
{
    /// <summary>
    /// 系统框架提供的所有前端工具的使用演示demo页，新增的demo页请写在此路径下
    /// </summary>
    [Export]
    public class ToolDemoController : BaseController
    {
        #region DataTables
        [LogRequestFilter(false)]
        public ActionResult DataTables()
        {
            return View();
        }

        [LogRequestFilter(false)]
        public ActionResult GetUserList(int pageindex)
        {
            if (Log.IsInfoEnabled)
                Log.Info("获取用户列表", new ApplicationException("hahaha"));


            var users = SysUserService.GetAll();
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
        [LogRequestFilter(false)]
        public ActionResult AutoComplete()
        {
            return View();
        }
        #endregion

        #region Dialog
        [LogRequestFilter(false)]
        public ActionResult Dialog()
        {
            return View();
        }

        [LogRequestFilter(false)]
        public ActionResult D_Msgbox()
        {
            return View();
        }

        [LogRequestFilter(false)]
        public ActionResult D_Dialog()
        {
            return View();
        }
        #endregion

        #region JCrop
        [LogRequestFilter(false)]
        public ActionResult JCrop()
        {
            return View();
        }

        #endregion

        #region Gridster
        [LogRequestFilter(false)]
        public ActionResult Gridster()
        {
            return View();
        }

        #endregion

        #region Sortable
        [LogRequestFilter(false)]
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