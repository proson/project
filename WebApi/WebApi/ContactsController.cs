using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Http;
using Common;

namespace WebApi
{
    public class ContactsController : ApiController
    {
        static List<Contact> contacts;
        static int counter = 2;
        static ContactsController()
        {
            contacts = new List<Contact>
            {
                new Contact
                {
                    Id = "001",
                    Name = "张三",
                    PhoneNo = "0512-12345678",
                    EmailAddress = "zhangsan@gmail.com",
                    Address = "江苏省苏州市星湖街328号"
                },
                new Contact
                {
                    Id = "002",
                    Name = "李四",
                    PhoneNo = "0512-23456789",
                    EmailAddress = "lisi@gmail.com",
                    Address = "江苏省苏州市金鸡湖大道328号"
                }
            };
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Contact> Get(string id = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return contacts;
            }
            return contacts.FindAll(c => c.Id == id);
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="contact"></param>
        public void Post(Contact contact)
        {
            Interlocked.Increment(ref counter);
            contact.Id = counter.ToString("D3");
            contacts.Add(contact);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="contact"></param>
        public void Put(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
        }
    }
}
