using System;
using System.Collections.Generic;

namespace RainbowSchoolWebServiices.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Students = new HashSet<Student>();
        }

        public int SubId { get; set; }
        public int? SubjectMarks { get; set; }
        public string? SubjectName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
