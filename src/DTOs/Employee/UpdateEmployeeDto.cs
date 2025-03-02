using System.ComponentModel.DataAnnotations;

namespace DTOs.Employee;

public class UpdateEmployeeDto
{
  [Required]
  [MaxLength(50)]
  public string FirstName { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string LastName { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  [EmailAddress]
  public string Email { get; set; } = null!;

  [MaxLength(50)]
  public string? PhoneNumber { get; set; }

  [Required]
  public DateTime HireDate { get; set; }

  [Required]
  public int DepartmentId { get; set; }

  public int? AddressId { get; set; }

  [Required]
  [Range(0, double.MaxValue)]
  public decimal HourlyRate { get; set; }
}