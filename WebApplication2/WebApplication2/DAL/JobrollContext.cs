using WebApplication2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity.Infrastructure;

namespace WebApplication2.DAL
{
    public class JobrollContext : DbContext
    {

        public JobrollContext() : base("JBConnection")
        {
            Database.SetInitializer<JobrollContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;


        }

       // public DbSet<Common> Commons { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            modelBuilder.Entity<IdentityUser>().Ignore(c => c.AccessFailedCount)
                                   .Ignore(c => c.LockoutEnabled)
                                   .Ignore(c => c.LockoutEndDateUtc)                                  
                                   .Ignore(c => c.TwoFactorEnabled)
                                   .Ignore(c => c.EmailConfirmed)
                                   .Ignore(c => c.PhoneNumberConfirmed)
                                   ;

          //  modelBuilder.Entity<Member>().ToTable("Members");
          //  modelBuilder.Entity<Company>().ToTable("Companies");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            */
        }

        public DbQuery<T> Query<T>() where T : class
        {
            return Set<T>().AsNoTracking();
        }

    }
}