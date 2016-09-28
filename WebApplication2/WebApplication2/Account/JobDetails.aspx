<%@ Page Title="Job Details" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="JobDetails.aspx.cs" Inherits="WebApplication2.Account.JobDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="lvjob" runat="server">
        <EmptyDataTemplate>
            <p>
                No Entries Found
            </p>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="job-details-header">
                <asp:Image runat="server" ImageUrl=<%# Eval("CompLogo") %> />
               <!-- <img src="http://www.myiconfinder.com/uploads/iconsets/256-256-da92ce9f71a953e629f8f49813b77c46-hp.png" /> -->
                <span class="company-open-pos">
                    <asp:Label runat="server" Text='<%# Eval("JobName") %>' ID="ljbname" /></span>
                <ul>
                    <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content">
                        <asp:Label runat="server" Text='<%# Eval("JobExpected") %>' ID="ljbsal" /></span></li>
                    <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content">
                        <asp:Label runat="server" Text='<%# Eval("JobReqt") %>' ID="ljbreqt" />
                    </span></li>
                    <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content">
                        <asp:Label runat="server" Text='<%# Eval("CompAddr") %>' ID="lcploc" /></span></li>
                    <li><span class="glyphicon glyphicon-globe" style="color: gray;"></span><span class="info-content">
                        <a href="/Account/CompanyProfile?uid=<%# Eval("UserId") %>">
                            <asp:Label Text='<%# Eval("CompName") %>' runat="server" /></a> </span></li>
                </ul>
            </div>
            <hr class="custom-hr" />
            <div class="job-desc">
                <div>
                    <h3>Job Description</h3>
                    <p>
                        <asp:Label runat="server" Text='<%# Eval("JobDesc") %>' ID="ljbdesc" />
                    </p>
                </div>
                <div>
                    <h3>Work Location</h3>
                    <p>
                        <asp:Label runat="server" Text='<%# Eval("JobLocation") %>' ID="ljbloc" />
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <div></div>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
