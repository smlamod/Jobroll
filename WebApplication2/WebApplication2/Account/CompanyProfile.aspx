<%@ Page Title="Company Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CompanyProfile.aspx.cs" Inherits="WebApplication2.Account.CompanyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="company-profile-header">
        <asp:Literal Id="lldp" runat="server" />
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
            <p><asp:Label runat="server" Text="<Insert Overview>" Id="lover"/></p>
        </div>
        <div>
            <h3>Why join us?</h3>
            <p><asp:Label runat="server" Text="<Insert Why Join>" Id="ljoin"/></p>
        </div>
        <div>
            <h3>Company Snapshot</h3>
            <table>
                <tr>
                    <th>Average application processing time</th>
                    <td><asp:Label runat="server" Text="Eternity" Id="lpoc"/></td>
                </tr>
                <tr>
                    <th>Industry</th>  
                    <td><asp:Label runat="server" Text="Any" Id="lindustry"/></td>
                </tr>
                <tr>
                    <th>Website</th>  
                    <td><asp:Label runat="server" Text="http://www.hpe.com" Id="lweb"/>  </td>
                </tr>
                <tr>
                    <th>Company Size</th>  
                    <td><asp:Label runat="server" Text="501-1000" Id="lsize"/></td>
                </tr>        
                <tr>
                    <th>Employees Working Hours</th>  
                    <td><asp:Label runat="server" Text="Saturdays or Shift required except for Support Group" Id="lemp"/></td>
                </tr>
                <tr>
                    <th>Dress Code</th>  
                    <td><asp:Label runat="server" Text="Business (e.g. Shirts)" Id="ldress"/></td>
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