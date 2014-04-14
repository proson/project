using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace CSharp.Models
{
    public class Person
    {
        public string Fly()
        {
            return Fly("test");
        }

        public string Fly(string name)
        {
            return string.Format("我的log日志.\n\n{0}", Environment.StackTrace);
        }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "")]
        public string Name { get; set; }

        [DisplayName("性别")]
        public string Gender { get; set; }

        [DisplayName("年龄")]
        public int? Age { get; set; }
    }

}