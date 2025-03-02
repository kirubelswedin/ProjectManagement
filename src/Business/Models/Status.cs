namespace Business.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int SortOrder { get; set; } 
    public string? Color { get; set; } 
}

