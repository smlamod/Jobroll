using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;

namespace WebApplication2
{
    public partial class ProfilePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                string usrid = User.Identity.GetUserId();
                using (var context = new JobrollContext())
                {
                    var jmember = context.Members.First(a => a.UserId == usrid);
                    lfirst.Text = jmember.FirstMidName;
                    llast.Text = jmember.LastName;
                    lphone.Text = jmember.PhoneNumber;
                    lemail.Text = User.Identity.GetUserName();
                    lloc.Text = jmember.Location;

                }            
        }
    }
}