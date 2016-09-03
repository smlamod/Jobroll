using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication2.Models
{
    public class Job
    {
        //Job Atributes
        [Key]
        public int JobId { get; set; }
        
        public int CompanyId { get; set; }
        public virtual Company  Company { get; set; }

        public string JobName { get; set; }
        public string JobDesc { get; set; }
        public string JobReqt { get; set; }
        
        public string JobField { get; set; }

        public string JobLocation { get; set; }
        public double JobExpected { get; set; }

        //Job Management
        public bool JobPublished { get; set; }
        public DateTime JobStart { get; set; }
        public DateTime JobEnd { get; set; }

    }
}