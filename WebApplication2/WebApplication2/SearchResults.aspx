<%@ Page Title="Search Results" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchResults.aspx.cs" Inherits="WebApplication2.SearchResults" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Search for Jobs</h4>
        <div class="form-horizontal">

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tjbsearch" CssClass="col-md-2 control-label">Search term</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tjbsearch" class="form-control" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tsalary" CssClass="col-md-2 control-label">Salary Greater Than</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tsalary" CssClass="form-control" TextMode="Number" />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="tlocation" CssClass="col-md-2 control-label">Job Location</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="tlocation" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="Search_click" Text="Search" CssClass="btn btn-default" />
                </div>
            </div>

        </div>
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

