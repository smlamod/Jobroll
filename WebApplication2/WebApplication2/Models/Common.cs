using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Common
    {
        //Common Attributes
        [Key]
        public string ID { get; set; }
        

        public bool Membertype { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

  
    }
}