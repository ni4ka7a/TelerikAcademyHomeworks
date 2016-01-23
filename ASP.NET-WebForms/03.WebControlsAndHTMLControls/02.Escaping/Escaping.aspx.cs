using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var inputText = Server.HtmlEncode(this.tb_inputText.Text);

            this.tb_output.Text = inputText;
            this.lbl_output.Text = inputText;
        }
    }
}