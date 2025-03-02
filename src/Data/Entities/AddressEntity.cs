using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class AddressEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(200)]
  public string Street { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  public string City { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  public string State { get; set; } = null!;

  [Required]
  [MaxLength(20)]
  public string PostalCode { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  public string Country { get; set; } = null!;

  // Navigation properties
  public ICollection<ClientEntity> Clients { get; set; } = [];
  public ICollection<EmployeeEntity> Employees { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}