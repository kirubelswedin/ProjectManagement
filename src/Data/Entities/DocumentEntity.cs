using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class DocumentEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(255)]
  public string FileName { get; set; } = null!;

  [Required]
  public string FilePath { get; set; } = null!;

  [MaxLength(100)]
  public string FileType { get; set; } = null!;

  public long FileSize { get; set; }

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("EmployeeEntity")]
  public int EmployeeId { get; set; }
  public EmployeeEntity Employee { get; set; } = null!;

  [MaxLength(500)]
  public string? Description { get; set; }

  public DateTime UploadDate { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}