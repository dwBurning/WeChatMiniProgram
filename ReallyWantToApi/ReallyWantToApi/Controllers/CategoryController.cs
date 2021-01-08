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
    /// 菜单分类
    /// </summary>
    public class CategoryController : ApiController
    {
        /// <summary>
        /// 获取菜单分类
        /// </summary>
        /// <returns>ResultData通用结果返回类型</returns>
        public JsonResult<ResultData> Get()
        {
            List<Category> lstCategory = new List<Category>();
            lstCategory.Add(new Category
            {
                CategoryId = 1,
                CategoryName = "经济快餐",
                Menus = LazyOrdersRepository.GetMenuList().Where(x => x.CategoryId == 1).ToList()
            });
            lstCategory.Add(new Category
            {
                CategoryId = 2,
                CategoryName = "精美小炒",
                Menus = LazyOrdersRepository.GetMenuList().Where(x => x.CategoryId == 2).ToList()
            });
            return Json(new ResultData() { Code = ResponseResult.Success, Context = lstCategory });
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
