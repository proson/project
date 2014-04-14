using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using ApiDemo.Models;
using ApiDemo;

namespace ApiDemo.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllNews()
        {
            var news = new NewsRepository().GetAllNews();
            return new HttpResponseMessage()
            {
                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument(news, "NewsRoot"))
            };
        }

        public HttpResponseMessage GetAllNewsById(int id)
        {
            List<News> news = new NewsRepository().GetAllNews().ToList();

            return new HttpResponseMessage
            {
                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument(news.FindAll(p => p.Id == id), "NewsRoot"))
            };
        }
    }
}
