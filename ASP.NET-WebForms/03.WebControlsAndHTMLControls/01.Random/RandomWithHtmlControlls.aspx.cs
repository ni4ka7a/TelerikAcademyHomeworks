using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Random
{
    public partial class RandomWithHtmlControlls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GetRandom(object sender, EventArgs e)
        {
            var random = new System.Random();

            int firstNumber;
            int secondNumber;

            try
            {
                firstNumber = int.Parse(this.firstNumber.Value);
                secondNumber = int.Parse(this.secondNumber.Value);
                this.result.InnerText = random.Next(firstNumber, secondNumber).ToString();
            }
            catch (Exception)
            {
                this.result.InnerText = "Invalid boundary!";
            }

        }
    }
}