<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_06.CachingData.Web._Default" %>

<%@ Register Src="~/Controls/WelcomeLabel.ascx" TagPrefix="userControls"
    TagName="WelcomeLabel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Caching Data Homework</h1>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Enjoy</a></p>
    </div>

    <div class="lead">Task 1: Make About.aspx page cacheable for 1 hour - Go to /About </div>

    <div class="lead">Task 2: Create cacheable user control:</div>

    <div>
        This is a simple cacheable  user control from the TelerikAcademy demos.
            More information about the control:
            <a href="https://github.com/TelerikAcademy/ASP.NET-Web-Forms/tree/master/13.%20User-Controls/Demo">Here</a>
    </div>

    <div class="lead">
        <userControls:WelcomeLabel ID="WelcomeLabelMaria" runat="server"
            Name="I am a cacheable User Control. Please Hover me" Color="#FF0000" AlternateColor="#000" />
    </div>

</asp:Content>
