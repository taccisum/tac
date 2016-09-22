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
        private class SinglePromotionStrategy : IPromotionStrategy
        {
            public bool AlterPromotion(Guid id)
            {
                throw new NotImplementedException();
            }

            public decimal CalculatePromotionPrice(Guid id)
            {
                throw new NotImplementedException();
            }

            public decimal CalculatePromotionPrice(ShopCartItem item)
            {
                throw new NotImplementedException();
            }
        }
    }


}
