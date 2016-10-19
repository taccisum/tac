using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Common;
using Model.Entity;
using Practice.Attributes;
using Practice.Controllers.Base;
using Service.Interf.Sys;

namespace Practice.Controllers
{
    [Export]
    public class CommonInfoController : BaseController
    {
        [Import]
        protected Lazy<ISysMenuService> LazyMenuService { get; set; }

        public ActionResult Menus()
        {
            return Try(() =>
            {
                var menuService = LazyMenuService.Value;
                var menus =
                    menuService.Query(m => m.EnabledState)
                        .OrderByDescending(m => m.SortNo)
                        .ThenByDescending(m => m.CreatedOn).ToList().Select(m => new
                        {
                            ID = m.ID,
                            Name = m.Name,
                            ParentId = m.ParentId,
                            Url = string.IsNullOrWhiteSpace(m.Url) ? "#" : m.Url,
                            Icon = m.Icon,
                            SortNo = m.SortNo,
                            EnabledState = m.EnabledState,
                            Description = m.Description,
                            CreatedOn = m.CreatedOn
                        });
                return menus;
            },"获取菜单信息失败", "获取菜单信息成功");
        }

        [LogRequestInfoFilter(false)]
        public ActionResult NonAuthority()
        {
            return View();
        }
    }
}