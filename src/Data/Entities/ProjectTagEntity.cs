using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectTagEntity
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("TagEntity")]
  public int TagId { get; set; }
  public TagEntity TagEntity { get; set; } = null!;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}