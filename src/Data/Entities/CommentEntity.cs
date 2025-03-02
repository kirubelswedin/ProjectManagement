using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CommentEntity
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("EmployeeEntity")]
  public int EmployeeId { get; set; }
  public EmployeeEntity Employee { get; set; } = null!;

  [Required]
  public string Content { get; set; } = null!;

  public DateTime CommentDate { get; set; }

  [ForeignKey("ParentComment")]
  public int? ParentCommentId { get; set; }
  public CommentEntity? ParentComment { get; set; }

  // Navigation property
  public ICollection<CommentEntity> Replies { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}