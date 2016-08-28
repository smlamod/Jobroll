<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="WebApplication2.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--title><asp:PlaceHolder ID="Username" runat="server"></asp:PlaceHolder>'s Profile</title-->
    <title>JobRoll Profile Page</title>
    <style type="text/css">
        body {
            padding-top: 50px;
            padding-bottom: 200px;
            padding-left: 15px;
            padding-right: 15px;
            width: 60%;
            margin: 0 auto;
            font-family: sans-serif;
        }

        #leftsidebar {
            float: left;
            position: fixed;
            width: 230px;
        }

        #username{
            padding: 10px 0;            
        }

        #footer{
            margin-top: 125%;
            font-size: 0.75em;
        }

        .userinfo {
            list-style: none;
            padding: 0;
        }

        .userinfo li {
            margin: 10px 0;
        }

        .userinfo li a {
            text-decoration: none;
        }

        #profilepic {
            border: 0;
        }

        #maincontent {
            width: 78%;
            margin-left: 240px;
        }
        

        /* Responsive: Portrait tablets and up */
        @media screen and (min-width: 768px) {
            body {
                margin-top: 20px;
                width: 70%;
            }

            #userimage {
                width: 51px;
            }
        }
    </style>

</head>
<body>
    <form id="Frm_ProfilePage" runat="server">
        <div id="leftsidebar">
            <img alt="" src="" style="height: 100px; width: 100px; padding-right: 5px" />
            <div id="username">
                <b>[Some user's name]</b>
            </div>
            <div id="sidebarmenu">
                <ul class="userinfo">
                    <li><a href="">About Me</a></li>
                    <li><a href="">Education</a></li>
                    <li><a href="">Skills</a></li>
                    <li><a href="">Experience</a></li>
                </ul>
            </div>            
            <div id="footer">
                <p>Copyright (C) 2016. All rights reserved.</p>
            </div>
        </div>
        <div id="maincontent" class="column">
            <div id="banner">
                <h1>AdventureWorks Styling Page</h1>
                <h2>Making CSS Styling Easier in Design View</h2>
            </div>

            <p>
                Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.
            </p>
            <p>
                Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.
            </p>
            <p>
                Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.
            </p>
            <p>
                Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.
            </p>
            <p>
                Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.
            </p>
            <p>
                Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.
            </p>
            <p>
                Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.
            </p>
            <p>
                Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.
            </p>
            <p>
                Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.
            </p>
            <p>
                Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.
            </p>
        </div>

    </form>
</body>
</html>
