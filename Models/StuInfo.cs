using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace webtemp_api.Models
{
    public class StuInfo
    {
        [Comment("主键"), Column(Order = 0)]
        public int Stuid { get; set; }
        [Comment("名称")]
        public string Stuname { get; set; }
        [Comment("性别")]
        public string Stusex { get; set; }
        public DateTime EnrollmentDate { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
