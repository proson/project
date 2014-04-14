using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.UI;

namespace Artech.MvcRouting
{
    public class MvcHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; private set; }

        public IControllerFactory ControllerFactory
        {
            get { return ControllerBuilder.Current.GetControllerFactory(); }
        }

        public MvcHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            RouteData routeData = this.RequestContext.RouteData;
            var controller = this.ControllerFactory.CreateController(this.RequestContext, routeData.Controller);
            controller.Execute(this.RequestContext);
        }
    }
}
