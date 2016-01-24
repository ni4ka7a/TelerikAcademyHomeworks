<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="_05.WebCalculator.WebCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <table>
            <thead>
                <tr>
                    <th colspan="3">
                        <asp:TextBox ID="result" runat="server" ReadOnly="true" />
                    </th>
                    <th>

                        <asp:Label ID="operator" runat="server" Text=""></asp:Label>
                    </th>
                </tr>
            </thead>
            <tr>
                <td>
                    <asp:Button Text="1" CommandArgument="1" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="2" CommandArgument="2" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="3" CommandArgument="3" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="+" CommandArgument="+" OnCommand="Button_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="4" CommandArgument="4" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="5" CommandArgument="5" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="6" CommandArgument="6" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="-" CommandArgument="-" OnCommand="Button_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="7" CommandArgument="7" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="8" CommandArgument="8" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="9" CommandArgument="9" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="X" CommandArgument="X" OnCommand="Button_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Clear" CommandArgument="C" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="0" CommandArgument="0" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="/" CommandArgument="/" OnCommand="Button_Click" runat="server" />
                </td>
                <td>
                    <asp:Button Text="√" CommandArgument="√" OnCommand="Button_Click" runat="server" />
                </td>
            </tr>
            <tfoot>
                <tr>
                    <td colspan="4">
                        <asp:Button Text="=" CommandArgument="=" OnCommand="Button_Click" runat="server" />
                    </td>
                </tr>
            </tfoot>
        </table>

        <input type="hidden"  id="firstNumber" runat="server" value="" />
        <input type="hidden"  id="secondNumber" runat="server" value="" />
    </form>
</body>
</html>
