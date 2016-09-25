<%@ Page Title="Search Results" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchResults.aspx.cs" Inherits="WebApplication2.SearchResults" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="lvJobr" runat="server">
        <EmptyDataTemplate>
            <p>
                No Entries Found
            </p>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="search-result">
                    <h3><a href="/Account/JobDetails?id=<%# Eval("JobId") %>"> <asp:Label runat="server" Text='<%# Eval("JobName") %>' id="ljbname" /> </a> </h3>
                    <p><a href="/Account/CompanyProfile?uid=<%# Eval("UserId") %>"><asp:Label runat="server" Text='<%# Eval("CompName") %>' id="ljbcname" /> </a> </p>
                    <ul>
                        <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text='<%# Eval("JobExpected") %>' id="ljbsal" /></span></li>
                        <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text='<%# Eval("JobReqt") %>' id="ljbreqt" /> </span></li>
                        <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text='<%# Eval("JobLocation") %>' id="ljbloc" /></span></li>
                    </ul>
                    <div class="short-job-desc"><asp:Label runat="server" Text='<%# Eval("JobDesc") %>' id="ljbdesc" /></div>
                    <div class="clearfix" style="clear: both;"></div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <!--
    <div class="search-result">
        <a href="">
            <h3>Marketing Officer</h3>
            <p class="ent-name">Power Mac Center, Inc.</p>
            <ul>
                <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content">Above expected salary</span></li>
                <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content">Min. 1 year (4 years as an Experienced Employee) </span></li>
                <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content">Philippines - National Capital Reg</span></li>
            </ul>
            <div class="short-job-desc">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. </div>
            <div class="clearfix" style="clear: both;"></div>
        </a>
    </div>
    <div class="search-result">
        <a href="">
            <h3>Marketing Officer</h3>
            <p class="ent-name">Power Mac Center, Inc.</p>
            <ul>
                <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content">Above expected salary</span></li>
                <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content">Min. 1 year (4 years as an Experienced Employee) </span></li>
                <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content">Philippines - National Capital Reg</span></li>
            </ul>
            <div class="short-job-desc">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. </div>
            <div class="clearfix" style="clear: both;"></div>
        </a>
    </div>
    -->
</asp:Content>

