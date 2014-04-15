using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //指定程序集
            Assembly.Load("WebApi,Version=1.0.0.0,Culture=neutral,PublicKeyToken=null");
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration("http://localhost/selfhost");
            using (HttpSelfHostServer hostServer = new HttpSelfHostServer(configuration))
            {
                hostServer.Configuration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });
                hostServer.OpenAsync().Wait();
                Console.Read();
            }


        }
    }
}
