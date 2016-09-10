using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplication2.Models;
using WebApplication2.DAL;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace WebApplication2.Account
{
    public partial class Login : Page 
    {

        public UserManager<User> UserManager { get; private set; }

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            IAuthenticationManager AuthenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            DoLogIn();

        }

        protected async Task DoLogIn()
        {

            if (IsValid)
            {

                var user = await UserManager.FindAsync(Email.Text, Password.Text);
                if (user != null)
                {
                    
                   await SignInAsync(user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }

            }
        }
    }
}