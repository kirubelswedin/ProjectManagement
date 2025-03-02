using System.ComponentModel.DataAnnotations;

namespace DTOs.Status;

public class CreateStatusDto
{
  [Required]
  [MaxLength(50)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string Type { get; set; } = null!;

  [Required]
  [MaxLength(200)]
  public string Description { get; set; } = null!;

  [Required]
  public int SortOrder { get; set; }

  [MaxLength(50)]
  public string? Color { get; set; }
}