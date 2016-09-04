<%@ Page Title="Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication2.ProfilePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="leftsidebar">
        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/3/Harry-Potter-1-.jpg"/>
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
        
        <div id="footer">
            <span>Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
                <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
            </span>
        </div>
    </div>

    <div id="maincontent">

        <h2>Skills</h2>
        <div id="sec-skl">
            <ul>
                <li>Business process improvement</li>
                <li>Forecasting and planning</li>
                <li>Advanced Excel modelling</li>
                <li>Cost-benefit analysis</li>
                <li>Business systems analysis</li>
                <li>Budgeting</li>
                <li>Project management</li>
                <li>Project life cycle</li>
                <li>System development life cycle</li>
                <li>IS change management</li>
            </ul>
        </div>
        <hr />

        <h2>Education</h2>
        <div id="sec-edu">
            <table class="edu-tbl">
                <tr>
                    <th>June 2004 - August 2008</th>
                    <td>
                        <div class="edu-head">
                            <span class="sch-pos">Bachelor of Science: Business Management</span>
                            <br />
                            <span class="sch-name">Mapúa Institute of Technology</span> — 
                            <span class="ent-loc">Intramuros, Manila</span>
                        </div>
                        <ul>
                            <li>Emphasis in Business Analytics</li>
                            <li>Top 5% in class.</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th>September 2009 - June 2011</th>
                    <td>
                        <p>
                            <span class="sch-pos">Masters in Business Administration</span>
                            <br />
                            <span class="sch-name">University of California - Bakersfield</span> — 
                            <span class="ent-loc">Bakersfield, CA</span>
                        </p>
                        <ul>
                            <li>Finished Magna Cum Laude.</li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <hr />

        <h2>Experience</h2>
        <div id="sec-exp">
            <table class="exp-tbl">
                <tr>
                    <th>Aug 2011 - Present</th>
                    <td>
                        <p>
                            <span class="ent-pos">Lead Business Analyst</span>
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
            </table>
        </div>
    </div>
</asp:Content>



