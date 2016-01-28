<%@ Page Language="C#" Title="Manage Skills" AutoEventWireup="true" MasterPageFile="~/Admin/Default.master" CodeBehind="Skills.aspx.cs" Inherits="LINQdIn.Admin.Skills" %>

<asp:Content runat="server" ContentPlaceHolderID="admincontent">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h2>Manage skills</h2>
        </div>
        <div class="panel-body">
            <asp:GridView runat="server"
                ItemType="LINQdIn.Models.Skill"
                SelectMethod="Select"
                AllowPaging="true"
                PageSize="10"
                AllowSorting="true"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                UpdateMethod="Update"
                DeleteMethod="Delete"
                CssClass="table table-hover table-striped table-responsive"
                ID="gvSkills">
                <Columns>
                    <asp:BoundField SortExpression="Id" HeaderText="Id" DataField="Id" />
                    <asp:BoundField SortExpression="Name" HeaderText="Name" DataField="Name" />
                    <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info btn-raised" />
                    <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-raised" />
                </Columns>
            </asp:GridView>
            <div class="text-center">
                <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                        <h4>Add skill:</h4>
                        <p> Skill name: <asp:TextBox runat="server" ID="newSkill"/></p>
                        <asp:Button Text="Add" runat="server" ID="BtnAdd" OnClick="OnClick"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger runat="server" ControlID="BtnAdd" EventName="Click"/>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
