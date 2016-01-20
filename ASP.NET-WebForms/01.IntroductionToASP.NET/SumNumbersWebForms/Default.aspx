<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SumNumbersWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>This is a simple calculator for sum two numbers</h1>

    <div class="form-group">
        <br />
        <asp:Label ID="lblFirstNumber" runat="server" Text="Label" class="col-lg-2 control-label">Enter the first number:</asp:Label>
        <asp:TextBox ID="tbFirstNumber" runat="server" class="form-control"></asp:TextBox>
        <br />

        <asp:Label ID="lblSecondNumber" runat="server" Text="Label" class="col-lg-2 control-label">Enter the second number</asp:Label>
        <asp:TextBox ID="tbSecondNumber" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class="form-group" style="width: 40%">
        <asp:Button ID="btnCalculate" OnClick="btnCalcuate_Click" runat="server" Text="Calcuate" class="btn btn-primary pull-right" />
    </div>

    <div class="form-group">
        <div>The sum is:</div>

        <strong id="result" runat="server"></strong>
    </div>

</asp:Content>
