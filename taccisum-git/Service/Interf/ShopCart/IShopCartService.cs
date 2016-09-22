using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Global.Enum.Business;
using Model.Models.ShopCart;

namespace Service.Interf.ShopCart
{
    public interface IShopCartService
    {
        /// <summary>
        /// 获取购物车详情
        /// </summary>
        /// <param name="uniqueToken">用户唯一标识（登陆用户为用户ID，游客为设备mac地址）</param>
        /// <returns></returns>
        IQueryable<ShopCartItem> GetDetails(string uniqueToken);

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="pdtid">product id</param>
        /// <returns></returns>
        ShopCartItem AddProduct(Guid pdtid);

        /// <summary>
        /// 移除商品
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        bool RemoveProduct(Guid id);

        /// <summary>
        /// 修改数量
        /// </summary>
        /// <param name="id">item id</param>
        /// <param name="qty">商品数量</param>
        /// <returns></returns>
        bool AlterQty(Guid id, int qty);

        /// <summary>
        /// 修改促销类型，也可修改为无促销
        /// </summary>
        /// <param name="id">item id</param>
        /// <param name="type">促销类型</param>
        /// <param name="prmId">促销活动ID</param>
        /// <returns></returns>
        bool AlterPromotion(Guid id, PromotionType type, Guid prmId);

        /// <summary>
        /// 反转购物车item的勾选状态（选中的item主要用于提交订单时使用）
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        bool InverseCheckedStatus(Guid id);

        /// <summary>
        /// 计算总价，用于提交订单时结算
        /// </summary>
        /// <param name="couponId">优惠券ID</param>
        /// <returns></returns>
        decimal CalculateSumPrice(Guid? couponId);

        /// <summary>
        /// 将游客的购物车数据转移到会员中，并返回登陆用户的购物车Service实例
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        IShopCartService ConvertToLoginUser(Guid userid);
    }
}
