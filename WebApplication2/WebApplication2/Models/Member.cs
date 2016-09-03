using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Member
    {
        //Identification
        [Key]
        public int MemberId { get; set; }
        
        public string UserID { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        

        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        //Resume 
        public string Profpic { get; set; }
        public string About { get; set; }
        public string EduDegree  { get; set; }
        public string EduSchool { get; set; }
        public string FieldWork { get; set; }
        public string Skills {get; set;}

        //Experience
        public string XpPosition { get; set; }
        public string XpCompany { get; set; }
        public DateTime XpStart { get; set; }
        public DateTime XpStop { get; set; }

        //Preferences
        public string Location { get; set; }
        public double ExpSalary { get; set; }

    }
}