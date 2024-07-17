using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace webtemp_api.Models
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            // 假设 Course 类中有一个名为 CourseID 的属性作为主键
            builder.HasKey(c => c.CourseID);
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired(); // 设置长度 不可为空
        }
    }
}
