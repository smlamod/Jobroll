<%@ Page Title="Edit Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditMemberProfile.aspx.cs" Inherits="WebApplication2.Account.EditMemberProfile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Edit your Profile</h4>
        <h4>
            <asp:Label ID="lmsg" runat="server" />
        </h4>
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
                <asp:Label runat="server" AssociatedControlID="tlocation" CssClass="col-md-2 control-label">Picture</asp:Label>
                <div class="col-md-2">
                    <asp:FileUpload ID="fupload" runat="server" />                 
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="EditMember_Click" Text="Update" CssClass="btn btn-default" />
                </div>
            </div>
        </div>

        <h2>Education</h2>
        <div id="Education">
            <div id="Degree Addrow">

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="teduStart" CssClass="col-md-2 control-label">Enrollment Date:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="teduStart" TextMode="Date" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="teduStop" CssClass="col-md-2 control-label">Graduation Date:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="teduStop" TextMode="Date" CssClass="form-control" />
                    </div>
                </div>

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
                <asp:ListView ID="lvDegree" runat="server" OnItemCanceling="Lvdegree_ItemCanceling"
                    OnItemDeleting="Lvdegree_ItemDelete"
                    OnItemDataBound="Lvdegree_ItemDatabound"
                    OnItemEditing="Lvdegree_ItemEditing"
                    OnItemUpdating="Lvdegree_ItemUpdating">
                    <EmptyDataTemplate>
                        <p>
                            No Entries Found
                        </p>
                    </EmptyDataTemplate>

                    <ItemTemplate>
                        <tr>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduStart" CssClass="col-md-2 control-label">Enrollment Date:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduStart" Text='<%# Eval("EduStart") %>' TextMode="Date" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduStop" CssClass="col-md-2 control-label">Graduation Date:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduStop" Text='<%# Eval("EduStop") %>' TextMode="Date" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduDegree" CssClass="col-md-2 control-label">Degree</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedudegree" Text='<%# Eval("EduDegree") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduschool" CssClass="col-md-2 control-label">School</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduschool" Text='<%# Eval("EduSchool") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teducity" CssClass="col-md-2 control-label">City</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teducity" Text='<%# Eval("EduCity") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="tedustate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedustate" Text='<%# Eval("EduState") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="tedudesc" CssClass="col-md-2 control-label">Description</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedudesc" Text='<%# Eval("EduDesc") %>' TextMode="MultiLine" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btn_edit" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                                    <asp:Button runat="server" ID="btn_delete" CommandName="Delete" Text="Delete" CssClass="btn btn-default" />
                                </div>
                            </div>

                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduStart" CssClass="col-md-2 control-label">Enrollment Date:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduStart" Text='<%# Eval("EduStart") %>' TextMode="Date" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduStop" CssClass="col-md-2 control-label">Graduation Date:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduStop" Text='<%# Eval("EduStop") %>' TextMode="Date" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduDegree" CssClass="col-md-2 control-label">Degree</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedudegree" Text='<%# Eval("EduDegree") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teduschool" CssClass="col-md-2 control-label">School</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teduschool" Text='<%# Eval("EduSchool") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="teducity" CssClass="col-md-2 control-label">City</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="teducity" Text='<%# Eval("EduCity") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="tedustate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedustate" Text='<%# Eval("EduState") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="tedustate" CssClass="col-md-2 control-label">Description</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="tedudesc" Text='<%# Eval("EduDesc") %>' TextMode="MultiLine" CssClass="form-control" />
                                </div>
                            </div>



                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btn_update" CommandName="Update" Text="Update" CssClass="btn btn-default" />
                                    <asp:Button runat="server" ID="btn_cancel" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </table>
        </div>

        <h2>Experience</h2>
        <div id="Experience">
            <div id="XP Addrow">

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpStart" CssClass="col-md-2 control-label">Start of Employment:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpStart" TextMode="Date" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpStop" CssClass="col-md-2 control-label">End of Employment:</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpStop" TextMode="Date" CssClass="form-control" />

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpPosition" CssClass="col-md-2 control-label">Position</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpPosition" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpCompany" CssClass="col-md-2 control-label">Company</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpCompany" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpcity" CssClass="col-md-2 control-label">City</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpcity" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpstate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpstate" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txpdesc" CssClass="col-md-2 control-label">Description</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txpdesc" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="AddExperience_Click" Text="Add Experience" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
            <table class="edu-table">
                <asp:ListView ID="lvXp" runat="server" 
                    OnItemDataBound="LvXP_ItemDataBound" 
                    OnItemEditing="LvXP_ItemEditing" 
                    OnItemUpdating="LvXP_ItemUpdating" 
                    OnItemCanceling="LvXp_ItemCanceling" 
                    OnItemDeleting="LvXp_ItemDelete" >
                    <EmptyDataTemplate>
                        <p>
                            No Entries Found
                        </p>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpStart" CssClass="col-md-2 control-label">Start of Employment:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpStart" Text='<%# Eval("XpStart") %>' TextMode="Date" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpStop" CssClass="col-md-2 control-label">End of Employment:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpStop" Text='<%# Eval("XpStop") %>' TextMode="Date" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpPosition" CssClass="col-md-2 control-label">Position</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpPosition" Text='<%# Eval("XpPosition") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpCompany" CssClass="col-md-2 control-label">Company</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpCompany" Text='<%# Eval("XpCompany") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpcity" CssClass="col-md-2 control-label">City</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpcity" Text='<%# Eval("XpCity") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpstate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpstate" Text='<%# Eval("XpState") %>' Enabled="false" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpdesc" CssClass="col-md-2 control-label">Description</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpdesc" Text='<%# Eval("XpDesc") %>' TextMode="MultiLine" Enabled="false" CssClass="form-control" />
                                </div>
                            </div>


                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btn_edit" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                                    <asp:Button runat="server" ID="btn_delete" CommandName="Delete" Text="Delete" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpStart" CssClass="col-md-2 control-label">Start of Employment:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpStart" Text='<%# Eval("XpStart") %>' TextMode="Date" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpStop" CssClass="col-md-2 control-label">End of Employment:</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpStop" Text='<%# Eval("XpStop") %>' TextMode="Date" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpPosition" CssClass="col-md-2 control-label">Position</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpPosition" Text='<%# Eval("XpPosition") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpCompany" CssClass="col-md-2 control-label">Company</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpCompany" Text='<%# Eval("XpCompany") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpcity" CssClass="col-md-2 control-label">City</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpcity" Text='<%# Eval("XpCity") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpstate" CssClass="col-md-2 control-label">State or Region</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpstate" Text='<%# Eval("XpState") %>' CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txpdesc" CssClass="col-md-2 control-label">Description</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txpdesc" Text='<%# Eval("XpDesc") %>' TextMode="MultiLine" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btn_update" CommandName="Update" Text="Update" CssClass="btn btn-default" />
                                    <asp:Button runat="server" ID="btn_cancel" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </table>
        </div>



    </div>


</asp:Content>
