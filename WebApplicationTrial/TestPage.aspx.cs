using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTrial
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Changed by Server Code" + DateTime.Now.ToString();
            TextBox1.Text="Changed by server"+DateTime.Now.ToString();
        }
    }
}