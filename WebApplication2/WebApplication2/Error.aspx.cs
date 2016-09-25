using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
           
            
            switch (int.Parse(id))
            {
                case 404:
                    lmsg.Text = "Not Found";
                    break;
                case 503:
                    lmsg.Text = "Forbidden";
                    break;
                case 2:
                    lmsg.Text = "The user is in not in the correct role";
                    break;
                case 3:
                    lmsg.Text = "The user has no information to display";
                    break;
                default:
                    lmsg.Text = "An Error has occured";
                    break;
            }
        }
    }
}