using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.MvcRouting
{
    public class RouteData
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        /// <summary>
        /// 表示引入的程序集
        /// </summary>
        public IList<string> Assemblies { get; set; }

        /// <summary>
        /// 表示引入的命名空间
        /// </summary>
        public IList<string> Namespaces { get; set; }

        public IRouteHandler RouteHandler { get; set; }

        public RouteData(string controller, string action, IRouteHandler routeHandler)
        {
            this.Controller = controller;
            this.Action = action;
            this.RouteHandler = routeHandler;
            this.Namespaces = RouteTable.Namespaces;
            this.Assemblies = RouteTable.Assemblies;
        }
    }
}
