using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEmployeeEntity
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("EmployeeEntity")]
  public int EmployeeId { get; set; }
  public EmployeeEntity Employee { get; set; } = null!;

  public DateTime AssignmentStart { get; set; }
  public DateTime? AssignmentEnd { get; set; }

  // for customization
  public decimal? CustomHourlyRate { get; set; }

  [MaxLength(200)]
  public string? Role { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}