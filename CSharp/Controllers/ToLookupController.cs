using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp.Models;

namespace CSharp.Controllers
{
    public class ToLookupController : Controller
    {
        //
        // GET: /ToLookup/
        public ActionResult Index()
        {
            var ticketlist = Ticket.GetList();
            var dic = ticketlist.ToLookup(i => i.OrderID);
            foreach (var item in dic)
            {
                Console.WriteLine("订单号:" + item.Key);

                foreach (var item1 in item)
                {
                    Console.WriteLine("\t\t" + item1.TicketNo + "  " + item1.Description);
                }
            }

            return View();
        }
	}



}