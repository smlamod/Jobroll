using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication2.DAL;
using WebApplication2.Models;
using System.Threading.Tasks;

namespace WebApplication2.Account
{
    public partial class ManageLogins : System.Web.UI.Page
    {
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

        protected string SuccessMessage { get; private set; }
        protected bool CanRemoveExternalLogins { get; private set; }

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

            CanRemoveExternalLogins = UserManager.GetLogins(User.Identity.GetUserId()).Count() > 1;

            SuccessMessage = String.Empty;
            successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
        }

        public IEnumerable<UserLoginInfo> GetLogins()
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var accounts = UserManager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1 || HasPassword();
            return accounts;
        }

        public async void RemoveLogin(string loginProvider, string providerKey)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            obj = new IdentityHelper();
            var result = UserManager.RemoveLogin(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            string msg = String.Empty;
            if (result.Succeeded)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                await obj.SignInAsync(UserManager, user, isPersistent: false);
                msg = "?m=RemoveLoginSuccess";
            }
            Response.Redirect("~/Account/ManageLogins" + msg);
        }
    }

}
