using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ServiceTypeEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [MaxLength(500)]
  public string Description { get; set; } = null!;

  public decimal DefaultHourlyRate { get; set; }

  // Navigation properties
  public ICollection<TimeEntryEntity> TimeEntries { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}