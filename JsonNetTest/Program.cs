using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace JsonNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account()
            {
                Email = "aehyok@vip.qq.com",
                Active = true,
                CreatedDate = new DateTime(2014, 3, 27, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string> { "aehyok", "Kris" }
            };
            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            Console.Write(json);
            Console.Read();
        }
    }
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}
