using Data.Entities;

namespace Business.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DisplayName => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public decimal HourlyRate { get; set; }
    
    public int DepartmentId { get; set; }
    public int? AddressId { get; set; }
    
    public Department Department { get; set; } = null!;
    public Address? Address { get; set; }
    
}