using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using managment_api.Models;

namespace managment_api.Data.Configurations;

public class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.EnrollmentId).IsRequired();
        builder.Property(m => m.ExamMark).IsRequired();
        builder.Property(m => m.AssignmentMark).IsRequired();
        builder.Property(m => m.CreatedAt).IsRequired();
        builder.HasOne(m => m.Enrollment)
               .WithMany(e => e.Marks)
               .HasForeignKey(m => m.EnrollmentId);
        builder.ToTable("Marks");
    }
}