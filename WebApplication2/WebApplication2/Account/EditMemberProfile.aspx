<%@ Page Title="Edit Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditMemberProfile.aspx.cs" Inherits="WebApplication2.Account.EditMemberProfile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Edit your Profile</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tfirst" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tfirst" CssClass="form-control"  />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tlast" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tlast"  CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="EditMember_Click" Text="Update" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    
</asp:Content>
