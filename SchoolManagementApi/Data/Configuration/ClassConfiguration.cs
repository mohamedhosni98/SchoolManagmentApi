using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using managment_api.Models;

namespace managment_api.Data.Configurations;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Teacher).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Description).HasMaxLength(500);
        builder.ToTable("Classes");
    }
}