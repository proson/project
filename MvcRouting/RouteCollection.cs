using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Artech.MvcRouting
{
    public class RouteCollection : Collection<RouteBase>
    {
        public RouteData GetRouteData(HttpContextBase httpContext)
        {
            foreach (RouteBase routeBase in this)
            {
                var routeData = routeBase.GetRouteData(httpContext);
                if (routeData != null)
                {
                    return routeData;
                }
            }
            return null;
        }
    }
}
