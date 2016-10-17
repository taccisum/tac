using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Model.Common
{
    public class CurrentUserInfo
    {
        public CurrentUserInfo(SysUser user)
        {
            UserID = user.ID;
            Uid = user.Uid;
        }

        public Guid UserID { get; set; }

        public string Uid { get; set; }

    }
}
