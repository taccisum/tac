using System;
using System.Collections.Generic;
using Model.Entity;
using Repository.Repository.Base;

namespace Repository.Dao.Interf.Sys
{
    public interface ISysMenuDao : ICrud<SysMenu>
    {
        void PushRecentMenuToCache(SysMenu menu);

        List<string> GetRecentMenuCache();

    }

}
