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
    public partial class Login : Page 
    {

        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

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

        protected async void LogIn(object sender, EventArgs e)
        {
            await DoLogIn();

        }

        protected async Task DoLogIn()
        {
            
            if (IsValid)
            {
                UserManager = new UserManager<User>(new UserStore());
                obj = new IdentityHelper();
                var user = await UserManager.FindAsync(Email.Text, Password.Text);
                if (user != null)
                {
                    
                    await obj.SignInAsync(UserManager, user, RememberMe.Checked);
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