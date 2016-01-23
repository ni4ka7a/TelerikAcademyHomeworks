using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SimpleWebFormsApp
{
    public partial class HelloAspDotNet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblHello.Text = "Hello, ASP.NET - I came from the `code behind`";
        }
    }
}