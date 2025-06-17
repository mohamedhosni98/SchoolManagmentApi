using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managment_api.Models;

public class Mark
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Enrollment")]
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; } = null!;

    [Required]
    [Range(0, 100)]
    public decimal ExamMark { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal AssignmentMark { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}