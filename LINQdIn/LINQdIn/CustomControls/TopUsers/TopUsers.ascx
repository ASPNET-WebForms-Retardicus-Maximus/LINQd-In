<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopUsers.ascx.cs" Inherits="LINQdIn.CustomControls.TopUsers.TopUsers" %>

<div class="row">
    <asp:ListView runat="server" ID="lv" ItemType="LINQdIn.ViewModels.TopUserViewModel" SelectMethod="Select">
        <ItemTemplate>
            <div class="col-md-4 text-center">
                <img src="<%# Item.UserImage %>" runat="server" alt="Alternate Text" class="text-center" width="100" height="100" style="-ms-border-radius: 100px; border-radius: 100px"/>
                <h2><%#: Item.Username %></h2>
                <p>Endorsed a total of <h4><%# Item.SkillEndorseCount %></h4></p>
                <p><a href="/Profile/Public?userId=<%# Item.UserId %>">Visit Profile</a></p>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
