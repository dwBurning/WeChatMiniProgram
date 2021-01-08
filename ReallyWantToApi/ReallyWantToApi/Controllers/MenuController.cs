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
    /// 菜单
    /// </summary>
    public class MenuController : ApiController
    {
        /// <summary>
        /// 根据菜单ID获取菜单详情
        /// </summary>
        /// <param name="menuId">菜单ID</param>
        /// <returns>ResultData通用结果返回类型</returns>
        public JsonResult<ResultData> Get(int menuId)
        {
            var menu = LazyOrdersRepository.GetMenuList().Where(x => x.MenuId == menuId).First();
            if (menu == null)
            {
                Json(new ResultData() { Code = ResponseResult.Falied });
            }
            return Json(new ResultData() { Code = ResponseResult.Success, Context = menu });
        }

        // POST: api/Menu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }
    }
}
