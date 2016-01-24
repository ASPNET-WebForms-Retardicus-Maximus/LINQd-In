<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="Public.aspx.cs" Inherits="LINQdIn.Profile.Public" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="UserFormView" ItemType="LINQdIn.Models.User" SelectMethod="Select" CssClass="">
        <ItemTemplate>
            <div class="panel panel-primary" style="-moz-min-width: 450px; -ms-min-width: 450px; -o-min-width: 450px; -webkit-min-width: 450px; min-width: 450px">
                <div class="panel-heading">
                    <h2 class="text-center"><i><%#: Item.FirstName %> <%#: Item.LastName %> </i></h2>
                </div>
                <div class="text-center" style="padding-top: 10px">
                    <img src="<%# Item.ProfilePhotoUrl %>" alt="<%# Item.FirstName %>" width="300" height="300" runat="server" style="-ms-border-radius: 300px; border-radius: 300px" />
                </div>
                <div class="text-center">
                    <div class="btn-group-sm">
                        <a><i class=""></i></a>
                    </div>
                </div>
                <hr />
                <div class="text-center">
                    Summary: 
            <%# Item.Summary %>
                </div>

                <div class="text-center">
                    <div class="form-group has-warning">
                        <label class="col-lg-4 col-md-4 control-label">&nbsp;Email:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.Email %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;First Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.FirstName %></label>
                        </div>
                    </div>
                    <div class="form-group has-success">
                        <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>&nbsp;Last Name:</label>
                        <div class="col-lg-8 col-md-8">
                            <label><%# Item.LastName %></label>
                        </div>
                    </div>
                    <div class="form-group">
                        Portfolio: <a href="<%# Item.Portfolio %>"><%# Item.Portfolio %></a>
                    </div>
                    <div class="form-group">
                        Skills: 
                            <asp:Repeater runat="server" ID="userSkillsGridView" ItemType="LINQdIn.Models.Skill" SelectMethod="GetSkills">
                                <HeaderTemplate>
                                    <table class="table table-responsive table-condensed table-hover">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Item.Name %></td>
                                        <td>
                                            <a href="/#" class="btn btn-sm btn-primary"><span class="glyphicon glyphicon-check"></span>&nbsp;Endorse!</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                    </div>
                    <div class="form-group">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                Latest Endorsements: 
                            </div>
                            <div class="panel-body">
                                <asp:Repeater runat="server" ID="Repeater1" ItemType="LINQdIn.Models.Endorsement" SelectMethod="GetEndorsements">
                                    <HeaderTemplate>
                                        <table class="table table-responsive table-condensed table-hover">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Item.Skill.Name %></td>
                                            <td>
                                                <a href="/Profile/Public?userId=<%# Item.UserId %>" class="btn btn-sm">&nbsp;<%# string.Format("{0} {1}", Item.EndorsedBy.FirstName, Item.EndorsedBy.LastName) %></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
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
