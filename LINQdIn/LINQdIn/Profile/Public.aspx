<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Public.aspx.cs" Inherits="LINQdIn.Profile.Public" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="UserFormView" ItemType="LINQdIn.Models.User" SelectMethod="Select" CssClass="">
        <ItemTemplate>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h2><i><%#: Item.FirstName %> <%#: Item.LastName %> </i></h2>
                </div>
                <div class="text-center" style="padding-top: 10px">
                    <img src="<%# Item.ProfilePhotoUrl %>" alt="<%# Item.FirstName %>" width="300" height="300" runat="server" style="-ms-border-radius: 300px; border-radius: 300px"/>
                </div>
                <hr />
                <div class="text-center">
                    Summary: 
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
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"> </span>First Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.FirstName %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"> </span>Last Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.LastName %></label>
                        </div>
                    </div>
                    <div class="form-group">
                        Skills: 
                            <asp:GridView runat="server" ID="userSkillsGridView">
                                
                            </asp:GridView>
                    </div>
                    <div class="form-group">
                        Education:
                    </div>
                    <div class="form-group">
                        Connections:
                    </div>
                </div>
                
                <div>
                    <a href="/#" class="btn btn-block btn-success">Add connection!</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
