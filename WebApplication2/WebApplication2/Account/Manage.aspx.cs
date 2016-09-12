using Owin;
using System;
using System.Web;
using System.Web.UI;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication2.Models;
using WebApplication2.DAL;



namespace WebApplication2.Account
{
    public partial class Manage : System.Web.UI.Page
    {

        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
          //  var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

         
    }
}