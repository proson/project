using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheApplicationMvc.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            ViewBag.DateTime = DateTime.Now;
            return View();
        }
    }
}