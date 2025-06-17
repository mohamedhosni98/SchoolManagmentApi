using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using managment_api.Models;

namespace managment_api.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Age).IsRequired();
        builder.ToTable("Students");
    }
}
