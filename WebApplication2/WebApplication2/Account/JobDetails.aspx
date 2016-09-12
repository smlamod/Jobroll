<%@ Page Title="Job Details" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="JobDetails.aspx.cs" Inherits="WebApplication2.Account.JobDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="job-details-header">
        <img src="https://siva.jsstatic.com/ph/32504/images/sol/32504_logo_0_50430.png" />
        <span class="company-open-pos">Junior Engineer</span>
        <ul>
            <li><span class="glyphicon glyphicon-usd" style="color: gray;"></span><span class="info-content">Above expected salary</span></li>
            <li><span class="glyphicon glyphicon-stats" style="color: gray;"></span><span class="info-content">Min. 1 year (4 years as an Experienced Employee) </span></li>
            <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content">Philippines - National Capital Reg</span></li>
        </ul>
    </div>
    <hr class="custom-hr" />
    <div class="job-desc">
        <div>
            <h3>Job Description</h3>
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text 
                ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
        </div>
        <div>
            <h3>Work Location</h3>
            <p>SM Mall of Asia, Pasay City, Philippines</p>
        </div>    
    </div>
    <div class="footer">
        <div class="footer-text">
            Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
            <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
        </div>
    </div>
</asp:Content>
