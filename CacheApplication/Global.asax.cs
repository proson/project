using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CacheApplication
{
    public class Global : System.Web.HttpApplication
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


        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}