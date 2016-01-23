<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomWithHtmlControlls.aspx.cs" Inherits="_01.Random.RandomWithHtmlControlls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Generate a random number</h2>
        <div>
            <label>Lower boundary:</label>
            <input id="firstNumber" runat="server" />
        </div>
        <div>
            <label>Upper boundary:</label>
            <input id="secondNumber" runat="server"/>
        </div>
        <div>
            <input type="button" id="btnGetRandom" onserverclick="GetRandom" value="Get Random" runat="server" />
        </div>
        <div>
            <label id="result" runat="server"></label>
        </div>
    </form>
</body>
</html>
