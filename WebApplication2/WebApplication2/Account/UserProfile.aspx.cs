using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserManager = new UserManager<User>(new UserStore());
            var user = UserManager.FindById(Context.User.Identity.GetUserId());
            if (user.Role)
                Response.Redirect("/Error.aspx");
            
            /*
                    lfirst.Text = jmember.FirstMidName;
                    llast.Text = jmember.LastName;
                    lphone.Text = jmember.PhoneNumber;
                    lemail.Text = User.Identity.GetUserName();
                    lloc.Text = jmember.Location;
        */
        }
    }
}