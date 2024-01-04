using System;
using System.Collections.Generic;

namespace RainbowSchoolWebServiices.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Cid { get; set; }
        public string? ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
