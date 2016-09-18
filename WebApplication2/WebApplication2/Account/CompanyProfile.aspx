<%@ Page Title="Company Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CompanyProfile.aspx.cs" Inherits="WebApplication2.Account.CompanyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="company-profile-header">
        <img src="http://www.myiconfinder.com/uploads/iconsets/256-256-da92ce9f71a953e629f8f49813b77c46-hp.png"/>
        <span class="company-name"><asp:Label runat="server" Text="Hewlett-Packard Enterprise" Id="lcomp"/> </span>
        <ul>
            <li><span class="glyphicon glyphicon-earphone" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text="+63 912 345 6789" Id="lphone"/> </span></li>
            <li><span class="glyphicon glyphicon-envelope" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text="softeng@jobroll.com" Id="lemail"/></span></li>
            <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><span class="info-content"><asp:Label runat="server" Text="Metro Manila, PH" Id="lloc"/></span></li>
        </ul>
    </div>
    <hr class="custom-hr"/>
    <div class="company-desc">
        <div>
            <h3>Overview</h3>
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text 
                ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
        </div>
        <div>
            <h3>Why join us?</h3>
            <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text 
                ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
        </div>
        <div>
            <h3>Company Snapshot</h3>
            <table>
                <tr>
                    <th>Average application processing time</th>
                    <td>6</td>
                </tr>
                <tr>
                    <th>Industry</th>  
                    <td>Enterprise Products/FMCG</td>
                </tr>
                <tr>
                    <th>Website</th>  
                    <td>http://www.hpe.com</td>
                </tr>
                <tr>
                    <th>Company Size</th>  
                    <td>501 - 1000 </td>
                </tr>        
                <tr>
                    <th>Employees Working Hours</th>  
                    <td>Saturdays or Shift required except for Support Group</td>
                </tr>
                <tr>
                    <th>Dress Code</th>  
                    <td>Business (e.g. Shirts)</td>
                </tr> 
            </table>
        </div>        
    </div>

    
    <div class="job-listing">
        <%--<span class="company-job-listing">Latest Jobs</span>--%>
        <h3>Latest Jobs</h3>
    </div>


    <%--<footer>Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
            <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
    </footer>--%>
    <%--<div class="footer">
        <div class="footer-text">
            Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
            <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
        </div>
    </div>--%>
</asp:Content>