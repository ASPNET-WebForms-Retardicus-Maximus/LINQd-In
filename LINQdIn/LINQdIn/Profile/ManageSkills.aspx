<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSkills.aspx.cs" Inherits="LINQdIn.Profile.ManageSkills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server"
        ItemType="LINQdIn.ViewModels.SkillViewModel"
        SelectMethod="Unnamed_GetData1"
        DataKeyNames="Id"
        OnItemDataBound="Unnamed_ItemDataBound">
        <ItemTemplate>
            <h4>
                <%#: Item.Name %>
                <asp:Button Text="Add" runat="server" OnCommand="Unnamed_Command" CommandArgument="<%# Item.Id %>" />
            </h4>
        </ItemTemplate>
    </asp:ListView>

    <asp:Button ID="gosho" runat="server" />
</asp:Content>
