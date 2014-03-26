using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using NvelocityApplication.Code;

namespace NvelocityApplication
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class baseobject : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            VelocityEngine velocityEngine = new VelocityEngine();
            velocityEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            velocityEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("/template"));
            velocityEngine.Init();

            //定义一个模板上下文
            VelocityContext velocityContext = new VelocityContext();
            //定义类对象
            Person p = new Person()
            {
                Name = "王三",
                Age = 20

            };
            velocityContext.Put("p", p);
            //定义键值对
            Dictionary<string,string> dic=new Dictionary<string, string>();
            dic["aa"] = "李四";
            dic["bb"] = "30";
            velocityContext.Put("dic", dic);
            
            //定义list集合
            List<string> list=new List<string>(){"张五","马六"};
            velocityContext.Put("list", list);

            //获取定义的模板
            Template template = velocityEngine.GetTemplate("baseobject.html");
            StringWriter stringWriter = new StringWriter();
            template.Merge(velocityContext, stringWriter);
            string html = stringWriter.GetStringBuilder().ToString();
            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}