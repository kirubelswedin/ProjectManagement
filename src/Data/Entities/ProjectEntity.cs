using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int ProjectNumber { get; set; }

  [Required]
  [MaxLength(100)]
  public string ProjectName { get; set; } = null!;

  [MaxLength(500)]
  public string Description { get; set; } = null!;

  public DateTime StartDate { get; set; }

  public DateTime? EndDate { get; set; }

  public decimal Budget { get; set; }

  [ForeignKey("ClientEntity")]
  public int ClientId { get; set; }
  public ClientEntity Client { get; set; } = null!;

  [ForeignKey("StatusEntity")]
  public int StatusId { get; set; }
  public StatusEntity Status { get; set; } = null!;

  [ForeignKey("EmployeeEntity")]
  public int ProjectManagerId { get; set; }
  public EmployeeEntity ProjectManager { get; set; } = null!;

  [ForeignKey("ServiceTypeEntity")]
  public int ServiceTypeId { get; set; }
  public ServiceTypeEntity ServiceType { get; set; } = null!;

  // Navigation properties
  public ICollection<ProjectEmployeeEntity> ProjectEmployees { get; set; } = [];
  public ICollection<TimeEntryEntity> TimeEntries { get; set; } = [];
  public ICollection<InvoiceEntity> Invoices { get; set; } = [];
  public ICollection<CommentEntity> Comments { get; set; } = [];
  public ICollection<DocumentEntity> Documents { get; set; } = [];
  public ICollection<ProjectTagEntity> ProjectTags { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}