using System;
using System.Collections.Generic;
using System.Text;
using EfCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Config
{
    public class PurchaseRequestItemConfig : EntityMappingConfiguration<Enrollment>
    {
        public override void Map(EntityTypeBuilder<Enrollment> b)
        {
            b.HasKey(e => e.Id);

            b.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            b.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

        }

    }
}
