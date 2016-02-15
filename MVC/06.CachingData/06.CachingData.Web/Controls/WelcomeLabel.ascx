<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WelcomeLabel.ascx.cs" Inherits="_06.CachingData.Web.Controls.WelcomeLabel" %>
<%@ OutputCache Duration=3600 VaryByParam="None" %>

<script type="text/javascript">
    function changeColor(sender, color) {
        sender.style.color = color;
    }
</script>

<asp:Label ID="LabelWelcome" runat="server" />