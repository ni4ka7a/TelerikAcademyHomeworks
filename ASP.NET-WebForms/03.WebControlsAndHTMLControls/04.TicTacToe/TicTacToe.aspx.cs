using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.TicTacToe
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        private const string BlankImageUrl = "~/Content/blank.png";
        private const string XImageUrl = "~/Content/x.png";
        private const string OImageUrl = "~/Content/o.png";
        private List<ImageButton> buttons;

        protected void Page_Load(object sender, EventArgs e)
        {
            buttons = new List<ImageButton>();

            foreach (TableRow row in this.field.Controls)
            {
                foreach (TableCell item in row.Controls)
                {
                    var imgButton = item.Controls[0] as ImageButton;

                    if (imgButton != null)
                    {
                        buttons.Add(imgButton);
                    }
                }
            }
        }

        protected void Play(object sender, CommandEventArgs e)
        {

            var currentButton = this.buttons.FirstOrDefault(b => b.ID == e.CommandArgument.ToString());

            if (currentButton.ImageUrl == BlankImageUrl)
            {
                currentButton.ImageUrl = XImageUrl;

                var aiMove = this.buttons
                    .Where(b => b.ImageUrl == BlankImageUrl)
                    .OrderBy(b => Guid.NewGuid())
                    .FirstOrDefault();

                if (aiMove != null)
                {
                    aiMove.ImageUrl = OImageUrl;
                }
            }

            var winner = this.CheckDiagonals();
            if (winner == XImageUrl)
            {
                this.output.Text = "You WON!!!";
                this.DisableButtensOnGameOver();
            }
            else if(winner == OImageUrl)
            {
                this.output.Text = "You Loose!!!";
                this.DisableButtensOnGameOver();
            }

            winner = this.CheckRows();

            if (winner == XImageUrl)
            {
                this.output.Text = "You WON!!!";
                this.DisableButtensOnGameOver();
            }
            else if (winner == OImageUrl)
            {
                this.output.Text = "You Loose!!!";
                this.DisableButtensOnGameOver();
            }

            winner = this.CheckCols();

            if (winner == XImageUrl)
            {
                this.output.Text = "You WON!!!";
                this.DisableButtensOnGameOver();
            }
            else if (winner == OImageUrl)
            {
                this.output.Text = "You Loose!!!";
                this.DisableButtensOnGameOver();
            }
        }

        protected void StartOver(object sender, EventArgs e)
        {
            Response.Redirect("~/TicTacToe.aspx");
        }

        private void DisableButtensOnGameOver()
        {
            foreach (var item in this.buttons)
            {
                item.OnClientClick = "this.disabled = true;";
            }
        }

        private string CheckDiagonals()
        {
            if (this.buttons[0].ImageUrl == this.buttons[4].ImageUrl &&
                this.buttons[0].ImageUrl == this.buttons[8].ImageUrl)
            {
                return this.buttons[0].ImageUrl;
            }

            else if(this.buttons[2].ImageUrl == this.buttons[4].ImageUrl &&
                    this.buttons[2].ImageUrl == this.buttons[6].ImageUrl)
            {
                return this.buttons[2].ImageUrl;
            }

            return null;
        }

        private string CheckCols()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.buttons[i].ImageUrl == this.buttons[i + 3].ImageUrl &&
                    this.buttons[i].ImageUrl == this.buttons[i + 6].ImageUrl)
                {
                    return this.buttons[i].ImageUrl;
                }
            }

            return null;
        }

        private string CheckRows()
        {
            for (int i = 0; i < this.buttons.Count; i += 3)
            {
                if (this.buttons[i].ImageUrl == this.buttons[i + 1].ImageUrl &&
                    this.buttons[i].ImageUrl == this.buttons[i + 2].ImageUrl)
                {
                    return this.buttons[i].ImageUrl;
                }
            }

            return null;
        }
    }
}