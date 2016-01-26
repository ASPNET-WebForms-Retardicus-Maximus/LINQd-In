<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="EditProfile.aspx.cs" Inherits="LINQdIn.Profile.EditProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit profile Page</h2>
    <div>
        <div class="text-center">

            <div class="has-success">
                <div>
                    <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>Change profile photo:</label>
                    <asp:FileUpload ID="ImageFileUpload" runat="server" />
                    <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
                </div>
            </div>
            <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
        </div>
        
        <asp:FormView runat="server"
            ItemType="LINQdIn.Models.User" DefaultMode="Edit" DataKeyNames="Id"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the User with Id <%: Request.QueryString["Id"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="Edit" DataField="FirstName" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="LastName" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="Summary" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="TwitterProfile" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="GithubProfile" runat="server" />
                    <asp:DynamicControl Mode="Edit" DataField="Portfolio" runat="server" />

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
                    </div>
                </fieldset>

            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
