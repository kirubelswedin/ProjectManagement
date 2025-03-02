using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class EmployeeEntity
{
  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  public string FirstName { get; set; } = null!;

  [Required]
  [MaxLength(50)]
  public string LastName { get; set; } = null!;

  [MaxLength(100)]
  [EmailAddress]
  public string Email { get; set; } = null!;

  [MaxLength(50)]
  public string? PhoneNumber { get; set; }

  public DateTime HireDate { get; set; }

  [ForeignKey("DepartmentEntity")]
  public int DepartmentId { get; set; }
  public DepartmentEntity Department { get; set; } = null!;

  [ForeignKey("AddressEntity")]
  public int? AddressId { get; set; }
  public AddressEntity? Address { get; set; }

  public decimal HourlyRate { get; set; }

  // Navigation properties
  public ICollection<ProjectEmployeeEntity> ProjectEmployees { get; set; } = [];
  public ICollection<TimeEntryEntity> TimeEntries { get; set; } = [];
  public ICollection<CommentEntity> Comments { get; set; } = [];
  public ICollection<ProjectEntity> ManagedProjects { get; set; } = [];

  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; }
}