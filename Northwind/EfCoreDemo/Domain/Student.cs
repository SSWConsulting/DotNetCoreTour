using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreDemo.Domain
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Firstname { get; set; }

        [MaxLength(30)]
        public string Lastname { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}