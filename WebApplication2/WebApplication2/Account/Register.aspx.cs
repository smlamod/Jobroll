using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication2.Models;

namespace WebApplication2.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
          
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new JBUser() { Email = Email.Text, Role = CheckBox1.Checked };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
             
                /*
                if (CheckBox1.Checked)
                {
                    manager.AddToRole(user.Id, "company");
                }
                else
                {
                    manager.AddToRole(user.Id, "member");
                }
                 */

               // IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
             
        }
    }
}