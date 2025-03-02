using DTOs.Employee;

namespace DTOs.Client;

public class ClientDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? CompanyName { get; set; }
  public string Email { get; set; } = null!;
  public string? PhoneNumber { get; set; }
  public string? Description { get; set; }

  // Nav
  public AddressDto? Address { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}