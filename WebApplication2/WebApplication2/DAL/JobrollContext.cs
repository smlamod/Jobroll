﻿using WebApplication2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication2.DAL
{
    public class JobrollContext : DbContext
    {

        public JobrollContext() : base("JBConnection")
        {

        }

       // public DbSet<Common> Commons { get; set; }
        public DbSet<Member> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().Ignore(c => c.AccessFailedCount)
                                   .Ignore(c => c.LockoutEnabled)
                                   .Ignore(c => c.LockoutEndDateUtc)                                  
                                   .Ignore(c => c.TwoFactorEnabled)
                                   .Ignore(c => c.EmailConfirmed)
                                   .Ignore(c => c.PhoneNumberConfirmed)
                                   ;

        }

    }
}