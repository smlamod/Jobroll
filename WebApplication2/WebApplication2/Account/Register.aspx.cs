using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Threading.Tasks;

namespace WebApplication2.Account
{
    public partial class Register : Page
    {
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

        protected async void CreateUser_Click(object sender, EventArgs e)
        {

            await Do_Create();

            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, IsCompany = CheckBox1.Checked };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{

            //    if (CheckBox1.Checked)
            //    {
            //        manager.AddToRole(user.Id, "company");
            //    }
            //    else
            //    {
            //        manager.AddToRole(user.Id, "member");
            //    }
            //    IdentityHelper.SignIn(manager, user, isPersistent: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
             
        }

        protected async Task Do_Create()
        {
            UserManager = new UserManager<User>(new UserStore());
            obj = new IdentityHelper();

            var user = new User() { UserName = Email.Text, Email = Email.Text};
            var result = await UserManager.CreateAsync(user, Password.Text);
            if (result.Succeeded)
            {
                await obj.SignInAsync(UserManager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}