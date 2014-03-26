using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Prosen.Common
{
    public class HttpTime : IHttpModule
    {
        public void Init(HttpApplication application)//实现IHttpModules中的Init事件 
        {
            //订阅两个事件 
            application.BeginRequest += new EventHandler(application_BeginRequest);
            application.EndRequest += new EventHandler(application_EndRequest);
        }
        private DateTime _starttime;
        private void application_BeginRequest(object sender, EventArgs e)
        {
            //object sender是BeginRequest传递过来的对象 
            //里面存储的就是HttpApplication实例 
            //HttpApplication实例里包含HttpContext属性 
            _starttime = DateTime.Now;
        }
        private void application_EndRequest(object sender, EventArgs e)
        {
            DateTime endtime = DateTime.Now;
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string result = string.Format("<p>页面执行时间：{0},请求信息:{1}", (endtime - _starttime).TotalMilliseconds, application.Request.Url);
            context.Response.AddHeader("default", result);
            context.Response.Write(result);
        }
        //必须实现dispose接口 
        public void Dispose() { }
    }
}
