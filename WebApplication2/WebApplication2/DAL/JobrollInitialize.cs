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
            var users = new List<Member>
            {
                new Member{
                    LastName="Schultz",
                    FirstMidName="Dieter",

                    Profpic="",
                    About="Fusce magna urna, gravida non, sodales vehicula, consequat ac, lacus. Ut sed eros sit amet neque malesuada malesuada. Fusce porttitor cursus eros. Maecenas libero odio, convallis vel, tristique id, sodales vel, leo. ",
                    EduDegree="Computer Science",
                    EduSchool="Mapua Institute Of Technology",
                    FieldWork="Web Development",
                    Skills="HTML Programming, CSS Layouts, MVC Web Apps",

                    XpPosition="Web Developer",
                    XpCompany="Contoso Ltd.",
                    XpStart=DateTime.Parse("2012-06-01"),
                    XpStop=DateTime.Parse("2014-12-31"),

                    Location="Makati",
                    ExpSalary=25000},

                new Member{
                    LastName="Webster",
                    FirstMidName="Denise",

                    Profpic="",
                    About="about me",
                    EduDegree="Hotel and Room Management",
                    EduSchool="Lyceum of the Philippines University",
                    FieldWork="Restaurant Management",
                    Skills="etc etc",

                    XpPosition="Restaurant Manager",
                    XpCompany="9 Spoons",
                    XpStart=DateTime.Parse("2014-01-01"),
                    XpStop=DateTime.Parse("2014-06-31"),
                

                    Location="Manila",
                    ExpSalary=20000},

                new Member{
                    LastName="Lamod",
                    FirstMidName="Shawn",

                    Profpic="",
                    About="Entschudigung sie bitte",
                    EduDegree="Computer Engineering",
                    EduSchool="Mapua Institute of Technology",
                    FieldWork="System Administration",
                    Skills="Bash Scripting, C C# C++ Intel x86 Programming",

                    XpPosition="System Admin",
                    XpCompany="Contoso Ltd",
                    XpStart=DateTime.Parse("2017-01-01"),
                    XpStop=DateTime.Parse("2018-12-31"),

                    Location="Manila",
                    ExpSalary=30000},
                };

                users.ForEach(s => context.Users.Add(s));
                context.SaveChanges();

                var companies = new List<Company>
                {
                    new Company{
                        CompanyId=1,

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
                        CompanyId=1,
                        JobName = "Data Scientist",
                        JobDesc = "Able to extract information from large sets of data",
                        JobReqt = "Graduate of Applied Mathematics, Computer Science",

                        JobField = "Data Mining",
                        JobLocation = "Bellevue, WA",

                        JobPublished = true,
                        JobStart = DateTime.Parse("2016-01-01"),
                        JobEnd = DateTime.Parse("207-01-01")
                    },

                    new Job{
                        CompanyId =1,
                        JobName = "System Administrator",
                        JobDesc = "Manages and Maintains Production Servers",
                        JobReqt = "Graduate of Computer Engineering, Computer Science",

                        JobField = "System Administration",
                        JobLocation = "Bellevue, WA",

                        JobPublished = true,
                        JobStart = DateTime.Parse("2016-01-01"),
                        JobEnd = DateTime.Parse("207-01-01")
                    }              
                
                };
            jobs.ForEach(s=> context.Jobs.Add(s));
            context.SaveChanges();

            }
        }
    }
