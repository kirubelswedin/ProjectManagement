using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class TimeEntryEntity
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("EmployeeEntity")]
  public int EmployeeId { get; set; }
  public EmployeeEntity Employee { get; set; } = null!;

  [ForeignKey("ServiceTypeEntity")]
  public int ServiceTypeId { get; set; }
  public ServiceTypeEntity ServiceType { get; set; } = null!;

  public DateTime Date { get; set; }

  public decimal Hours { get; set; }

  [MaxLength(500)]
  public string? Description { get; set; }

  public bool IsBilled { get; set; }

  [ForeignKey("InvoiceEntity")]
  public int? InvoiceId { get; set; }
  public InvoiceEntity? Invoice { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}