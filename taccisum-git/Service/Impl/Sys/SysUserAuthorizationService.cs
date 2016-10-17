using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Common.Global;
using Common.Global.Enum.Common;
using Common.Tool.Units;
using IoC.Manager;
using Model.Common;
using Model.Entity;
using Repository.Dao.Interf.Sys;
using Service.Interf.Sys;

namespace Service.Impl.Sys
{
    /// <summary>
    /// 提供站点用户验证相关服务方法
    /// </summary>
    public class SysUserAuthorizationService
    {
        protected ISysUserDao SysUserDao = IoCManager.GetInstance().Create().Resolve<ISysUserDao>();

        #region Public Methods
        /// <summary>
        /// 验证用户账号密码是否正确，并记录相关信息到Session
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="psd"></param>
        /// <returns></returns>
        public bool LoginVerify(string uid, string psd)
        {
            var user = SysUserDao.LoginVerify(uid, psd, EncryptType.MD5_32);
            if (user != null)
            {
                SaveSession(new CurrentUserInfo(user));
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取当前请求用户信息
        /// </summary>
        /// <returns></returns>
        public CurrentUserInfo CurrentUser()
        {
            return SessionHelper.Get(GlobalConfig.CURRENT_USER) as CurrentUserInfo;
        }
        /// <summary>
        /// 清空当前会话存储的相关信息
        /// </summary>
        public void ClearSession()
        {
            SessionHelper.Remove(GlobalConfig.CURRENT_USER);
        }
        #endregion


        #region Private Methods
        private void SaveSession(CurrentUserInfo info)
        {
            SessionHelper.Set(GlobalConfig.CURRENT_USER, info, 60);
        }
        #endregion
    }
}
