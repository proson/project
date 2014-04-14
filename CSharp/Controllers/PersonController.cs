using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp.Models;

namespace CSharp.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(Person person)
        {
            Validate(person);

            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }

        private void Validate(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                ModelState.AddModelError("Name", "'Name'是必需字段");
            }

            if (string.IsNullOrEmpty(person.Gender))
            {
                ModelState.AddModelError("Gender", "'Gender'是必需字段");
            }
            else if (new[] { "M", "F" }.All(g => String.Compare(person.Gender, g, StringComparison.OrdinalIgnoreCase) != 0))
            {
                ModelState.AddModelError("Gender","有效'Gender'必须是'M','F'之一");
            }
            if (null == person.Age)
            {
                ModelState.AddModelError("Age", "'Age'是必需字段");
            }
            else if (person.Age > 25 || person.Age < 18)
            {
                ModelState.AddModelError("Age", "有效'Age'必须在18到25周岁之间");
            }
        }
    }
}