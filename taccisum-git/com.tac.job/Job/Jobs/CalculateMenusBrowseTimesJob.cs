using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Global;
using IoC.Manager;
using log4net;
using Model.Entity;
using Quartz;
using Repository.Dao.Interf.Sys;
using Service.Impl.Sys;

namespace Job.Jobs
{
    public class CalculateMenusBrowseTimesJob: IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //new PageBrowseHistoryService().UpdateMenusBrowseTimes();

            //todo::
            //var log = LogManager.GetLogger(typeof(CalculateMenusBrowseTimesJob));
            //log.Info("job start");
            ISysMenuDao menuDao = IoCManager.GetInstance().Create().Resolve<ISysMenuDao>();
            foreach (var menu in menuDao.Query().ToList())
            {
                IPageBrowseHistoryDao historyistoryDao = IoCManager.GetInstance().Create().Resolve<IPageBrowseHistoryDao>();
                var entity = menuDao.GetEntity(menu.ID);
                entity.BrowserTimes = historyistoryDao.GetHistoryCountByMenuId(menu.ID);
                entity.ModifiedBy = new Guid(GlobalConfig.ADMIN_ID);
                menuDao.Update(entity, false);
            }
            menuDao.Submit();
            //log.Info("job finish");
        }
    }
}
