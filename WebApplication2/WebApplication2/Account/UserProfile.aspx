<%@ Page Title="Profile" Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication2.ProfilePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="leftsidebar">
        <asp:Literal Id="lldp" runat="server" />
        <span class="user-name">
            <asp:Label runat="server" Text="James Carlo" Id="lfirst"/>
            <asp:Label runat="server" Text=" " />
            <asp:Label runat="server" Text="Atienza" Id="llast"/>
        </span>

        <ul>
            <li><span class="glyphicon glyphicon-earphone" style="color: gray;"></span><p><asp:Label runat="server" Text="+63 912 345 6789" Id="lphone"/> </p></li>
            <li><span class="glyphicon glyphicon-envelope" style="color: gray;"></span><p><asp:Label runat="server" Text="softeng@jobroll.com" Id="lemail"/></p></li>
            <li><span class="glyphicon glyphicon-tree-conifer" style="color: gray;"></span><p><asp:Label runat="server" Text="Metro Manila, PH" Id="lloc"/></p></li>
        </ul>
        
    </div>

    <div id="maincontent">

        <h2>Skills</h2>
        <div id="sec-skl">            
            <ul>
                <asp:Literal Id="llskill" runat="server" />
            </ul>
        </div>
        <hr />

        <h2>Education</h2>
        <div id="sec-edu">
            <table class="edu-tbl">
                <asp:ListView ID="lvDegree" runat="server"
                    OnItemDatabound="Lvdegree_ItemDatabound">
                    <EmptyDataTemplate>
                        <p> No Entries Found </p>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr>
                            <th>
                                <asp:Label runat="server"  id="ledstart" />
                                <asp:Label runat="server" Text=" - " />
                                <asp:Label runat="server" Text='<%# Eval("EduStop") %>' id="ledstop" />
                            </th>
                            <td>
                                <div class="edu-head">
                                    <span class="sch-pos">
                                        <asp:Label runat="server" Text='<%# Eval("EduDegree") %>' ID="leddegree" /></span>
                                    <br />
                                    <span class="sch-name">
                                        <asp:Label runat="server" Text='<%# Eval("EduSchool") %>' ID="ledschool" /></span>
                                    <asp:Label runat="server" Text=" - " />
                                    <span class="ent-loc">
                                        <asp:Label runat="server" Text='<%# Eval("EduCity") %>' ID="ledcity" /></span>
                                    <asp:Label runat="server" Text=" , " />
                                    <span class="ent-loc">
                                        <asp:Label runat="server" Text='<%# Eval("EduState") %>' ID="ledstate" /></span>
                                </div>
                                <ul>
                                    <asp:Literal ID="lleddesc" runat="server" />
                                </ul>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </table>
        </div>
        <hr />

        <h2>Experience</h2>
        <asp:Label runat="server" Text="No Experience Yet" Visible="false" ID="llnoxp" />
        <div id="sec-exp">
            <table class="exp-tbl">
                <asp:ListView runat="server" ID="lvXp" OnItemDataBound="LvXP_ItemDataBound">
                    <EmptyDataTemplate>
                        <p>No Entries Found </p>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr>
                            <th>
                                <asp:Label runat="server" Text='<%# Eval("XpStart") %>' ID="lxpstart" />
                                <asp:Label runat="server" Text=" - " />
                                <asp:Label runat="server" Text='<%# Eval("XpStop") %>' ID="lxpstop" />
                            </th>
                            <td>
                                <p>
                                    <span class="ent-pos"><asp:Label runat="server" Text='<%# Eval("XpPosition") %>' ID="lxpposition" /></span>
                                    <br />
                                    <span class="ent-name"><asp:Label runat="server" Text='<%# Eval("XpCompany") %>' ID="lxpcompany" /></span>
                                    <asp:Label runat="server" Text=" - " />
                                    <span class="ent-loc">
                                        <asp:Label runat="server" Text='<%# Eval("XpCity") %>' ID="lxpcity" /></span>
                                    <asp:Label runat="server" Text=" , " />
                                    <span class="ent-loc">
                                        <asp:Label runat="server" Text='<%# Eval("XpState") %>' ID="lxpstate" /></span>
                                </p>
                                <ul>
                                    <asp:Literal ID="llxpdesc" runat="server" />
                                </ul>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <!--
                <tr>
                    <th>June 2010 - July 2011</th>
                    <td>
                        <p>
                            <span class="ent-pos">Business Analyst</span>
                            <br />
                            <span class="ent-name">Heritage Hospital</span> — 
                            <span class="ent-loc">Bradford, West Yorkshire</span>
                        </p>
                        <ul>
                            <li>Spearhead supply chain process improvement and systems implementation projects.</li>
                            <li>Develop metrics used to determine inefficiencies and areas of improvement across the hospital.</li>
                            <li>Identify process bottlenecks and implemented new and improved processes and policies.</li>
                            <li>Lead cross-functional teams to analyze and understand the operational impacts and opportunities for technical changes institution-wide. Redirected
                                technology master plan toward a forward-thinking approach.
                            </li>
                            <li>Identified key roadbloakcs and proposed effective solutions for $55 million project that saved the hospital almost 
                                $1 million.
                            </li>
                            <li>Promoted to Lead Analyst after just 11 months of employment.</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>June 2010 - July 2011</th>
                    <td>
                        <p>
                            <span class="ent-pos">Business Analyst</span>
                            <br />
                            <span class="ent-name">Mercy Hospital</span> — 
                            <span class="ent-loc">Salt Lake City, Utah</span>
                        </p>
                        <ul>
                            <li>Performed research to assist in development of project scope, define requirements, and propose changes.</li>
                            <li>Drafted monthly financial reconciliations and forecasts.</li>
                            <li>Assisted senior staff with development of effective presentations.</li>
                            <li>Collected data, analyzed records, and created reports as requested.</li>
                        </ul>
                    </td>
                </tr>
                -->
            </table>
        </div>
    </div>
</asp:Content>



