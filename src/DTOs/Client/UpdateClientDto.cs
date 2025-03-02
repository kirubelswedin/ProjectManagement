using System.ComponentModel.DataAnnotations;

namespace DTOs.Client;

public class UpdateClientDto
{
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

  public int? AddressId { get; set; }
}