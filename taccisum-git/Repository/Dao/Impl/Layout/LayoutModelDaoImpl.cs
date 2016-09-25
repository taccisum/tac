using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Model.Entities.Layout;
using Repository.Dao.Interf.Layout;
using Repository.Repository.Base;

namespace Repository.Dao.Impl.Layout
{
    [Export(typeof(ILayoutModelDao))]
    public class LayoutModelDaoImpl: RepositorySupport<LayoutModel>, ILayoutModelDao
    {

    }
}
