﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Layout;

namespace Service.Interf.Layout
{
    public interface ILayoutManager
    {
        /// <summary>
        /// 更新layout配置
        /// </summary>
        /// <param name="layout"></param>
        /// <returns></returns>
        LayoutModel UpdateLayout(LayoutModel layout);
        /// <summary>
        /// 获取指定layout的所有widgets
        /// </summary>
        /// <returns></returns>
        IQueryable<WidgetModel> GetWidgets();

        /// <summary>
        /// 新增一个widget
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        WidgetModel AddWidget(WidgetModel widget);
        /// <summary>
        /// 删除widget
        /// </summary>
        /// <param name="id"></param>
        void DeleteWidget(Guid id);

        /// <summary>
        /// 更新Widget
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        void UpdateWidget(WidgetModel widget);

        /// <summary>
        /// 更新变更过的widgets
        /// </summary>
        /// <param name="widgets"></param>
        void RefreshChangedWidgets(IEnumerable<WidgetModel> widgets);
    }
}
