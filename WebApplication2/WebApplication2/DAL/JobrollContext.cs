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

        public DbSet<Member> Members { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers")
                                   .Ignore(c => c.PhoneNumber)
                                   .Ignore(c => c.AccessFailedCount)
                                   .Ignore(c => c.LockoutEnabled)
                                   .Ignore(c => c.LockoutEndDateUtc)                                  
                                   .Ignore(c => c.TwoFactorEnabled)
                                   .Ignore(c => c.EmailConfirmed)
                                   .Ignore(c => c.PhoneNumberConfirmed)
                                   ;
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles").HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
        }

        public DbQuery<T> Query<T>() where T : class
        {
            return Set<T>().AsNoTracking();
        }

        public static JobrollContext Create()
        {
            return new JobrollContext();
        }
    }
}