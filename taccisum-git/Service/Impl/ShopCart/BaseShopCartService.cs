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
        private abstract class BaseShopCartService : IShopCartService
        {
            public virtual IQueryable<ShopCartItem> GetDetails(string uniqueToken)
            {
                throw new NotImplementedException();
            }

            public abstract ShopCartItem AddProduct(Guid pdtid);

            public virtual bool RemoveProduct(Guid id)
            {
                throw new NotImplementedException();
            }

            public virtual bool AlterQty(Guid id, int qty)
            {
                throw new NotImplementedException();
            }

            public virtual bool AlterPromotion(Guid id, PromotionType type, Guid prmId)
            {
                throw new NotImplementedException();
            }

            public bool InverseCheckedStatus(Guid id)
            {
                throw new NotImplementedException();
            }

            public abstract decimal CalculateSumPrice(Guid? couponId);
            public abstract IShopCartService ConvertToLoginUser(Guid userid);
        }
    } 

}
