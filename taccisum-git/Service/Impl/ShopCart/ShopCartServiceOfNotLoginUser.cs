using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models.ShopCart;
using Service.Interf.ShopCart;

namespace Service.Impl.ShopCart
{
    public static partial class ShopCart
    {
        private class ShopCartServiceOfNotLoginUser : BaseShopCartService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="macAddr">游客设备地址</param>
            public ShopCartServiceOfNotLoginUser(string macAddr)
            {
                
            }


            public override ShopCartItem AddProduct(Guid pdtid)
            {
                //游客购物车添加商品时，唯一标识存储为游客的设备地址
                throw new NotImplementedException();
            }

            public override decimal CalculateSumPrice(Guid? couponId)
            {
                //未登陆的用户无法提交订单，所以不需要此方法的实现
                //此处直接抛出异常，编程时如果抛出了该异常，说明你的业务逻辑可能有误——因为原则上是不会调用到本方法的。
                throw new NotImplementedException();
            }

            public override IShopCartService ConvertToLoginUser(Guid userid)
            {
                //todo:: 将数据标识从设备mac地址转换为用户的id
                return Factory(userid.ToString(), true);
            }
        }
    }
}
