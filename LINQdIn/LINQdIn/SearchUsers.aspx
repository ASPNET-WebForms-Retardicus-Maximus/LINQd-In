<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchUsers.aspx.cs" Inherits="LINQdIn.SearchUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-responsive table-hover"
        AllowPaging="True" DataKeyNames="ID"
        OnPageIndexChanging="GridViewUsers_PageIndexChanging"
        OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged"
        OnRowDataBound="GridViewUsers_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Skills" HeaderText="Skills" />
            <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" ControlStyle-CssClass="btn btn-sm btn-raised btn-primary"
                DataNavigateUrlFormatString='~/Profile/Public?userId={0}' />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnPrevious" Text="<" runat="server" CommandArgument="-1" OnCommand="ChangePage" CssClass="btn btn-md btn-success" />
    <asp:Label ID="lblCurrentPage" Text="0" runat="server" />
    <asp:Button ID="btnNext" Text=">" runat="server" CommandArgument="1" OnCommand="ChangePage" CssClass="btn btn-md btn-success" />
</asp:Content>
