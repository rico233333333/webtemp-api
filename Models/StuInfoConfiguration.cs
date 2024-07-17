using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace webtemp_api.Models
{
    public class StuInfoConfiguration : IEntityTypeConfiguration<StuInfo>
    {
        public void Configure(EntityTypeBuilder<StuInfo> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(s => s.Stuid); // 假设 StuInfo 类中有一个名为 Stuid 的属性作为主键
                                          // 其他配置...
        }
    }
}
