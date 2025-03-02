using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string Name { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string Type { get; set; } = null!; // ex. Project, Invoice

  [MaxLength(200)]
  public string Description { get; set; } = null!;

  public int SortOrder { get; set; } // order status in UI

  public string? Color { get; set; } // UI-presentation

  // Nav properties baserade på Type
  public ICollection<ProjectEntity> Projects { get; set; } = [];
  public ICollection<InvoiceEntity> Invoices { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}