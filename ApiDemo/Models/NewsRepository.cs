using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace ApiDemo.Models
{
    public class NewsRepository
    {
        public IList<News> GetAllNews()
        {
            News[] news =
            {
                new News { Id = 1, Title="新闻标题1", Content="新闻内容1", Author="xishuai", CreateTime=DateTime.Now }, 
                new News { Id = 2, Title="新闻标题2", Content="新闻内容2", Author="xishuai", CreateTime=DateTime.Now }, 
                new News { Id = 3, Title="新闻标题2", Content="新闻内容3", Author="xishuai", CreateTime=DateTime.Now }
            };
            return news.ToList();
        }
    }

    public class XmlContent : HttpContent
    {
        private readonly MemoryStream _stream = new MemoryStream();

        public XmlContent(XmlDocument document)
        {
            document.Save(_stream);
            _stream.Position = 0;
            Headers.ContentType = new MediaTypeHeaderValue("application/xml");
        }

        protected override Task SerializeToStreamAsync(Stream stream, System.Net.TransportContext context)
        {

            _stream.CopyTo(stream);

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _stream.Length;
            return true;
        }

    }

    public class SimpleXmlConverter
    {
        public static string ToXml<T>(IList<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();
            //builder.AppendLine(XmlResource.XmlHeader);

            XElement element = ToXElement<T>(entities, rootName);
            builder.Append(element.ToString());

            return builder.ToString();
        }

        public static XmlDocument ToXmlDocument<T>(IList<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(ToXml<T>(entities, rootName));

            return xmlDocument;
        }

        public static XDocument ToXDocument<T>(IList<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            return XDocument.Parse(ToXml<T>(entities, rootName));
        }

        public static XElement ToXElement<T>(IList<T> entities, string rootName = "") where T : new()
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(rootName))
            {
                //rootName = typeof(T).Name + XmlResource.XmlRootNameSuffix;
            }

            XElement element = new XElement(rootName);

            foreach (T entity in entities)
            {
                element.Add(ToXElement<T>(entity));
            }

            return element;
        }

        public static string ToXml<T>(T entity) where T : new()
        {
            if (entity == null)
            {
                return string.Empty;
            }

            XElement element = ToXElement<T>(entity);

            return element.ToString();
        }

        public static XElement ToXElement<T>(T entity) where T : new()
        {
            if (entity == null)
            {
                return null;
            }

            XElement element = new XElement(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties();
            XElement innerElement = null;
            object propertyValue = null;

            foreach (PropertyInfo property in properties)
            {
                propertyValue = property.GetValue(entity, null);
                innerElement = new XElement(property.Name, propertyValue);
                element.Add(innerElement);
            }

            return element;
        }

        public static XElement ToXElement(Type type)
        {
            if (type == null)
            {
                return null;
            }

            XElement element = new XElement(type.Name);
            PropertyInfo[] properties = type.GetProperties();
            XElement innerElement = null;

            foreach (PropertyInfo property in properties)
            {
                innerElement = new XElement(property.Name, null);
                element.Add(innerElement);
            }

            return element;
        }
    }
}