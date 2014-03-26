using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTML5Pro
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             //System.Threading.Thread.Sleep(10000);
            int j = 0;
            for (int i = 0; i < 10000; i++)
            {
                j++;
            }
            //Response.Write(j);
            iii.InnerText = j.ToString();

        }

        
    }
}