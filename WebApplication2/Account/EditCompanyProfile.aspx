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

        <h2>Job Offers</h2>
        <div id="Add Job">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbName" CssClass="col-md-2 control-label">Job Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbName" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbDesc" CssClass="col-md-2 control-label">Job Description:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbDesc" TextMode="MultiLine" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbReqt" CssClass="col-md-2 control-label">Job Requirements:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbReqt" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbLoc" CssClass="col-md-2 control-label">Job Location:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbLoc" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbExp" CssClass="col-md-2 control-label">Expected Salary:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbExp" TextMode="Number" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="cjbPub" CssClass="col-md-2 control-label" Style="padding-top: 0;">Publish ?</asp:Label>
                <div class="col-md-10">
                    <asp:CheckBox runat="server" ID="cjbPub" CssClass="form-inline" />
                </div>
            </div>

                            <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="AddJob_Click" Text="Add Job Listing" CssClass="btn btn-default" />
                    </div>
                </div>


        </div>
        <table class="edu-table" >
            <asp:ListView ID="lvJob" runat="server"  
                OnItemUpdating="LvJob_ItemUpdating"
                OnItemEditing="LvJob_ItemEditing" 
                OnItemCanceling="LvJob_ItemCanceling" 
                OnItemDeleting="LvJob_ItemDelete"        
                
                >
                <EmptyItemTemplate>
                    <p>
                        No Entries Found
                    </p>
                </EmptyItemTemplate>
                <ItemTemplate>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbName" CssClass="col-md-2 control-label">Job Name:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbName" Enabled="false" Text='<%# Eval("JobName") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbDesc" CssClass="col-md-2 control-label">Job Description:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbDesc" Enabled="false" Text='<%# Eval("JobDesc") %>' TextMode="MultiLine" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbReqt" CssClass="col-md-2 control-label">Job Requirements:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbReqt" Enabled="false" Text='<%# Eval("JobReqt") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbLoc" CssClass="col-md-2 control-label">Job Location:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbLoc" Enabled="false" Text='<%# Eval("JobLocation") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbExp" CssClass="col-md-2 control-label">Expected Salary:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbExp" Enabled="false" Text='<%# Eval("JobExpected") %>' TextMode="Number" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="cjbPub" CssClass="col-md-2 control-label" Style="padding-top: 0;">Publish ?</asp:Label>
                        <div class="col-md-10">
                            <asp:CheckBox runat="server" ID="cjbPub" Enabled="false" Checked='<%# Eval("JobPublished") %>' CssClass="form-inline" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btn_edit" CommandName="Edit" Text="Edit" CssClass="btn btn-default" />
                            <asp:Button runat="server" ID="btn_delete" CommandName="Delete" Text="Delete" CssClass="btn btn-default" />
                        </div>
                    </div>

                </ItemTemplate>

                <EditItemTemplate>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbName" CssClass="col-md-2 control-label">Job Name:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbName" Text='<%# Eval("JobName") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbDesc" CssClass="col-md-2 control-label">Job Description:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbDesc" Text='<%# Eval("JobDesc") %>' TextMode="MultiLine" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbReqt" CssClass="col-md-2 control-label">Job Requirements:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbReqt" Text='<%# Eval("JobReqt") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbLoc" CssClass="col-md-2 control-label">Job Location:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbLoc" Text='<%# Eval("JobLocation") %>' CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="tjbExp" CssClass="col-md-2 control-label">Expected Salary:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tjbExp" Text='<%# Eval("JobExpected") %>' TextMode="Number" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="cjbPub" CssClass="col-md-2 control-label" Style="padding-top: 0;">Publish ?</asp:Label>
                        <div class="col-md-10">
                            <asp:CheckBox runat="server" ID="cjbPub" Checked='<%# Eval("JobPublished") %>' CssClass="form-inline" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btn_update" CommandName="Update" Text="Update" CssClass="btn btn-default" />
                            <asp:Button runat="server" ID="btn_cancel" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
                        </div>
                    </div>

                </EditItemTemplate>


            </asp:ListView>
        </table>
    </div>


</asp:Content>
