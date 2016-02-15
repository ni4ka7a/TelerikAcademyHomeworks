<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="_06.CachingData.Web.About" %>
<%@ OutputCache Duration=3600 VaryByParam="None" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Note: This page use caching!</h2>
    <p>Current Time:</p>
    <asp:Label ID="lvlCurrenTime" CssClass="lead" runat="server" />
</asp:Content>
