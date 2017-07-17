using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}