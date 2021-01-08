using ReallyWantToApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReallyWantToApi.Repository
{
    /// <summary>
    /// 模拟仓储类
    /// </summary>
    public static class LazyOrdersRepository
    {
        static LazyOrdersRepository()
        {
            AppSession = new ConcurrentDictionary<string, string>();
            Carts = new List<Carts>();
        }

        public static ConcurrentDictionary<string, string> AppSession { get; set; }

        public static List<Carts> Carts { get; set; }

        #region Menu
        public static List<Menu> GetMenuList()
        {
            List<Menu> lstMenu = new List<Menu> {
                new Menu { CategoryId = 1, MenuId = 1, MenuName = "腐竹炒肉" ,Price=15},
                new Menu { CategoryId = 1, MenuId = 2, MenuName = "芹菜香干" ,Price=14} ,
                new Menu { CategoryId = 1, MenuId = 3, MenuName = "农家小炒肉" ,Price=18} ,
                new Menu { CategoryId = 1, MenuId = 4, MenuName = "青瓜炒蛋" ,Price=14} ,
                new Menu { CategoryId = 2, MenuId = 5, MenuName = "茄子煲" ,Price=28},
                new Menu { CategoryId = 2, MenuId = 6, MenuName = "小龙虾",Price=88}
                };
            lstMenu.ForEach((x) =>
            {
                x.ImgPath = GetImagePath(x.CategoryId, x.MenuId);
            });
            return lstMenu;
        }

        /// <summary>
        /// 获取图片的url
        /// </summary>
        private const string url = "http://localhost:8089/api/lazyorders?fileName=";

        private static string GetImagePath(int categoryId, int menuId)
        {
            return string.Format("{0}{1}{2}.jpg", url, categoryId, menuId);
        }

        public static List<Orders> GetOrders()
        {
            List<Orders> lstOrders = new List<Orders>()
            {
                new Orders()
                {
                    OrderId = 1,
                    OpenId = "",
                    Menus = GetMenuList().Where(x => x.MenuId == 1 || x.MenuId == 2).ToList(),
                    IsPaid = false
                },
                new Orders()
                {
                    OrderId = 2,
                    OpenId = "",
                    Menus = GetMenuList().Where(x => x.MenuId == 1 || x.MenuId == 2).ToList(),
                    IsPaid = true
                }
            };

            return lstOrders;
        }
        #endregion

    }
}