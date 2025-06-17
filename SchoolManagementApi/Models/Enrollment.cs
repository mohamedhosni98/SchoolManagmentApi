using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managment_api.Models;

public class Enrollment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    [ForeignKey("Class")]
    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    [Required]
    public DateTime EnrollmentDate { get; set; }

    public List<Mark> Marks { get; set; } = new();
}