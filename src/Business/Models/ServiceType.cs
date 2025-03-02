namespace Business.Models;

public class ServiceType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal DefaultHourlyRate { get; set; }
    
}