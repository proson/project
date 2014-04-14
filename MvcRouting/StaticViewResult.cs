using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.MvcRouting
{
    public class StaticViewResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.Write(context.RequestContext.RouteData.Action + ".html");
        }
    }
}
