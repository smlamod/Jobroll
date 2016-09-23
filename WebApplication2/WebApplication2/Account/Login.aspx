<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Account.Login" Async="true" EnableEventValidation="false" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Sign in</h2>
    <div id="login-local">
        <h4>Use a local account to log in.</h4>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="input-item">
            <label class="input-label">Email</label>
            <div class="input-field-group">
                <asp:TextBox runat="server" ID="Email" CssClass="input-field" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="input-item">
            <label class="input-label">Password</label>
            <div class="input-field-group">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input-field" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="login-button-group">
            <asp:CheckBox runat="server" ID="RememberMe" /><label style="padding-left: 10px;">Remember me?</label>
            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn-new" style="float: right; margin: 5px 123px 0 0;"/>
        </div>
        <%--<div class="form-group">--%>

        <%--<div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn-new" />
            </div>--%>
        <%--</div>--%>

        <p>
            <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
            --%>
        </p>
    </div>
    <%--    </div>--%>
    <div class="login-external">
        <section id="socialLoginForm">
            <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
        </section>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
        </p>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
