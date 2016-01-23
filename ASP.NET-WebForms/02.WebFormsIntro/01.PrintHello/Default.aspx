<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.PrintHello.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSumbit" runat="server" Text="submit" OnClick="submit_Click" />

            <div>
                <asp:Label ID="output" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
