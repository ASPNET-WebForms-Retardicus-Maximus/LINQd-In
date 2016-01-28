<%@ Page Language="C#" Title="Manage Users" AutoEventWireup="true" MasterPageFile="~/Admin/Default.master" CodeBehind="Users.aspx.cs" Inherits="LINQdIn.Admin.Users" %>

<asp:Content runat="server" ContentPlaceHolderID="admincontent">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage Regular Users</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="LINQdIn.Models.User"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                SelectMethod="Select"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                CssClass="table table-hover table-striped table-responsive"
                ID="gvUsers"
                OnRowDataBound="gvUsers_OnRowDataBound">
                <Columns>
                    <asp:BoundField SortExpression="Email" HeaderText="Email" DataField="Email" />
                    <asp:BoundField SortExpression="FirstName" HeaderText="FirstName" DataField="FirstName" />
                    <asp:BoundField SortExpression="LastName" HeaderText="LastName" DataField="LastName" />
                    <asp:BoundField SortExpression="GithubProfile" HeaderText="GithubProfile" DataField="GithubProfile" />
                    <asp:BoundField SortExpression="RegisteredOn" HeaderText="RegisteredOn" DataField="RegisteredOn" />
                    <asp:TemplateField HeaderText="Roles">
                        <ItemTemplate>
                            <%#: GetRoles(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-raised" />
                </Columns>
            </asp:GridView>
            <div class="text-center">
            </div>
        </div>
    </div>

    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage Employers</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="LINQdIn.Models.User"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                SelectMethod="SelectEmployers"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                CssClass="table table-hover table-striped table-responsive"
                ID="gvEmployers">
                <Columns>
                    <asp:BoundField SortExpression="Email" HeaderText="Email" DataField="Email" />
                    <asp:BoundField SortExpression="FirstName" HeaderText="FirstName" DataField="FirstName" />
                    <asp:BoundField SortExpression="LastName" HeaderText="LastName" DataField="LastName" />
                    <asp:BoundField SortExpression="GithubProfile" HeaderText="GithubProfile" DataField="GithubProfile" />
                    <asp:BoundField SortExpression="RegisteredOn" HeaderText="RegisteredOn" DataField="RegisteredOn" />
                    <asp:TemplateField HeaderText="Roles">
                        <ItemTemplate>
                            <%#: GetRoles(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-raised" />
                </Columns>
            </asp:GridView>
            <div class="text-center">
            </div>
        </div>
    </div>

    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage Admins</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="LINQdIn.Models.User"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                SelectMethod="SelectAdmins"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                ID="gvAdmins"
                CssClass="table table-hover table-striped table-responsive">
                <Columns>
                    <asp:BoundField SortExpression="Email" HeaderText="Email" DataField="Email" />
                    <asp:BoundField SortExpression="FirstName" HeaderText="FirstName" DataField="FirstName" />
                    <asp:BoundField SortExpression="LastName" HeaderText="LastName" DataField="LastName" />
                    <asp:BoundField SortExpression="GithubProfile" HeaderText="GithubProfile" DataField="GithubProfile" />
                    <asp:BoundField SortExpression="RegisteredOn" HeaderText="RegisteredOn" DataField="RegisteredOn" />
                    <asp:TemplateField HeaderText="Roles">
                        <ItemTemplate>
                            <%#: GetRoles(Item.Id) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-raised" />
                </Columns>
            </asp:GridView>
            <div class="text-center">
            </div>
        </div>
    </div>
</asp:Content>
