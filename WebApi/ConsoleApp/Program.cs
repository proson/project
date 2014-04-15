﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Proccess();
            Console.Read();

        }

        private async static void Proccess()
        {
            //获取联系人列表
            HttpClient httpClient = new HttpClient();
            //接收响应
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            IEnumerable<Contact> contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            Console.WriteLine("获取当前联系人列表：");
            ListContacts(contacts);

            //添加新的联系人信息
            Contact contact = new Contact { Name = "王五", PhoneNo = "0512-34567890", EmailAddress = "wangwu@gmail.com" };
            await httpClient.PostAsJsonAsync<Contact>("http://localhost/selfhost/api/contacts", contact);
            Console.WriteLine("添加新联系人“王五”：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //修改现有的某个联系人
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts/001");
            contact = (await response.Content.ReadAsAsync<IEnumerable<Contact>>()).First();
            contact.Name = "赵六";
            contact.EmailAddress = "zhaoliu@gmail.com";
            //向服务器段请求数据
            await httpClient.PutAsJsonAsync<Contact>("http://localhost/selfhost/api/contacts/001", contact);
            Console.WriteLine("修改联系人“001”信息：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //删除现有的某个联系人

            await httpClient.DeleteAsync("http://localhost/selfhost/api/contacts/002");
            Console.WriteLine("删除联系人“002”：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);
        }

        private static void ListContacts(IEnumerable<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("{0,-6}{1,-6}{2,-20}{3,-10}", contact.Id, contact.Name, contact.EmailAddress, contact.PhoneNo);
            }
            Console.WriteLine();
        }
    }
}
