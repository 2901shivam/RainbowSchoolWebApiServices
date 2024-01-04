using System;
using System.Collections.Generic;

namespace RainbowSchoolWebServiices.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public int? Class { get; set; }
        public int? Subjects { get; set; }

        public virtual Class? ClassNavigation { get; set; }
        public virtual Subject? SubjectsNavigation { get; set; }
    }
}
