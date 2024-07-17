using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace webtemp_api.Models
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");
            // 配置外键
            builder.HasOne(e => e.StuInfo).WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StuInfoID); // 导航属性和外键配置
            builder.HasOne(e => e.Course).WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.CourseID);
        }
    }
}
