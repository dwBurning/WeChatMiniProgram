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
    /// 已支付订单
    /// </summary>
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public JsonResult<ResultData> Get()
        {
            List<Orders> lstOrders = LazyOrdersRepository.GetOrders();
            return Json(new ResultData() { Code = ResponseResult.Success, Context = lstOrders });
        }

        // GET: api/Orders/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Orders
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
        }
    }
}
