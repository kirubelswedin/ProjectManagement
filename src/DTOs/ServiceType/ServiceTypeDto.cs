namespace DTOs.ServiceType;

public class ServiceTypeDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public decimal DefaultHourlyRate { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}