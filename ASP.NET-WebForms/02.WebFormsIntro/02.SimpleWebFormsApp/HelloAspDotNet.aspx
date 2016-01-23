<%@ Page Title="Hello, ASP.NET" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HelloAspDotNet.aspx.cs" Inherits="_02.SimpleWebFormsApp.HelloAspDotNet" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div>
            <asp:Label ID="lblHelloFromAspx" Text="Hello, ASP.NET" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblHello" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
