namespace webtemp_api.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StuInfoID { get; set; }
        public int? Grade { get; set; }  // 在前面加？表示可空

        public Course Course { get; set; }
        public StuInfo StuInfo { get; set; }
    }

}
