<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Site.Master" CodeBehind="EditProfile.aspx.cs" Inherits="LINQdIn.Profile.EditProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit profile Page</h2>

    <div class="text-center">

        <div class="has-success">
            <label class="col-lg-4 col-md-4 control-label"><span class="glyphicon glyphicon-pencil"></span>Change profile photo:</label>
            <asp:FileUpload ID="ImageFileUpload" runat="server" />
            <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
            <br />
            <br />
            <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
        </div>
    </div>

</asp:Content>
