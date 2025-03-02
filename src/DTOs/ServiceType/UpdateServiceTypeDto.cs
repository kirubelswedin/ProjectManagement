using System.ComponentModel.DataAnnotations;

namespace DTOs.ServiceType;

public class UpdateServiceTypeDto
{
  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = null!;

  [Required]
  [Range(0, double.MaxValue)]
  public decimal DefaultHourlyRate { get; set; }
}