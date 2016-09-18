using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Models;
using WebApplication2.DAL;
using Microsoft.AspNet.Identity;

namespace WebApplication2.Account
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                UserManager = new UserManager<User>(new UserStore());
                var user = UserManager.FindById(Context.User.Identity.GetUserId());
                if (!user.Role)
                    Response.Redirect("/Error.aspx");


            }
            else
                Response.Redirect("/Error.aspx");
                
        }
    }
}