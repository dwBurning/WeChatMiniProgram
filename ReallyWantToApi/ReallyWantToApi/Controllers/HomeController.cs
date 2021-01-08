using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReallyWantToApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public string get_index(string value)
        {
            return "get_index" + value;
        }

        [HttpPost]
        public string post_index(string value)
        {
            return "post_index" + value;
        }
    }
}
