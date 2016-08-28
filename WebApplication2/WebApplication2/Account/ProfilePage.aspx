<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="WebApplication2.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--title><asp:PlaceHolder ID="Username" runat="server"></asp:PlaceHolder>'s Profile</title-->
    <title>Profile Page</title>
    <style type="text/css">
        body {
            padding-top: 50px;
            padding-bottom: 200px;
            padding-left: 15px;
            padding-right: 15px;
            width:90%;
            margin:0 auto;
        }
        .banner {
            margin: 25px 25px 25px 25px;
        }
        
        #leftsidebar { 
            width: 200px; 
            position: relative; 
            margin: 10px 10px 10px 0px;
        }

        #maincontent{
            float: left;
            width: 78%;
            margin-left: 220px;
        }

        #footer{
            clear: both;
        }

        /* Responsive: Portrait tablets and up */
        @media screen and (min-width: 768px) {
            body {
                margin-top: 20px;
                width: 50%;
            }
        }
    </style>

</head>
<body>
    <form id="Frm_ProfilePage" runat="server">
    <p>
        <img alt="" src="" style="height: 100px; width: 100px" /></p>
    <div id="">
      <div id="banner">
        <h1>AdventureWorks Styling Page</h1>
        <h2>Making CSS Styling Easier in Design View</h2>
        <div id="search">Find:<input id="searchbox" type="text" />
          <input id="searchbutton" type="button" value="Go" />
        </div>
      </div>
    <div id="leftsidebar" class="column">
        <h3>Matters of the Web</h3>
        <p> Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur in sem. Vivamus adipiscing vulputate lacus. Sed enim 
    lorem, fringilla eget, nonummy sed, ullamcorper sit amet, diam. Sed a justo. Curabitur quis nibh sit amet nunc malesuada 
    rutrum.</p>
    </div>    
    <div id="maincontent" class="column">
      <h2>Matters of the Web</h2>
      <p> Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.</p>
      <p>Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.</p>
        <p> Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.</p>
      <p>Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.</p>
        <p> Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.</p>
      <p>Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.</p>
        <p> Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.</p>
      <p>Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.</p>
        <p> Pellentesque mattis tincidunt ipsum. Donec tempus, nunc vitae rhoncus imperdiet, eros turpis accumsan risus, ut luctus ipsum 
    lacus a felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean convallis euismod 
    nulla. Suspendisse potenti. Donec in mi nec odio tincidunt luctus. Donec euismod, mauris cursus molestie convallis, quam 
    pede tempus magna, mollis dapibus quam est et magna. Aenean eros massa, elementum vehicula, dapibus eget, lobortis non, 
    mauris. Vivamus nisl ante, interdum eget, sagittis vel, scelerisque nec, magna. Praesent placerat nibh vel metus viverra 
    tincidunt.</p>
      <p>Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada 
    malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. Curabitur nibh 
    neque, interdum eget, convallis id, adipiscing nec, risus. Suspendisse rutrum dui sed urna. Pellentesque leo felis, tempor eu, 
    convallis venenatis, auctor vitae, justo. In at massa.</p>
    </div>
    <div id="footer">
      <p> Lorem ipsum dolor sit amet, consectetuer adipiscing elit 2007.</p>
    </div>
    </div>

    </form>
</body>
</html>
