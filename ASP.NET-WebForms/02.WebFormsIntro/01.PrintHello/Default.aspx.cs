using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.PrintHello
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            var name = this.tbName.Text;

            if (string.IsNullOrEmpty(name))
            {
                this.output.Text = "Invalid name!";
            }

            else
            {
                this.output.Text = "Hello " + name;
            }
        }
    }
}