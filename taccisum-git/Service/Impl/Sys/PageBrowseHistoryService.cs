using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using Repository.Dao.Interf.Sys;
using Service.Base;

namespace Service.Impl.Sys
{
    public class PageBrowseHistoryService : BaseService
    {
        protected IPageBrowseHistoryDao PageBrowseHistoryDao;

        public PageBrowseHistoryService()
        {
            PageBrowseHistoryDao = IoC.Resolve<IPageBrowseHistoryDao>();
        }

        public void InsertBrowseHistory(PageBrowseHistory history)
        {
            PageBrowseHistoryDao.Create(history);
        }

        public void UpdateMenusBrowseTimes()
        {
            
        }
    }
}
