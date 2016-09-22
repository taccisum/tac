using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Global.Enum.Business;

namespace Service.Impl.ShopCart
{
    public static partial class ShopCart
    {
        private static class PromotionStrategyCreater
        {
            public static IPromotionStrategy Factory(PromotionType type)
            {
                switch (type)
                {
                    case PromotionType.NonePromotion:
                        return new NonePromotionStrategy();
                    case PromotionType.SinglePromotion:
                        return new SinglePromotionStrategy();
                    default:
                        return new NonePromotionStrategy();
                }
            }
        }
    }

}
