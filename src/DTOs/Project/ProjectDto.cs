namespace DTOs.Project;

public class ProjectDto
{
  public int Id { get; set; }
  public int ProjectNumber { get; set; }
  public string ProjectName { get; set; } = null!;
  public string Description { get; set; } = null!;
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
  public decimal Budget { get; set; }

  // Nav
  public StatusDto? Status { get; set; } = null!;
  public ClientDto? Client { get; set; } = null!;
  public EmployeeDto? ProjectManager { get; set; } = null!;
  public ServiceTypeDto? ServiceType { get; set; } = null!;

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}

public class StatusDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string Type { get; set; } = null!;
  public string Description { get; set; } = null!;
  public int SortOrder { get; set; }
  public string? Color { get; set; }
}

public class ClientDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string? CompanyName { get; set; }
  public string Email { get; set; } = null!;
  public string? PhoneNumber { get; set; }
}

public class EmployeeDto
{
  public int Id { get; set; }
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string? PhoneNumber { get; set; }
}

public class ServiceTypeDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public decimal DefaultHourlyRate { get; set; }
}