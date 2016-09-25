using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Layout;
using Repository.Repository.Base;

namespace Repository.Dao.Interf.Layout
{
    public interface IWidgetModelDao : ICrud<WidgetModel>
    {
        /// <summary>
        /// 使用新的widgets参数刷新旧的参数（全部刷新）
        /// </summary>
        /// <param name="layoutId">要刷新widgets的Layout的ID</param>
        /// <param name="widgets"></param>
        void RefreshWidgets(Guid layoutId, IEnumerable<WidgetModel> widgets);
        /// <summary>
        /// 使用修改过的widgets参数刷新旧的参数
        /// </summary>
        /// <param name="layoutId">要刷新widgets的Layout的ID</param>
        /// <param name="widgets">修改过的widgets</param>
        void RefreshChangedWidgets(Guid layoutId, IEnumerable<WidgetModel> widgets);

    }
}
