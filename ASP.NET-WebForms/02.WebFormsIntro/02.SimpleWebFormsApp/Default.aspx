<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.SimpleWebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class=".form-control">

        <h3>Task:</h3>
        <strong>Start Visual Studio and create new Web Forms App.
        Look at the files generated and tell what's purpose of each file.
        Explain the "code behind" model. Print "Hello, ASP.NET" from the C# code and from the aspx code.
        Display the current assembly location by Assembly.GetExecutingAssembly().Location.
        </strong>

    </div>

    <div class="jumbotron">
        <div class="col-md-3">
            <a href="FilesPurpose.aspx">Files Purpose</a>
        </div>
        <div class="col-md-3">
            <a href="CodeBehind.aspx">Code Behind</a>
        </div>
        <div class="col-md-3">
            <a href="HelloAspDotNet.aspx">Hello ASP.NET</a>
        </div>
        <div class="col-md-3">
            <a href="Location.aspx">Assembly Location</a>
        </div>
    </div>



</asp:Content>
