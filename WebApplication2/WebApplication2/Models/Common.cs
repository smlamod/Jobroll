﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication2.Models
{
    public class Common : IdentityUser
    {
        //Common Attributes

        public virtual Member Member { get; set; }
        public virtual Company Company { get; set; }
    }
}