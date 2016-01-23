using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Random
{
    public partial class RandomWithWebControlls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GetRandom(object sender, EventArgs e)
        {
            var random = new System.Random();

            try
            {
                var lowerBoundary = int.Parse(this.tb_lowerBoundary.Text);
                var upperBoundary = int.Parse(this.tb_UpperBoundary.Text);
                this.result.Text = random.Next(lowerBoundary, upperBoundary).ToString();
            }
            catch (Exception)
            {
                this.result.Text = "Invalid Boundaries";
            }
        }
    }
}