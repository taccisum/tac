using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Models;

namespace Service.Interf.Sys
{
    public interface ISysUserManagementService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        SysUser Register(SysUser user);
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        SysUser Register(string uid, string psd);
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUser GetById(Guid id);
        /// <summary>
        /// 查询并返回用户列表
        /// </summary>
        /// <returns></returns>
        IQueryable<SysUser> GetAll();

    }

}
