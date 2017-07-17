using System;
using System.Collections.Generic;
using System.Reflection;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add fluent config here
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Name)
                .HasMaxLength(50);

            // or scan for fluent config classes
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
        }

    }
}
