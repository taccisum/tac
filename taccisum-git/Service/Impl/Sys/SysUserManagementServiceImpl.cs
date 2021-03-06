﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Global.Enum.Common;
using Model.Entity;
using Repository.Dao.Interf.Sys;
using Service.Base;
using Service.Interf.Sys;

namespace Service.Impl.Sys
{
    [Export(typeof(ISysUserManagementService))]
    public class SysUserManagementServiceImpl : BaseService, ISysUserManagementService
    {
        [Import]
        protected ISysUserDao SysUserDao { get; set; }

        public SysUser Register(SysUser user)
        {
            return SysUserDao.Create(user);
        }

        public SysUser Register(string uid, string psd)
        {
            return SysUserDao.Create(new SysUser()
            {
                Uid = uid,
                Psd = psd
            });
        }

        public SysUser GetById(Guid id)
        {
            return SysUserDao.GetEntity(id);
        }

        public IQueryable<SysUser> GetAll()
        {
            return SysUserDao.Query();
        }
    }
}
