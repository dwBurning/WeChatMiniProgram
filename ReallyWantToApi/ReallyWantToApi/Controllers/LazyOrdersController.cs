using Newtonsoft.Json;
using ReallyWantToApi.Common;
using ReallyWantToApi.Models;
using ReallyWantToApi.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReallyWantToApi.Controllers
{
    /// <summary>
    /// 懒人点单
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LazyOrdersController : ApiController
    {
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="fileName">文件名称，如:1.jpg</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage GetImage(string fileName)
        {
            var filePath = string.Format("~/images/{0}", fileName);
            var imgPath = System.Web.Hosting.HostingEnvironment.MapPath(filePath);
            if (!File.Exists(imgPath)) return new HttpResponseMessage(HttpStatusCode.NotFound);
            //从图片中读取byte
            var imgByte = File.ReadAllBytes(imgPath);
            //从图片中读取流
            var imgStream = new MemoryStream(File.ReadAllBytes(imgPath));
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(imgStream)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;
        }

        private readonly string _appID = "";//填写自己的AppId

        private readonly string _appSecret = "";//填写自己的AppSecret

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="data">dynamic接收{code:""}</param>
        /// <returns>sessionKey</returns>
        public string PostLogIn([FromBody]dynamic data)
        {
            string code = data.code;
            string strUrl = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", _appID, _appSecret, code);

            var appAuth = JsonConvert.DeserializeAnonymousType(HttpRequestHelper.HttpGet(strUrl), new
            {
                session_key = "",
                openid = ""
            });

            string sessionKey = Guid.NewGuid().ToString("N");
            string sessionValue = appAuth.session_key + "|" + appAuth.openid;

            LazyOrdersRepository.AppSession.AddOrUpdate(sessionKey, sessionValue, (key, value) => value);

            return sessionKey;
        }
    }
}
