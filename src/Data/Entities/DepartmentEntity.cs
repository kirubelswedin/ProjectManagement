using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class DepartmentEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [MaxLength(500)]
  public string? Description { get; set; }

  public ICollection<EmployeeEntity> Employees { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}