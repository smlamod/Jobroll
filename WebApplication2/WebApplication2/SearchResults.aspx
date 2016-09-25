<%@ Page Title="Search Results" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchResults.aspx.cs" Inherits="WebApplication2.SearchResults" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Search for Jobs</h4>
        <div class="form-class">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tjbsearch" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tjbsearch"
                    Display="Dynamic" CssClass="text-danger" ErrorMessage="Search Term Required" />
                <asp:ModelErrorMessage runat="server" ModelStateKey="tjbsearch" CssClass="text-error" />
                <asp:Button runat="server" OnClick="Search_click" Text="Search" CssClass="btn btn-default" />
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <asp:ListView ID="lvJobr" runat="server">
            <EmptyDataTemplate>
                <p>
                    No Entries Found
                </p>
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="search-result">
                    <h3><a href="/Account/JobDetails?id=<%# Eval("JobId") %>">
                        <asp:Label runat="server" Text='<%# Eval("JobName") %>' ID="ljbname" />
                    </a></h3>
                    <p>
                        <a href="/Account/CompanyProfile?uid=<%# Eval("UserId") %>">
                            <asp:Label runat="server" Text='<%# Eval("CompName") %>' ID="ljbcname" />
                        </a>
                    </p>
                    <ul>
                        <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content">
                            <asp:Label runat="server" Text='<%# Eval("JobExpected") %>' ID="ljbsal" /></span></li>
                        <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content">
                            <asp:Label runat="server" Text='<%# Eval("JobReqt") %>' ID="ljbreqt" />
                        </span></li>
                        <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content">
                            <asp:Label runat="server" Text='<%# Eval("JobLocation") %>' ID="ljbloc" /></span></li>
                    </ul>
                    <div class="short-job-desc">
                        <asp:Label runat="server" Text='<%# Eval("JobDesc") %>' ID="ljbdesc" />
                    </div>
                    <div class="clearfix" style="clear: both;"></div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <br />
    </div>

</asp:Content>

