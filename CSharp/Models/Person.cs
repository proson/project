using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }

}