using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Domain
{
    public class Enrollment
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
