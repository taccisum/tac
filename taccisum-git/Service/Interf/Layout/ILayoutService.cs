using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Layout;

namespace Service.Interf.Layout
{
    public interface ILayoutService
    {
        /// <summary>
        /// 获取所有的layout
        /// </summary>
        /// <returns></returns>
        IQueryable<LayoutModel> GetAllLayout();
        ILayoutManager GetLayoutManager(Guid layoutId);
    }
}
