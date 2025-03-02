using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class InvoiceEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string InvoiceNumber { get; set; } = null!;

  [ForeignKey("ProjectEntity")]
  public int ProjectId { get; set; }
  public ProjectEntity Project { get; set; } = null!;

  [ForeignKey("ClientEntity")]
  public int ClientId { get; set; }
  public ClientEntity Client { get; set; } = null!;

  public DateTime InvoiceDate { get; set; }

  public DateTime DueDate { get; set; }

  public decimal TotalAmount { get; set; }

  public bool IsPaid { get; set; }

  public DateTime? PaidDate { get; set; }

  [MaxLength(500)]
  public string? Notes { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}