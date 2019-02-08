using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Principal;
using System.Security.Claims;

namespace WebApplication2.Extensions
{
    public class IdentityExtensions
    {
        public static bool GetIsCompany (this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsCompany");
            return (claim != null) ? claim.Value : false;
        }
    }
}