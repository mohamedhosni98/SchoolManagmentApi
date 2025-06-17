using System.ComponentModel.DataAnnotations;

namespace managment_api.Models;

public class Class
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Teacher { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public List<Enrollment> Enrollments { get; set; } = new();
}