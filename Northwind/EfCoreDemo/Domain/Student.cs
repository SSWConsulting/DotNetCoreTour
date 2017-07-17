using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreDemo.Domain
{
    public class Student
    {

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}