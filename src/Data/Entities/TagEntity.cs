using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class TagEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string Name { get; set; } = null!;

  [MaxLength(200)]
  public string? Description { get; set; }

  // Navigation property
  public ICollection<ProjectTagEntity> ProjectTags { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}