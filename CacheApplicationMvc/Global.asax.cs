using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CacheApplicationMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "Index_Key")
            {
                var flag = context.Cache["Index_Key"];
                if (flag == null)
                {
                    flag = DateTime.Now.Ticks;
                    context.Cache["Index_Key"] = flag;
                }
                return flag.ToString();
            }
            return base.GetVaryByCustomString(context, custom);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
