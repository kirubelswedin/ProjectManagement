using Data.Entities;

namespace Data.Tests.SeedData;

public static class TestData
{
    public static readonly ClientEntity[] ClientEntities =
    {
        new ClientEntity { Id = 1, Name = "Volvo Cars", Email = "info@volvocars.com", CreatedAt = DateTime.UtcNow },
        new ClientEntity { Id = 2, Name = "Ericsson", Email = "contact@ericsson.com", CreatedAt = DateTime.UtcNow },
        new ClientEntity { Id = 3, Name = "IKEA", Email = "customer.service@ikea.com", CreatedAt = DateTime.UtcNow },
    };

    public static readonly EmployeeEntity[] EmployeeEntities =
    {
        new EmployeeEntity { Id = 1, FirstName = "Anders", LastName = "Andersson", Email = "anders.andersson@company.com", CreatedAt = DateTime.UtcNow },
        new EmployeeEntity { Id = 2, FirstName = "Britta", LastName = "Bengtsson", Email = "britta.bengtsson@company.com", CreatedAt = DateTime.UtcNow },
        new EmployeeEntity { Id = 3, FirstName = "David", LastName = "Davidsson", Email = "david.davidsson@company.com", CreatedAt = DateTime.UtcNow }
    };

    public static readonly ProjectEntity[] ProjectEntities =
    {
        new ProjectEntity { Id = 1, ProjectName = "Project A", Description = "Description A", StartDate = DateTime.UtcNow.AddMonths(1), EndDate = DateTime.UtcNow.AddMonths(6), ClientId = 1, ProjectManagerId = 1, ServiceTypeId = 1, StatusId = 1, CreatedAt = DateTime.UtcNow },
        new ProjectEntity { Id = 2, ProjectName = "Project B", Description = "Description B", StartDate = DateTime.UtcNow.AddMonths(2), EndDate = DateTime.UtcNow.AddMonths(7), ClientId = 2, ProjectManagerId = 2, ServiceTypeId = 2, StatusId = 2, CreatedAt = DateTime.UtcNow },
        new ProjectEntity { Id = 3, ProjectName = "Project C", Description = "Description C", StartDate = DateTime.UtcNow.AddMonths(3), EndDate = DateTime.UtcNow.AddMonths(8), ClientId = 3, ProjectManagerId = 3, ServiceTypeId = 3, StatusId = 3, CreatedAt = DateTime.UtcNow }
    };

    public static readonly ServiceTypeEntity[] ServiceTypeEntities =
    {
        new ServiceTypeEntity { Id = 1, Name = "Systemutveckling", Description = "Skräddarsydd systemutveckling för verksamhetens behov", DefaultHourlyRate = 1300m, CreatedAt = DateTime.UtcNow },
        new ServiceTypeEntity { Id = 2, Name = "Webbutveckling", Description = "Frontend och backend utveckling av webbplatser och -applikationer", DefaultHourlyRate = 1200m, CreatedAt = DateTime.UtcNow },
        new ServiceTypeEntity { Id = 3, Name = "Förvaltning", Description = "Löpande underhåll och förvaltning av system och webbplatser", DefaultHourlyRate = 900m, CreatedAt = DateTime.UtcNow }
    };

    public static readonly StatusEntity[] StatusEntities =
    {
        new StatusEntity { Id = 1, Name = "Ej påbörjad", Type = "Project", Description = "Projektet har inte startats än", Color = "#gray", CreatedAt = DateTime.UtcNow },
        new StatusEntity { Id = 2, Name = "Pågående", Type = "Project", Description = "Projektet är aktivt", Color = "#blue", CreatedAt = DateTime.UtcNow },
        new StatusEntity { Id = 3, Name = "Skickad", Type = "Invoice", Description = "Fakturan har skickats till kund", Color = "#blue", CreatedAt = DateTime.UtcNow },
    };
}