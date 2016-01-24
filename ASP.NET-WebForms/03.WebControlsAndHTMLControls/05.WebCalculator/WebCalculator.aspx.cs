using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.WebCalculator
{
    public partial class WebCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "C")
            {
                Response.Redirect("~/WebCalculator.aspx");
            }

            int number;

            var isNumber = int.TryParse(e.CommandArgument.ToString(), out number);

            if (isNumber)
            {
                this.result.Text += number;
                return;
            }

            if (e.CommandArgument.ToString() == "√")
            {
                if (this.result.Text != string.Empty)
                {
                    this.result.Text = Math.Sqrt((double)decimal.Parse(this.result.Text)).ToString();
                    return;
                }
            }

            if (this.firstNumber.Value == string.Empty)
            {
                this.firstNumber.Value = this.result.Text;
                this.@operator.Text = e.CommandArgument.ToString();
                this.result.Text = string.Empty;
            }

            else if (this.secondNumber.Value == string.Empty)
            {
                this.secondNumber.Value = this.result.Text;
                this.result.Text = Calculate();
                this.firstNumber.Value = string.Empty;
                this.secondNumber.Value = string.Empty;
            }
        }

        private string Calculate()
        {
            switch (this.@operator.Text[0])
            {
                case '+': return (decimal.Parse(this.firstNumber.Value) + decimal.Parse(this.secondNumber.Value)).ToString();
                case '-': return (decimal.Parse(this.firstNumber.Value) - decimal.Parse(this.secondNumber.Value)).ToString();
                case 'X': return (decimal.Parse(this.firstNumber.Value) * decimal.Parse(this.secondNumber.Value)).ToString();
                case '/': return (decimal.Parse(this.firstNumber.Value) / decimal.Parse(this.secondNumber.Value)).ToString();
                default:
                    return null;
            }
        }
    }
}