using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models.ShopCart;

namespace Service.Impl.ShopCart
{
    public static partial class ShopCart
    {
        private interface IPromotionStrategy
        {
            /// <summary>
            /// 将item修改为当前促销类型
            /// </summary>
            /// <param name="id">购物车item id</param>
            /// <returns></returns>
            bool AlterPromotion(Guid id);
            /// <summary>
            /// 计算购物车item的促销金额
            /// </summary>
            /// <param name="id">购物车item id</param>
            /// <returns></returns>
            decimal CalculatePromotionPrice(Guid id);
            /// <summary>
            /// 计算购物车item的促销金额
            /// </summary>
            /// <param name="item">购物车item实体</param>
            /// <returns></returns>
            decimal CalculatePromotionPrice(ShopCartItem item);
        }
    }
}
