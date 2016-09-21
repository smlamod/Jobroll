<%@ Page Title="Edit Profile" Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" CodeBehind="EditCompanyProfile.aspx.cs" Inherits="WebApplication2.Account.EditCompanyProfile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Edit the Company Profile</h4>
        <h4>
            <asp:Label ID="lmsg" runat="server" />
        </h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <h2>Information</h2>
        <div id="InfoDiv">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcname" CssClass="col-md-2 control-label">Company Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcname" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tcname"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Company Name Required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tcname" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcaddr" CssClass="col-md-2 control-label">Company Address</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcaddr" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tcaddr"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Company Address is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tcaddr" CssClass="text-error" />

                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcphone" CssClass="col-md-2 control-label">Phone Number</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcphone" CssClass="form-control" TextMode="Phone" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tcphone"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Phone Number is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tcphone" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcover" CssClass="col-md-2 control-label">Overview</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcover" CssClass="form-control" TextMode="MultiLine" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcjoin" CssClass="col-md-2 control-label">Why Join</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcjoin" CssClass="form-control" TextMode="Multiline" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcproc" CssClass="col-md-2 control-label">Average application processing time</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcproc" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcindstry" CssClass="col-md-2 control-label">Industry Fields</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcindstry" CssClass="form-control" />
                </div>
            </div>


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcweb" CssClass="col-md-2 control-label">Web URL</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcweb" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcsize" CssClass="col-md-2 control-label">Company Size</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcsize" CssClass="form-control" />
                </div>
            </div>

                        <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tcemp" CssClass="col-md-2 control-label">Work Hours</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tcemp" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tccode" CssClass="col-md-2 control-label">Dress Code</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tccode" CssClass="form-control" />
                </div>
            </div>



            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="EditCompany_Click" Text="Update" CssClass="btn btn-default" />
                </div>
            </div>
        </div>



    </div>


</asp:Content>
