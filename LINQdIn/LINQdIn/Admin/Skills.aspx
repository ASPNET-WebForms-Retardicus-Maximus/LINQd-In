<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Default.master" CodeBehind="Skills.aspx.cs" Inherits="LINQdIn.Admin.Skills" %>

<asp:Content runat="server" ContentPlaceHolderID="admincontent">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage skills</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="LINQdIn.Models.Skill"
                SelectMethod="Select"
                AllowPaging="true"
                PageSize="5"
                AllowSorting="true"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                UpdateMethod="Update"
                DeleteMethod="Delete"
                ID="gvSkills">
                <Columns>
                    <asp:BoundField SortExpression="Name" HeaderText="Name" DataField="Name" />
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-raised" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
