using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;

namespace NvelocityApplication
{
    /// <summary>
    /// basic 的摘要说明
    /// </summary>
    public class basic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //创建一个模板引擎
            VelocityEngine vltEngine = new VelocityEngine();
            //文件型模板，还可以是 assembly ，则使用资源文件
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            //模板存放目录
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("/template"));//模板文件所在的文件夹
            vltEngine.Init();
            //定义一个模板上下文
            VelocityContext vltContext = new VelocityContext();
            //传入模板所需要的参数
            vltContext.Put("Title", "标题"); //设置参数，在模板中可以通过$Title来引用
            vltContext.Put("Body", "内容");  //设置参数，在模板中可以通过$Body来引用
            vltContext.Put("Date", DateTime.Now); //设置参数，在模板中可以通过$Date来引用
            //获取我们刚才所定义的模板，上面已设置模板目录
            Template vltTemplate = vltEngine.GetTemplate("basic.html");
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            //根据模板的上下文，将模板生成的内容写进刚才定义的字符串输出流中
            vltTemplate.Merge(vltContext, vltWriter);
            string html = vltWriter.GetStringBuilder().ToString();
            context.Response.Write(html);

            ////字符串模板源，这里就是你的邮件模板等等的字符串
            //const string templateStr = "$Title,$Body,$Date";

            ////创建一个模板引擎
            //VelocityEngine vltEngine = new VelocityEngine();
            ////文件型模板，还可以是 assembly ，则使用资源文件
            //vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            //vltEngine.Init();
            ////定义一个模板上下文
            //VelocityContext vltContext = new VelocityContext();
            ////传入模板所需要的参数
            //vltContext.Put("Title", "标题"); //设置参数，在模板中可以通过$Title来引用
            //vltContext.Put("Body", "内容");  //设置参数，在模板中可以通过$Body来引用
            //vltContext.Put("Date", DateTime.Now); //设置参数，在模板中可以通过$Date来引用
            ////定义一个字符串输出流
            //StringWriter vltWriter = new StringWriter();
            ////输出字符串流中的数据
            //vltEngine.Evaluate(vltContext, vltWriter, null, templateStr);
            //context.Response.Write(vltWriter.GetStringBuilder().ToString());
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