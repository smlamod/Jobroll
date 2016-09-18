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

        <h2>Information</h2>
        <div id="InfoDiv">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tfirst" CssClass="col-md-2 control-label">First Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tfirst" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tfirst"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="First Name is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tfirst" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tlast" CssClass="col-md-2 control-label">Last Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tlast" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tfirst"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Last Name is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tlast" CssClass="text-error" />

                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tphone" CssClass="col-md-2 control-label">Phone Number</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tphone" CssClass="form-control" TextMode="Phone" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="tfirst"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="Phone Number is required" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="tphone" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tskills" CssClass="col-md-2 control-label">Skills</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tskills" CssClass="form-control" TextMode="MultiLine" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tsalary" CssClass="col-md-2 control-label">Expected Salary</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tsalary" CssClass="form-control" TextMode="Number" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tlocation" CssClass="col-md-2 control-label">Location</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tlocation" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="EditMember_Click" Text="Update" CssClass="btn btn-default" />
                </div>
            </div>
        </div>

        <h2>Experience</h2>
        <div id="Experience">

            <div id="Addrow">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="teduDegree" CssClass="col-md-2 control-label">Degree</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tedudegree" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="teduschool" CssClass="col-md-2 control-label">School</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="teduschool" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="teducity" CssClass="col-md-2 control-label">City</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="teducity" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="tedustate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tedustate" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="tedustate" CssClass="col-md-2 control-label">Description</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tedudesc" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="AddDegree_Click" Text="Add Degree" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>

            <table class="edu-table">
                <asp:ListView ID="lvDegree" runat="server">
                    <EmptyItemTemplate>
                        <p>
                            No Entries Found
                        </p>
                    </EmptyItemTemplate>

                    <ItemTemplate>
                        <tr>
                            <asp:TextBox runat="server" ID="lvIt_tedudegree" Text='<%# Eval("EduDegree") %>' />
                            <asp:TextBox runat="server" ID="lvIt_teduschool" Text='<%# Eval("EduSchool") %>' />
                            <asp:TextBox runat="server" ID="lvIt_teducity" Text='<%# Eval("EduCity") %>' />
                            <asp:TextBox runat="server" ID="lvIt_tedustate" Text='<%# Eval("EduState") %>' />
                            <asp:TextBox runat="server" ID="lvIt_tedudesc" TextMode="MultiLine" Text='<%# Eval("EduDesc") %>' />
                            <asp:Button runat="server" OnClick="EditEdu_Click" Text="Update" CssClass="btn btn-default" />
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <asp:TextBox runat="server" ID="tedudegree" Text='<%# Bind("EduDegree") %>' />
                            <asp:TextBox runat="server" ID="teduschool" Text='<%# Bind("EduSchool") %>' />
                            <asp:TextBox runat="server" ID="teducity" Text='<%# Bind("EduCity") %>' />
                            <asp:TextBox runat="server" ID="tedustate" Text='<%# Bind("EduState") %>' />
                            <asp:TextBox runat="server" ID="tedudesc" TextMode="MultiLine" Text='<%# Bind("EduDesc") %>' />
                            <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        </tr>

                    </InsertItemTemplate>
                </asp:ListView>
            </table>

        </div>




    </div>


</asp:Content>
