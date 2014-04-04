using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp.Models;

namespace CSharp.Controllers
{
    public class StringClassController : Controller
    {
        //
        // GET: /StringClass/
        public ActionResult Index()
        {
            Person person=new Person();

            ViewBag.Log = person.Fly();

            return View();
        }
	}
}