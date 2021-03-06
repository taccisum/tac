﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Layout;
using Repository.Dao.Interf.Layout;
using Service.Base;
using Service.Interf.Layout;

namespace Service.Impl.Layout
{
    [Export(typeof(ILayoutService))]
    public class LayoutServiceImpl: BaseService, ILayoutService
    {
        [Import]
        protected ILayoutModelDao LayoutModelDao { get; set; }

        
        public IQueryable<LayoutModel> GetAllLayout()
        {
            return LayoutModelDao.Query();
        }

        public ILayoutManager GetLayoutManager(Guid layoutId)
        {
            switch (layoutId.ToString())
            {
                case "":
                    //todo:: 这里可以根据不同的layout返回不同的处理方式子类
                    return null;
                default:
                    return new CommonLayoutManager(layoutId);
            }
        }

        private abstract class BaseLayoutManager : ILayoutManager
        {
            protected Guid LayoutId { get; set; }

            protected BaseLayoutManager(Guid layoutId)
            {
                LayoutId = layoutId;
            }

            public virtual LayoutModel UpdateLayout(LayoutModel layout)
            {
                throw new NotImplementedException();
            }

            public virtual IQueryable<WidgetModel> GetWidgets()
            {
                throw new NotImplementedException();
            }

            public WidgetModel AddWidget(WidgetModel widget)
            {
                throw new NotImplementedException();
            }

            public void DeleteWidget(Guid id)
            {
                throw new NotImplementedException();
            }

            public void UpdateWidget(WidgetModel widget)
            {
                throw new NotImplementedException();
            }

            public virtual void RefreshChangedWidgets(IEnumerable<WidgetModel> widgets)
            {
                throw new NotImplementedException();
            }
        }

        private class CommonLayoutManager : BaseLayoutManager
        {
            public CommonLayoutManager(Guid layoutId) : base(layoutId)
            {
            }
        }
    }


}
