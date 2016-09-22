using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Tool.Extend;
using Model.Models.ShopCart;
using Service.Interf.ShopCart;

namespace Service.Impl.ShopCart
{
    public static partial class ShopCart
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueToken">唯一标识符（登陆用户为用户id，游客为设备mac地址）</param>
        /// <param name="isLogin">是否登陆用户</param>
        /// <returns></returns>
        public static IShopCartService Factory(string uniqueToken, bool isLogin)
        {
            if (isLogin)
            {
                return new ShopCartServiceOfLoginUser(uniqueToken.ToGuid());
            }
            else
            {
                return new ShopCartServiceOfNotLoginUser(uniqueToken);
            }
        }

    }
}
