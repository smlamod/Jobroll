namespace WebApplication2.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("coe125");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    Email = "shawn.lamod@gmail.com",
                    UserName = "shawn.lamod@gmail.com",
                    PasswordHash = password,
                    PhoneNumber = "+639062532889",
                    IsCompany = false

                });

            password = passwordHash.HashPassword("coe125");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    Email = "DieterSchultz@armyspy.com",
                    UserName = "DieterSchultz@armyspy.com",
                    PasswordHash = password,
                    PhoneNumber = "+639062578436",
                    IsCompany = false

                });

            password = passwordHash.HashPassword("coe125");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    Email = "DeniseAWebster@jourrapide.com",
                    UserName = "DeniseAWebster@jourrapide.com",
                    PasswordHash = password,
                    PhoneNumber = "+639062545782",
                    IsCompany = false

                });

            password = passwordHash.HashPassword("coe125");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    Email = "EliFRoush@teleworm.us",
                    UserName = "EliFRoush@teleworm.us",
                    PasswordHash = password,
                    PhoneNumber = "+02452789",
                    IsCompany = true

                });

         
             
             
        }
    }
}
