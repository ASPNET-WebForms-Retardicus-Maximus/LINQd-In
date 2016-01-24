<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Private.aspx.cs" Inherits="LINQdIn.Profile.Private" %>

<asp:content id="BodyContent" contentplaceholderid="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h2>Profile</h2>
        </div>
        <div class="text-center">
            <img src="#" alt="profile photo of ###" width="300" height="300" runat="server"/>
        </div>
        <div>
            <asp:FormView ID="ProfileFV" runat="server">
                <ItemTemplate>
                    
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:content>
