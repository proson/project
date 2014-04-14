using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniMvc;

namespace WebApp
{
    public class HomeController
    {
        public ActionResult Index(SimpleModel model)
        {
            string content = string.Format("Controller: {0}<br/>Action:{1}", model.Controller, model.Action);
            return new RawContentResult(content);
        }
    }
}