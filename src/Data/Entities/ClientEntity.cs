using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ClientEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Name { get; set; } = null!;

  [MaxLength(200)]
  public string? CompanyName { get; set; }

  [Required]
  [MaxLength(100)]
  [EmailAddress]
  public string Email { get; set; } = null!;

  [MaxLength(50)]
  public string? PhoneNumber { get; set; }

  [MaxLength(500)]
  public string? Description { get; set; }

  [ForeignKey("AddressEntity")]
  public int? AddressId { get; set; }
  public AddressEntity? Address { get; set; }

  // Navigation properties
  public ICollection<ProjectEntity> Projects { get; set; } = [];
  public ICollection<InvoiceEntity> Invoices { get; set; } = [];

  public bool IsActive { get; set; } = true;

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}
