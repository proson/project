using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Ticket
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }


        public static List<Ticket> GetList()
        {
            return new List<Ticket>()
            {
                 new Ticket(){ TicketNo="999-12311",OrderID=79121281,Description="改签"},
                 new Ticket(){ TicketNo="999-24572",OrderID=29321289,Description="退票"},
                 new Ticket(){ TicketNo="999-68904",OrderID=19321289,Description="成交"},
                 new Ticket(){ TicketNo="999-24172",OrderID=64321212,Description="未使用"},
                 new Ticket(){ TicketNo="999-24579",OrderID=19321289,Description="退票"},
                 new Ticket(){ TicketNo="999-21522",OrderID=79121281,Description="未使用"},
                 new Ticket(){ TicketNo="999-24902",OrderID=79121281,Description="退票"},
                 new Ticket(){ TicketNo="999-04571",OrderID=29321289,Description="改签"},
                 new Ticket(){ TicketNo="999-23572",OrderID=96576289,Description="改签"},
                 new Ticket(){ TicketNo="999-24971",OrderID=99321289,Description="成交"}
            };
        }
    }

}