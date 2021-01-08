using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReallyWantToApi.Models
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类 类别名
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 该类别下的菜单
        /// </summary>
        public List<Menu> Menus { get; set; }
    }

    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 对应的图片路径
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
    }

    /// <summary>
    /// 购物车
    /// </summary>
    public class Carts
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 该用户购物车中的清单
        /// </summary>
        public int MenuId { get; set; }
    }

    /// <summary>
    /// 订单
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 该订单包含的菜单
        /// </summary>
        public List<Menu> Menus { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        public decimal TotalPrice { get { return this.Menus.Sum(x => x.Price); } }
    }
}