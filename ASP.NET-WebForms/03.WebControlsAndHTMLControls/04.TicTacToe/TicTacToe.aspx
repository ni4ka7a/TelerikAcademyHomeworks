<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="_04.TicTacToe.TicTacToe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="bform1" runat="server">
        <asp:Table ID="field" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b1" CommandArgument="b1" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b2" CommandArgument="b2" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b3" CommandArgument="b3" OnCommand="Play" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b4" CommandArgument="b4" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b5" CommandArgument="b5" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b6" CommandArgument="b6" OnCommand="Play" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b7" CommandArgument="b7" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b8" CommandArgument="b8" OnCommand="Play" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ImageButton ImageUrl="~/Content/blank.png" ID="b9" CommandArgument="b9" OnCommand="Play" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div id="startOver">
            <asp:Button Text="Start Over" OnClick="StartOver" runat="server" />
        </div>
        <div>
            <asp:Label ID="output" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
