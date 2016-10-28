﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Common.Tool.Extend;
using Common.Tool.Utility;
using Model.Entity;
using Repository.Dao.Interf.Sys;
using Repository.Repository.Base;

namespace Repository.Dao.Impl.Sys
{
    [Export(typeof(ISysMenuDao))]
    public class SysMenuDaoImpl : RepositorySupport<SysMenu>, ISysMenuDao
    {
        private IRedisClient _client;

        private IRedisClient client { get { return _client ?? (_client = RedisHelper.GetClient()); } }

        public void PushRecentMenuToCache(SysMenu menu)
        {
            client.Rpush("recent:menu", menu.ToCacheString());
        }

        public List<string> GetRecentMenuCache()
        {
            return client.Lrange("recent:menu", 0, -1);
        }
    }
}
