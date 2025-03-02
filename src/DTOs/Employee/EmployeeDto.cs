namespace DTOs.Employee;

public class EmployeeDto
{
  public int Id { get; set; }
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string? PhoneNumber { get; set; }
  public DateTime HireDate { get; set; }
  public decimal HourlyRate { get; set; }

  // Nav
  public DepartmentDto? Department { get; set; } = null!;
  public AddressDto? Address { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}

public class DepartmentDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
}

public class AddressDto
{
  public int Id { get; set; }
  public string Street { get; set; } = null!;
  public string City { get; set; } = null!;
  public string State { get; set; } = null!;
  public string PostalCode { get; set; } = null!;
  public string Country { get; set; } = null!;
}