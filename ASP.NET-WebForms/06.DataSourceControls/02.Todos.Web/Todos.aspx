<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="_02.Todos.Web.Todos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="TodosListView"
        SelectMethod="TodosListView_GetData"
        UpdateMethod="TodosListView_UpdateItem"
        InsertMethod="TodosListView_InsertItem"
        DeleteMethod="TodosListView_DeleteItem"
        InsertItemPosition="LastItem"
        ItemType="_02.Todos.Models.Todo"
        DataKeyNames="Id"
        runat="server" >
        <LayoutTemplate>
            <h1>Todos:</h1>
            <table class="table table-striped table-hover">
                <td>Title</td>
                <td>Body</td>
                <td>Category</td>
                <td>LastModified</td>
                <td></td>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="itemPlaceholder">
                <td><%#: Item.Title %></td>
                <td><%#: Item.Body %></td>
                <td><%#: Item.Category.Name %></td>
                <td><%#: Item.LastModified %></td>
                <td>
                    <asp:LinkButton runat="Server" Text="Edit" CommandName="Edit" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="form-horizontal">
                <legend>Add New Author</legend>
                <div class="form-group">
                    <label for="TitleInput" class="col-lg-2 control-label">Title</label>
                    <div class="col-lg-2">
                        <asp:TextBox runat="server" ID="TitleInput" class="form-control" Text="<%# BindItem.Title %>"></asp:TextBox>
                    </div>
                     <div class="col-lg-2">
                        <asp:TextBox runat="server" ID="TextBox1" class="form-control" Text="<%# BindItem.Body %>"></asp:TextBox>
                    </div>
                     <div class="col-lg-2">
                        <asp:TextBox runat="server" ID="TextBox3" class="form-control" Text="<%# BindItem.Category.Name %>"></asp:TextBox>
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
                <asp:TextBox runat="server" placeholder="Title" class="form-control" ID="TodoUpdatedName" Text="<%# BindItem.Title %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox runat="server" placeholder="Todo Body" class="form-control" ID="TodoUpdatedBody" Text="<%# BindItem.Body %>"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox runat="server" placeholder="Category" class="form-control" ID="tbCategories" Text="<%# BindItem.Category.Name %>"></asp:TextBox>
            </td>
            <td>
                <asp:Button runat="server" CommandName="Insert" Text="Insert" class="btn btn-success" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-default" />
            </td>
        </InsertItemTemplate>
        </asp:ListView>
</asp:Content>
