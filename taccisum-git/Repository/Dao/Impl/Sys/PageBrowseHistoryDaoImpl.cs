using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Common.Global;
using Model.Entities;
using Repository.Context;
using Repository.Dao.Interf.Sys;
using Repository.Repository.Base;

namespace Repository.Dao.Impl.Sys
{
    public class PageBrowseHistoryDaoImpl : RepositorySupport<PageBrowseHistory>, IPageBrowseHistoryDao
    {
        public override PageBrowseHistory Create(PageBrowseHistory entity, bool submit = true)
        {
            //这里是为了绕开使用Repository插入数据时的用户检测
            var dbContext = GetDbContext();
            var dbSet = dbContext.PageBrowserHistory;
            entity.ID = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = new Guid(GlobalConfig.ADMIN_ID);

            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public int GetHistoryCountByMenuId(Guid id)
        {
            return Query(h => h.RelativeMenuId == id).Count();
        }

        private TacContext GetDbContext()
        {
            var temp = CallContext.GetData(GlobalConfig.DataSink.EF_DB_CONTEXT) as TacContext;
            if (temp == null)
            {
                temp = new TacContext();
                CallContext.SetData(GlobalConfig.DataSink.EF_DB_CONTEXT, temp);
            }
            return temp;
        }
    }
}
