<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomWithWebControlls.aspx.cs" Inherits="_01.Random.RandomWithWebControlls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Generate a random number</h2>
        <div>
            <asp:Label ID="lbl_lowerBoundary" runat="server">Lower Boundary</asp:Label>
            <asp:TextBox ID="tb_lowerBoundary" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_upperBoundary" runat="server">Upper Boundary</asp:Label>
            <asp:TextBox ID="tb_UpperBoundary" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_getRandom" runat="server" Text="Get Random" OnClick="GetRandom"/>
        </div>
        <div>
            <asp:Label ID="result" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
