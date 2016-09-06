using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WebApplication2.Models
{
    public class JBUser : IUser
    {
        public int      Id { get; set; }
        public bool     Role { get; set; }
        public string   Email { get; set; }
        public string   PasswordHash { get; set; }
        public string   SecurityStamp {get; set;}

        string IUser.Id
        {
            get { return Id.ToString()};
        }
     }
}