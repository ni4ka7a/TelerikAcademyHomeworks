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
        protected void btnCalcuate_Click(object sender, EventArgs e)
        {
            decimal firstNumber;
            decimal secondNumber;

            var validFirstNumber = decimal.TryParse(this.tbFirstNumber.Text, out firstNumber);
            var validSecondNumber = decimal.TryParse(this.tbSecondNumber.Text, out secondNumber);

            if (!validFirstNumber)
            {
                this.result.InnerText = this.tbFirstNumber.Text + " is invalid";
            }

            else if (!validSecondNumber)
            {
                this.result.InnerText = this.tbSecondNumber.Text + " is invalid";
            }

            else
            {
                this.result.InnerText = (firstNumber + secondNumber).ToString();
            }
        }
    }
}