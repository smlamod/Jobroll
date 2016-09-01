using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Company
    {
        //Company Identification
        public int CompanyId { get; set; }
        public virtual Common Common { get; set; } 

        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
        public string CompanyDesc { get; set; }

        public string CompanyLogo { get; set; }


    }
}