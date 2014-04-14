using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Artech.MvcRouting;

namespace Artech.MvcApp
{
    public class HomeController
    {
        public ActionResult Index()
        {
            return new StaticViewResult();
        }
    }
}