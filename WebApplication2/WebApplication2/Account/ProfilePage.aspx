<%@ Page Title="Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProfilePage.aspx.cs" Inherits="WebApplication2.ProfilePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" href="Content/profile-page.css" rel="stylesheet">

    <div id="leftsidebar">
        <p class="profile-title">
            <img alt="" src="" style="border: none; height: 125px; width: 125px; margin: 20px auto; clear: right;" />
            Shawn Lamod
        </p>
        <ul style="list-style: none; padding: 0; line-height: 150%; word-wrap: break-word; display: inline-block">
            <li><span class="glyphicon glyphicon-earphone"></span><p>+63 912 345 6789</p></li>
            <li ><span class="glyphicon glyphicon-envelope"></span><p>shawn.lamod.blahblahhahahahahahahaha@gmail.com</p></li>
            <li><span class="glyphicon glyphicon-tree-conifer"></span><p>Metro Manila, PH</p></li>
        </ul>

        <%--<div id="sidebarmenu">
            <ul class="userinfo">
                <li><a href="">About Me</a></li>
                <li><a href="">Education</a></li>
                <li><a href="">Skills</a></li>
                <li><a href="">Experience</a></li>
            </ul>
        </div>--%>
        <div id="footer">
            <span>Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
                <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
            </span>
        </div>
    </div>
    <div id="maincontent">
        <div id="profile-banner">

            <h2>Education</h2>
            <div id="sec-edu">
                <table class="school-table">
                    <tr>
                        <th>2008 - 2010</th>
                        <td>
                            <p class="sch-title">Mapua Institute of Technology</p>
                            <p>Lorem ipsum dolor...</p>
                        </td>
                    </tr>
                    <tr>
                        <th>2012 - 2014</th>
                        <td>
                            <p class="sch-title">De La Salle University, Taft</p>
                            <p>Lorem ipsum dolor...</p>
                        </td>
                    </tr>
                </table>
            </div>
            <hr />

            <h2>Skills</h2>
            <div id="sec-skl">
            </div>
            <hr />
        </div>
    </div>
</asp:Content>



