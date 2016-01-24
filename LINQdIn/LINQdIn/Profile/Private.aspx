<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Private.aspx.cs" Inherits="LINQdIn.Profile.Private" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h2><%# DbUser.FirstName %> <%# DbUser.LastName %></h2>
        </div>
        <div class="text-center" style="padding-top: 10px">
            <img src="<%# DbUser.ProfilePhotoUrl %>" alt="<%# DbUser.FirstName %>" width="300" height="300" runat="server" style="-ms-border-radius: 300px; border-radius: 300px"/>
        </div>
        <hr />
        <div class="text-center">
            User Summary: 
            <%# DbUser.Summary %>
        </div>

        <div class="text-center">
            <div class="form-group has-warning">
                <label class="col-lg-4 col-md-4 control-label">Username:</label>
                <div class="col-lg-8 col-md-8">
                    <label><%# DbUser.UserName %></label>
                </div>
            </div>
            <div class="form-group has-success">
                <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>First Name:</label>
                <div class="col-lg-8 col-md-8">
                    <label><%# DbUser.FirstName %></label>
                </div>
            </div>
            <div class="form-group has-success">
                <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>Last Name:</label>
                <div class="col-lg-8 col-md-8">
                    <label><%# DbUser.LastName %></label>
                </div>
            </div>
            <div class="form-group">
                
            </div>
        </div>
    </div>
</asp:Content>