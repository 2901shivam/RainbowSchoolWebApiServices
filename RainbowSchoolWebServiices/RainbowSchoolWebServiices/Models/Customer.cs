using System;
using System.Collections.Generic;

namespace RainbowSchoolWebServiices.Models
{
    public partial class Customer
    {
        public int Cid { get; set; }
        public string Cname { get; set; } = null!;
        public double Odlimit { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
