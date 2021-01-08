using Newtonsoft.Json;
using ReallyWantToApi.Models;
using ReallyWantToApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ReallyWantToApi.Controllers
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartsController : ApiController
    {
        /// <summary>
        /// 根据sessionKey获取购物车列表
        /// </summary>
        /// <param name="sessionKey">会话Key</param>
        /// <returns>ResultData通用结果返回类型</returns>
        public JsonResult<ResultData> Get(string sessionKey)
        {
            string sessionValue = "";
            if (LazyOrdersRepository.AppSession.TryGetValue(sessionKey, out sessionValue))
            {
                string openId = sessionValue.Split('|')[1];
                var carts = from cart in LazyOrdersRepository.Carts
                            where cart.OpenId == openId
                            group cart by cart.MenuId into c
                            select new
                            {
                                c.Key,
                                Menu = LazyOrdersRepository.GetMenuList().FirstOrDefault(x => x.MenuId == c.Key),
                                Count = c.Count(),
                                Selected = true
                            };
                return Json<ResultData>(new ResultData() { Code = ResponseResult.Success, Context = carts.ToList() });
            }
            return Json(new ResultData() { Code = ResponseResult.Falied });
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="data">dynamic接收{count:1,menuId:"",sessionKey:""}</param>
        /// <returns>ResultData通用结果返回类型</returns>
        public JsonResult<ResultData> Post([FromBody]dynamic data)
        {
            string sessionValue = "";
            int count = data.count;
            int menuId = data.menuId;
            string sessionKey = data.sessionKey;
            if (LazyOrdersRepository.AppSession.TryGetValue(sessionKey, out sessionValue))
            {
                for (int i = 0; i < count; i++)
                {
                    Carts cart = new Carts();
                    cart.MenuId = menuId;
                    cart.OpenId = sessionValue.Split('|')[1];
                    LazyOrdersRepository.Carts.Add(cart);
                }

                return Json(new ResultData() { Code = ResponseResult.Success });
            }
            return Json(new ResultData() { Code = ResponseResult.Falied });
        }

        // PUT: api/Carts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 从购物车中移除
        /// </summary>
        /// <param name="data">dynamic接收{count:1,menuId:"",sessionKey:""}</param>
        /// <returns>ResultData通用结果返回类型</returns>
        public JsonResult<ResultData> Delete([FromBody]dynamic data)
        {
            string sessionValue = "";
            int count = data.count;
            int menuId = data.menuId;
            string sessionKey = data.sessionKey;
            if (LazyOrdersRepository.AppSession.TryGetValue(sessionKey, out sessionValue))
            {
                string openId = sessionValue.Split('|')[1];
                for (int i = 0; i < count; i++)
                {
                    var cart = LazyOrdersRepository.Carts.Find(x => x.MenuId == menuId && x.OpenId == openId);
                    LazyOrdersRepository.Carts.Remove(cart);
                }
                return Json(new ResultData() { Code = ResponseResult.Success });
            }
            return Json(new ResultData() { Code = ResponseResult.Falied });
        }
    }
}
