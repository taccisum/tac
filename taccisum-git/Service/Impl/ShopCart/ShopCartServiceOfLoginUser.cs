using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Global.Enum.Business;
using Model.Models.ShopCart;
using Service.Interf.ShopCart;

namespace Service.Impl.ShopCart
{
    public static partial class ShopCart
    {
        private class ShopCartServiceOfLoginUser : BaseShopCartService
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="userid">用户ID</param>
            public ShopCartServiceOfLoginUser(Guid userid)
            {
                
            }


            public override ShopCartItem AddProduct(Guid pdtid)
            {
                //用户的购物车添加商品时，唯一标识存储为用户的ID
                throw new NotImplementedException();
            }

            public override decimal CalculateSumPrice(Guid? couponId)
            {
                decimal price = 0;
                List<ShopCartItem> items = new List<ShopCartItem>();    //todo:: 从数据源获取购物车items
                foreach (var item in items)
                {
                    //计算每一项购物车item的价格
                    var isChecked = true;     //todo::检查是否选中状态的购物车项
                    if (isChecked)
                    {
                        PromotionType type = PromotionType.NonePromotion;       //todo:: 从item中获取促销类型
                        Guid itemId = Guid.Empty;      //todo:: 从item中获取id

                        IPromotionStrategy strategy = PromotionStrategyCreater.Factory(type);
                        price += strategy.CalculatePromotionPrice(itemId);
                    }
                }

                return price;
            }

            public override IShopCartService ConvertToLoginUser(Guid userid)
            {
                //因为是已登陆用户，所以该方法不需要写任何实现，直接返回本身
                return this;
            }
        }
    }


}
