using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Tool.Extend;
using Model.Entities.Layout;
using Practice.Attributes;
using Practice.Attributes.Filter;
using Practice.Controllers.Base;
using Service.Interf.Layout;

namespace Practice.Controllers
{
    [Export]
    public class LayoutController : BaseController
    {
        [Import]
        protected ILayoutService LayoutService;

        [LogRequestInfoFilter(false)]
        public ActionResult LayoutList()
        {
            return View();
        }

        public JsonResult GetLayoutList()
        {
            return Try(() => LayoutService.GetAllLayout(), "获取布局列表失败", "获取布局列表成功");
        }

        public JsonResult GetAllWidgets(string layoutId)
        {
            return Try(() => LayoutService.GetLayoutManager(layoutId.ToGuid()).GetWidgets(), "获取组件失败", "获取组件成功");
        }

        public JsonResult NewWidget(WidgetModel widget)
        {
            return Try(() => LayoutService.GetLayoutManager(widget.LayoutId).AddWidget(widget), "新增组件失败", "新增组件成功");
        }

        public JsonResult RemoveWidget(string layoutId, string widgetId)
        {
            return Try(() =>
            {
                LayoutService.GetLayoutManager(layoutId.ToGuid()).DeleteWidget(widgetId.ToGuid());
                return null;
            }, "移除组件失败", "移除组件成功");
        }
    }
}