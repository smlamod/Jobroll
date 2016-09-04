using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class JobrollInitialize : System.Data.Entity.DropCreateDatabaseIfModelChanges<JobrollContext>
    {
        protected override void Seed(JobrollContext context)
        {

            
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("coe125");
            var iuser = new ApplicationUser
                {
                    Id = "User1",
                    Email = "shawn.lamod@gmail.com",
                    UserName = "shawn.lamod@gmail.com",
                    PasswordHash = password,                    
                    IsCompany = false
                };
            manager.Create(iuser);

            password = passwordHash.HashPassword("coe125");
            iuser = new ApplicationUser
            {
                Id = "User2",
                Email = "DieterSchultz@armyspy.com",
                UserName = "DieterSchultz@armyspy.com",
                PasswordHash = password,
                
                IsCompany = false
            };
            manager.Create(iuser);

            password = passwordHash.HashPassword("coe125");
            iuser = new ApplicationUser
            {
                Id = "User3",
                Email = "DeniseAWebster@jourrapide.com",
                UserName = "DeniseAWebster@jourrapide.com",
                PasswordHash = password,
               
                IsCompany = false
            };
            manager.Create(iuser);

            password = passwordHash.HashPassword("coe125");
            iuser = new ApplicationUser
            {
                Id = "User4",
                Email = "EliFRoush@teleworm.us",
                UserName = "EliFRoush@teleworm.us",
                PasswordHash = password,
                
                IsCompany = true,
                
            };
            manager.Create(iuser);
            

            var users = new List<Member>
            {
                new Member{
                    MemberId=3,
                    UserId = "User1",
                    LastName="Lamod",
                    FirstMidName="Shawn",

                    PhoneNumber = "+639062532889",
                    Profpic="",
                    About="Entschudigung sie bitte",
                    EduDegree="Computer Engineering",
                    EduSchool="Mapua Institute of Technology",
                    FieldWork="System Administration",
                    Skills="Bash Scripting, C C# C++ Intel x86 Programming",

                    XpPosition="System Admin",
                    XpCompany="Contoso Ltd",
                    XpStart=DateTime.ParseExact("2017-01-01","yyyy-mm-dd",null),
                    XpStop=DateTime.ParseExact("2018-12-31","yyyy-mm-dd",null),

                    Location="Manila",
                    ExpSalary=30000},               

                new Member{
                    MemberId=1,
                    UserId = "User2",
                    LastName="Schultz",
                    FirstMidName="Dieter",

                    PhoneNumber = "+639062578436",
                    Profpic="",
                    About="Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. ",
                    EduDegree="Computer Science",
                    EduSchool="Mapua Institute Of Technology",
                    FieldWork="Web Development",
                    Skills="HTML Programming, CSS Layouts, MVC Web Apps",

                    XpPosition="Web Developer",
                    XpCompany="Contoso Ltd.",
                    XpStart=DateTime.ParseExact("2012-06-01","yyyy-mm-dd",null),
                    XpStop=DateTime.ParseExact("2014-12-31","yyyy-mm-dd",null),

                    Location="Makati",
                    ExpSalary=25000},

                new Member{
                    MemberId=2,
                    UserId = "User3",
                    LastName="Webster",
                    FirstMidName="Denise",

                     PhoneNumber = "+639062545782",
                    Profpic="",
                    About="about me",
                    EduDegree="Hotel and Room Management",
                    EduSchool="Lyceum of the Philippines University",
                    FieldWork="Restaurant Management",
                    Skills="etc etc",

                    XpPosition="Restaurant Manager",
                    XpCompany="9 Spoons",
                    XpStart=DateTime.ParseExact("2014-01-01","yyyy-mm-dd",null),
                    XpStop=DateTime.ParseExact("2014-06-31","yyyy-mm-dd",null),
                

                    Location="Manila",
                    ExpSalary=20000}}
                    ;

                users.ForEach(s => context.Members.Add(s));
                context.SaveChanges();

                var companies = new List<Company>
                {
                    new Company{
                        CompanyId=1,
                        UserId="User4",
                        
                        PhoneNumber = "+02452789",
                        CompanyName="Contoso Ltd.",
                        CompanyAddr="Bellevue, WA",
                        CompanyDesc="Contoso Ltd. (also known as Contoso and Contoso University) is a fictional company used by Microsoft as an example company and domain.",
                        CompanyLogo=""
                        
                        
                    }
                };

            companies.ForEach(s=> context.Companies.Add(s));
            context.SaveChanges();

                var jobs = new List<Job>
                {
                    new Job{
                        JobId=1,
                        CompanyId=1,
                        JobName = "Data Scientist",
                        JobDesc = "Able to extract information from large sets of data",
                        JobReqt = "Graduate of Applied Mathematics, Computer Science",

                        JobField = "Data Mining",
                        JobLocation = "Bellevue, WA",

                        JobPublished = true,
                        JobStart = DateTime.ParseExact("2016-01-01","yyyy-mm-dd",null),
                        JobEnd = DateTime.ParseExact("2017-01-01","yyyy-mm-dd",null)
                    },

                    new Job{
                        JobId=2,
                        CompanyId =1,
                        JobName = "System Administrator",
                        JobDesc = "Manages and Maintains Production Servers",
                        JobReqt = "Graduate of Computer Engineering, Computer Science",

                        JobField = "System Administration",
                        JobLocation = "Bellevue, WA",

                        JobPublished = true,
                        JobStart = DateTime.ParseExact("2016-01-01","yyyy-mm-dd",null),
                        JobEnd = DateTime.ParseExact("2017-01-01","yyyy-mm-dd",null)
                    }              
                
                };
            jobs.ForEach(s=> context.Jobs.Add(s));
            context.SaveChanges();

            }
        }
    }
