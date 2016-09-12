using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;
using System.Threading.Tasks;

namespace WebApplication2.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }
   
        

        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        private void RedirectOnFail()
        {
            Response.Redirect((User.Identity.IsAuthenticated) ? "~/Account/Manage" : "~/Account/Login");
        }

        protected async void Page_Load()
        {
            // Process the result from an auth provider in the request
            UserManager = new UserManager<User>(new UserStore());
            obj = new IdentityHelper();
            //ProviderName = IdentityHelper.GetProviderNameFromRequest(Request);

            if (!IsPostBack)
            {
                //var manager = Context.GetOwinContext().GetUserManager<UserManager>();
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    RedirectOnFail();
                    return;
                }

                // Sign in the user with this external login provider if the user already has a login

                var user = await UserManager.FindAsync(loginInfo.Login);
                if (user != null)
                {
                    await obj.SignInAsync(UserManager,user, isPersistent: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    return;
                }
             
            }
        }        
        
        protected async void LogIn_Click(object sender, EventArgs e)
        {
            await CreateAndLoginUser();
        }

        private async Task CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }

            UserManager = new UserManager<User>(new UserStore());
            obj = new IdentityHelper();

            var user = new User() { UserName = email.Text, Email = email.Text, Role = CheckBox1.Checked };
            var result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                result = await UserManager.AddLoginAsync(user.UserId.ToString(), loginInfo.Login);
                if (result.Succeeded)
                {
                    await obj.SignInAsync(UserManager, user, isPersistent: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    await UserManager.DeleteAsync(user);
                    AddErrors(result);
                }
            }
            else
            {
                AddErrors(result);
            }



            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = new ApplicationUser() { UserName = email.Text, Email = email.Text };
            //IdentityResult result = manager.Create(user);
            //if (result.Succeeded)
            //{
            //    var loginInfo = Context.GetOwinContext().Authentication.GetExternalLoginInfo();
            //    if (loginInfo == null)
            //    {
            //        RedirectOnFail();
            //        return;
            //    }
            //    result = manager.AddLogin(user.Id, loginInfo.Login);
            //    if (result.Succeeded)
            //    {
            //        IdentityHelper.SignIn(manager, user, isPersistent: false);

            //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //        // var code = manager.GenerateEmailConfirmationToken(user.Id);
            //        // Send this link via email: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)

            //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //        return;
            //    }
            //}
            //AddErrors(result);
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