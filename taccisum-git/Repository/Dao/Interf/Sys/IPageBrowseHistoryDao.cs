using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Repository.Repository.Base;

namespace Repository.Dao.Interf.Sys
{
    public interface IPageBrowseHistoryDao : ICrud<PageBrowseHistory>
    {
        int GetHistoryCountByMenuId(Guid id);
    }
}
