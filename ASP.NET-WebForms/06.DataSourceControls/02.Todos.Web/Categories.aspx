<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="_02.Todos.Web.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="CategoriesListView"
        SelectMethod="CategoriesListView_GetData"
        UpdateMethod="CategoriesListView_UpdateItem"
        InsertMethod="CategoriesListView_InsertItem"
        DeleteMethod="CategoriesListView_DeleteItem"
        InsertItemPosition="LastItem"
        ItemType="_02.Todos.Models.Category"
        DataKeyNames="Id"
        runat="server" >
        <LayoutTemplate>
            <h1>Todos:</h1>
            <table class="table table-striped table-hover">
                <td>Name</td>
                <td>Todos count</td>
                <td></td>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="itemPlaceholder">
                <td><%#: Item.Name %></td>
                <td><%#: Item.Todos.Count %></td>
                <td>
                    <asp:LinkButton runat="Server" Text="Edit" CommandName="Edit" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="form-horizontal">
                <legend>Add New Author</legend>
                <div class="form-group">
                    <label for="NameInput" class="col-lg-2 control-label">Title</label>
                    <div class="col-lg-2">
                        <asp:TextBox runat="server" ID="NameInput" class="form-control" Text="<%# BindItem.Name %>"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:Button runat="server" CommandName="Update" ID="UpdateButton" Text="Update" class="btn btn-primary" />
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" class="btn btn-danger" />
                        <asp:Button runat="server" CommandName="Cancel" ID="CancelButton" Text="Cancel" class="btn btn-default" />
                    </div>
                </div>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <td>
                <asp:TextBox runat="server" placeholder="Title" class="form-control" ID="CategoryName" Text="<%# BindItem.Name %>"></asp:TextBox>
            </td>
            <td>
                <asp:Button runat="server" CommandName="Insert" Text="Insert" class="btn btn-success" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-default" />
            </td>
        </InsertItemTemplate>
        </asp:ListView>
</asp:Content>
