using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using managment_api.Models;

namespace managment_api.Data.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.StudentId).IsRequired();
        builder.Property(e => e.ClassId).IsRequired();
        builder.Property(e => e.EnrollmentDate).IsRequired();
        builder.HasOne(e => e.Student)
               .WithMany(s => s.Enrollments)
               .HasForeignKey(e => e.StudentId);
        builder.HasOne(e => e.Class)
               .WithMany(c => c.Enrollments)
               .HasForeignKey(e => e.ClassId);
        builder.ToTable("Enrollments");
    }
}
