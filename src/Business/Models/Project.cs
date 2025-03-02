

namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public int ProjectNumber { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Budget { get; set; }
    
    public int StatusId { get; set; }
    public int ClientId { get; set; }
    public int ProjectManagerId { get; set; }
    public int ServiceTypeId { get; set; }
    
    public Status? Status { get; set; }
    public Client? Client { get; set; }
    public Employee? ProjectManager { get; set; }
    public ServiceType? ServiceType { get; set; }
    
}