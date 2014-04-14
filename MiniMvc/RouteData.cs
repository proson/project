using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMvc
{
    public class RouteData
    {
        /// <summary>
        /// 直接从请求地址解析出来的变量
        /// </summary>
        public IDictionary<string, object> Values { get; private set; }
        /// <summary>
        /// 其他类型的变量
        /// </summary>
        public IDictionary<string, object> DataTokens { get; private set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteBase Route { get; set; }

        public RouteData()
        {
            this.Values = new Dictionary<string, object>();
            this.DataTokens = new Dictionary<string, object>();
            this.DataTokens.Add("namespaces", new List<string>());
        }
        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                this.Values.TryGetValue("controller", out controllerName);
                return controllerName.ToString();
            }
        }
        public string ActionName
        {
            get
            {
                object actionName = string.Empty;
                this.Values.TryGetValue("action", out actionName);
                return actionName.ToString();
            }
        }
        public IEnumerable<string> Namespaces
        {
            get
            {
                return (IEnumerable<string>)this.DataTokens["namespaces"];
            }
        } 
    }
}
