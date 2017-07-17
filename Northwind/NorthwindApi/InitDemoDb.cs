using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo;
using EfCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace NorthwindTraders.NorthwindApi
{
    public class InitDemoDb
    {

        public static void Init(DemoDbContext dbCtx)
        {
            dbCtx.Database.EnsureDeleted();
            dbCtx.Database.Migrate();

            dbCtx.Students.AddRange(new List<Student>
            {
                new Student()
                {
                    Firstname = "Brendan",
                    Lastname = "Richards",
                },
                new Student()
                {
                    Firstname = "Jason",
                    Lastname = "Taylor",
                },
                new Student()
                {
                    Firstname = "Adam",
                    Lastname = "Cogan",
                },
                new Student()
                {
                    Firstname = "Adam",
                    Lastname = "Stephensen",
                },
                new Student()
                {
                    Firstname = "Duncan",
                    Lastname = "Hunter",
                },
                new Student()
                {
                    Firstname = "Thiago",
                    Lastname = "Passos",
                },
            });

            dbCtx.Courses.AddRange(new List<Course>
            {
                new Course()
                {
                    Name = ".NET Core Superpowers"
                },
                new Course()
                {
                    Name = "Angular Superpowers"
                },
                new Course()
                {
                    Name = "Azure Superpowers"
                },
            });
            dbCtx.SaveChanges();

            dbCtx.Enrollments.AddRange(new List<Enrollment>()
            {
                new Enrollment()
                {
                    Course = dbCtx.Courses.FirstOrDefault(c => c.Name == ".NET Core Superpowers"),
                    Student = dbCtx.Students.FirstOrDefault(c => c.Lastname == "Richards")
                },
                new Enrollment()
                {
                    Course = dbCtx.Courses.FirstOrDefault(c => c.Name == ".NET Core Superpowers"),
                    Student = dbCtx.Students.FirstOrDefault(c => c.Lastname == "Taylor")
                }
            });
            dbCtx.SaveChanges();
        }

    }
}
