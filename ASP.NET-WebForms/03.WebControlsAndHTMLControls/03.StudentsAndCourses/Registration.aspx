<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_03.StudentsAndCourses.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="First Name:" runat="server" />
            <asp:TextBox ID="tb_firstName" runat="server" />
        </div>
        <div>
            <asp:Label Text="Last Name:" runat="server" />
            <asp:TextBox ID="tb_lastName" runat="server" />
        </div>
        <div>
            <asp:Label Text="Faculty Number:" runat="server" />
            <asp:TextBox ID="tb_facultyNumber" runat="server" />
        </div>
        <div>
            <asp:Label Text="University:" runat="server" />
            <asp:DropDownList ID="ddl_university" runat="server">
                <asp:ListItem Text="TU-Sofia" />
                <asp:ListItem Text="Sofia University" />
                <asp:ListItem Text="NBU" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label Text="Specialty:" runat="server" />
            <asp:DropDownList ID="ddl_specialty" runat="server">
                <asp:ListItem Text="Telecommunications" />
                <asp:ListItem Text="Computer Science" />
                <asp:ListItem Text="Elektrotechnik" />
                <asp:ListItem Text="Marketing" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label Text="Courses:" runat="server" />
            <br />
            <asp:ListBox ID="lb_courses" SelectionMode="Multiple" runat="server">
                <asp:ListItem Text="Neural Network" />
                <asp:ListItem Text="Marketing Fundamentals" />
                <asp:ListItem Text="Radiocommunications" />
                <asp:ListItem Text="Elektrotechnik part 1" />
            </asp:ListBox>
        </div>
        <div>
            <asp:Button Text="Submit" ID="btn_submit" OnClick="Submit_Click" runat="server" />
        </div>
    </form>
</body>
</html>
