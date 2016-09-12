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
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

        protected string SuccessMessage
        {
            get;
            private set;
        }

        public int LoginsCount { get; set; }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }


        protected void Page_Load()
        {
            UserManager = new UserManager<User>(new UserStore());
            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword())
                
                {
                    CreatePassword.Visible = false;
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
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