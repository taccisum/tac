using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities.Layout;
using Repository.Dao.Interf.Layout;
using Repository.Repository.Base;

namespace Repository.Dao.Impl.Layout
{
    [Export(typeof(IWidgetModelDao))]
    public class WidgetModelDaoImpl: RepositorySupport<WidgetModel>, IWidgetModelDao
    {
        public void RefreshWidgets(Guid layoutId, IEnumerable<WidgetModel> widgets)
        {
            throw new NotImplementedException();
        }

        public void RefreshChangedWidgets(Guid layoutId, IEnumerable<WidgetModel> widgets)
        {
            throw new NotImplementedException();
        }
    }
}
