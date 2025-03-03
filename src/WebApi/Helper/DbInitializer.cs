using Business.Factories;
using Data.context;
using Data.Entities;

namespace WebApi.Helper;


// Initializes the database with default data. Took some help from gpt.
public static class DbInitializer
{

    public static void Initialize(DataContext context)
    {
        // ServiceTypes
        if (!context.ServiceTypes.Any())
        {
            var serviceTypes = ServiceTypeFactory.CreateDefaultServiceTypes();
            context.ServiceTypes.AddRange(serviceTypes);
            context.SaveChanges();
        }

        // Statuses
        if (!context.Statuses.Any())
        {
            var projectStatuses = StatusFactory.CreateDefaultProjectStatuses();
            var invoiceStatuses = StatusFactory.CreateDefaultInvoiceStatuses();
            context.Statuses.AddRange(projectStatuses);
            context.Statuses.AddRange(invoiceStatuses);
            context.SaveChanges();
        }

        // Departments
        if (!context.Departments.Any())
        {
            var departments = new List<DepartmentEntity>
            {
                new DepartmentEntity
                {
                    Name = "Utveckling",
                    Description = "Utvecklingsavdelning",
                    CreatedAt = DateTime.UtcNow
                },
                new DepartmentEntity
                {
                    Name = "Design",
                    Description = "Designavdelning",
                    CreatedAt = DateTime.UtcNow
                },
                new DepartmentEntity
                {
                    Name = "Projektledning",
                    Description = "Projektledningsavdelning",
                    CreatedAt = DateTime.UtcNow
                },
                new DepartmentEntity
                {
                    Name = "Marknad",
                    Description = "Marknadsavdelning",
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }

        // Clients
        if (!context.Clients.Any())
        {
            var clients = new List<ClientEntity>
            {
                new ClientEntity
                {
                    Name = "Testföretag AB",
                    Email = "kontakt@testforetag.se",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new ClientEntity
                {
                    Name = "Volvo Cars",
                    Email = "info@volvocars.com",
                    PhoneNumber = "031-123456",
                    CompanyName = "Volvo Car Corporation",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new ClientEntity
                {
                    Name = "Ericsson",
                    Email = "contact@ericsson.com",
                    PhoneNumber = "08-987654",
                    CompanyName = "Telefonaktiebolaget LM Ericsson",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new ClientEntity
                {
                    Name = "IKEA",
                    Email = "customer.service@ikea.com",
                    PhoneNumber = "042-123789",
                    CompanyName = "IKEA of Sweden AB",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new ClientEntity
                {
                    Name = "Spotify",
                    Email = "business@spotify.com",
                    PhoneNumber = "08-555123",
                    CompanyName = "Spotify AB",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();
        }

        // Employees/ProjectManagers
        if (!context.Employees.Any())
        {
            var departments = context.Departments.ToList();
            var developmentDept = departments.FirstOrDefault(d => d.Name == "Utveckling") ?? departments.First();
            var designDept = departments.FirstOrDefault(d => d.Name == "Design") ?? departments.First();
            var projectManagementDept = departments.FirstOrDefault(d => d.Name == "Projektledning") ?? departments.First();
            var marketingDept = departments.FirstOrDefault(d => d.Name == "Marknad") ?? departments.First();

            var employees = new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    FirstName = "Test",
                    LastName = "Testsson",
                    Email = "test@example.com",
                    HireDate = DateTime.UtcNow.AddYears(-2),
                    DepartmentId = developmentDept.Id,
                    HourlyRate = 1000m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "Anders",
                    LastName = "Andersson",
                    Email = "anders.andersson@company.com",
                    PhoneNumber = "070-123456",
                    HireDate = DateTime.UtcNow.AddYears(-3),
                    DepartmentId = projectManagementDept.Id,
                    HourlyRate = 1200m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "Britta",
                    LastName = "Bengtsson",
                    Email = "britta.bengtsson@company.com",
                    PhoneNumber = "070-234567",
                    HireDate = DateTime.UtcNow.AddYears(-1),
                    DepartmentId = projectManagementDept.Id,
                    HourlyRate = 1150m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "David",
                    LastName = "Davidsson",
                    Email = "david.davidsson@company.com",
                    PhoneNumber = "070-345678",
                    HireDate = DateTime.UtcNow.AddYears(-2).AddMonths(-6),
                    DepartmentId = projectManagementDept.Id,
                    HourlyRate = 1250m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "Emma",
                    LastName = "Eriksson",
                    Email = "emma.eriksson@company.com",
                    PhoneNumber = "070-456789",
                    HireDate = DateTime.UtcNow.AddYears(-1).AddMonths(-3),
                    DepartmentId = developmentDept.Id,
                    HourlyRate = 950m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "Fredrik",
                    LastName = "Fransson",
                    Email = "fredrik.fransson@company.com",
                    PhoneNumber = "070-567890",
                    HireDate = DateTime.UtcNow.AddMonths(-8),
                    DepartmentId = designDept.Id,
                    HourlyRate = 900m,
                    CreatedAt = DateTime.UtcNow
                },
                new EmployeeEntity
                {
                    FirstName = "Gunilla",
                    LastName = "Gustafsson",
                    Email = "gunilla.gustafsson@company.com",
                    PhoneNumber = "070-678901",
                    HireDate = DateTime.UtcNow.AddYears(-4),
                    DepartmentId = marketingDept.Id,
                    HourlyRate = 1100m,
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}