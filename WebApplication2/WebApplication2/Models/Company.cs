using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApplication2.Models
{
    public class Company
    {
        //Company Identification
        [Key]
        public int CompanyId { get; set; }

        //public string UserID { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
        //public virtual Common User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
        public string CompanyDesc { get; set; }

        public string CompanyLogo { get; set; }


    }
}