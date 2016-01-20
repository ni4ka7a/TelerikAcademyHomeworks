using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumNumbersWebForms
{
    public partial class _Default : Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal firstNumber;
            decimal secondNumber;

            var validFirstNumber = decimal.TryParse(this.TextBox1.Text, out firstNumber);
            var validSecondNumber = decimal.TryParse(this.TextBox2.Text, out secondNumber);

            if (!validFirstNumber)
            {
                this.result.InnerText = this.TextBox1.Text + " is invalid";
            }

            else if (!validSecondNumber)
            {
                this.result.InnerText = this.TextBox2.Text + " is invalid";
            }

            else
            {
                this.result.InnerText = (firstNumber + secondNumber).ToString();
            }
        }
    }
}