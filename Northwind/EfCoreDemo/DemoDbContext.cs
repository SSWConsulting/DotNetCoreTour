using System;
using System.Collections.Generic;
using System.Text;
using EfCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
    public class DemoDbContext: DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        { }


        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }


    }
}
