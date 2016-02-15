using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.CachingData.Web.Controls
{
    public partial class WelcomeLabel : System.Web.UI.UserControl
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.LabelWelcome.Text = "Welcome, " + Server.HtmlEncode(this.name) + "! To Prove I am cached i will Show you DateTime.Now - " + DateTime.Now.ToString();
            }
        }

        public Color Color
        {
            get
            {
                return this.LabelWelcome.ForeColor;
            }
            set
            {
                this.LabelWelcome.ForeColor = value;
            }
        }

        private Color alternateColor;

        public Color AlternateColor
        {
            get
            {
                return this.alternateColor;
            }
            set
            {
                this.alternateColor = value;
            }
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            this.LabelWelcome.Attributes["onmouseover"] =
                "changeColor(this,'" + ToWebColor(this.AlternateColor) + "')";
            this.LabelWelcome.Attributes["onmouseout"] =
                "changeColor(this,'" + ToWebColor(this.Color) + "')";
        }

        private string ToWebColor(Color color)
        {
            if (color.IsNamedColor)
            {
                return color.Name;
            }
            else
            {
                return String.Format(
                    "#{0:x}{1:x}{2:x}",
                    color.R, color.G, color.B);
            }
        }
    }
}