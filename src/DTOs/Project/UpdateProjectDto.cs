using System.ComponentModel.DataAnnotations;

namespace DTOs.Project;

public class UpdateProjectDto
{
  [Required]
  [MaxLength(100)]
  public string ProjectName { get; set; } = null!;

  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = null!;

  [Required]
  public DateTime StartDate { get; set; }

  public DateTime? EndDate { get; set; }

  [Required]
  [Range(0, double.MaxValue)]
  public decimal Budget { get; set; }

  [Required]
  public int StatusId { get; set; }

  [Required]
  public int ClientId { get; set; }

  [Required]
  public int ProjectManagerId { get; set; }

  [Required]
  public int ServiceTypeId { get; set; }
}