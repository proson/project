using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CacheApplication
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(DateTime.Now.ToString());
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            HttpRuntime.Cache.Remove("Index_Key");
        }
    }
}