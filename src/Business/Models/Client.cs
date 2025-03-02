using Data.Entities;

namespace Business.Models;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? CompanyName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
}