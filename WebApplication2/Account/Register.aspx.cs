﻿using Owin;
using System;
using System.Linq;
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
    public partial class Register : Page
    {
        public UserManager<User> UserManager { get; private set; }
        public IdentityHelper obj { get; set; }

        protected async void CreateUser_Click(object sender, EventArgs e)
        {
            await Do_Create();        
        }

        protected async Task Do_Create()
        {
            UserManager = new UserManager<User>(new UserStore());
            obj = new IdentityHelper();

            var user = new User() { UserName = Email.Text, Email = Email.Text , Role = CheckBox1.Checked};
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