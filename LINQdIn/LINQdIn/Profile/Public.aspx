<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Public.aspx.cs" Inherits="LINQdIn.Profile.Public" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="UserFormView" ItemType="LINQdIn.Models.User" SelectMethod="Select">
        <ItemTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h2>Profile page of <i><%#: Item.FirstName %> <%#: Item.LastName %> </i></h2>
                </div>
                <div class="text-center" style="padding-top: 10px">
                    <img src="<%# Item.ProfilePhotoUrl %>" alt="<%# Item.FirstName %>" width="300" height="300" runat="server" />
                </div>
                <hr />
                <div class="text-center">
                    User Summary: 
            <%# Item.Summary %>
                </div>

                <div class="text-center">
                    <div class="form-group has-warning">
                        <label class="col-lg-4 col-md-4 control-label">Username:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.UserName %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>First Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.FirstName %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>Last Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.LastName %></label>
                        </div>
                    </div>
                    <div class="form-group">
                        Skills: 
                    </div>
                    <div class="form-group">
                        Education:
                    </div>
                    <div class="form-group">
                        Connections:
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
