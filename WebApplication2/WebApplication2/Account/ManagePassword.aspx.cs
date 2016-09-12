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
    public partial class ManagePassword : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserManager = new UserManager<User>(new UserStore());
            obj = new IdentityHelper();

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword())
                {
                    setPassword.Visible = false;
                    changePassword.Visible = true;
                }
                else
                {
                    setPassword.Visible = true;
                    changePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");
                }
            }
        }

        protected async void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                IdentityResult result = UserManager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
                if (result.Succeeded)
                {
                    var user = UserManager.FindById(User.Identity.GetUserId());
                    await obj.SignInAsync(UserManager, user, isPersistent: false);
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                IdentityResult result = UserManager.AddPassword(User.Identity.GetUserId(), password.Text);
                if (result.Succeeded)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
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