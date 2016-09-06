using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class User : IUser
    {
        public Guid UserId { get; set; }
        public bool Role { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        string IUser<string>.Id
        {
            get { return UserId.ToString(); }
        }



    }
}