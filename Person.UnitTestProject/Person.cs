using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person.UnitTestProject
{
    [Serializable]
    public class Person
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Data { get; set; }

    }
}
