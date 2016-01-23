<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_02.Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tb_inputText" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_submit" OnClick="Submit_Click" Text="Submit" runat="server" />
        </div>

        <h3>Output:</h3>
        <div>
            <asp:Label ID="lbl_output" runat="server" />
        </div>
        <div>
            <asp:TextBox ID="tb_output" runat="server" />
        </div>
    </form>
</body>
</html>
