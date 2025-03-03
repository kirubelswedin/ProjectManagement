using Data.context;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repository_Tests;

public class ProjectRepository_Tests
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();
        return context;
    }
    
    [Fact]
    public async Task CreateAsync_ShouldCreateAndReturnProject()
    {
        // Arrange
        var context = GetDataContext();
        
        context.Clients.AddRange(TestData.ClientEntities);
        context.Employees.AddRange(TestData.EmployeeEntities);
        context.ServiceTypes.AddRange(TestData.ServiceTypeEntities);
        context.Statuses.AddRange(TestData.StatusEntities);
        
        await context.SaveChangesAsync();
        IProjectRepository repository = new ProjectRepository(context);
        
        var projectEntity = TestData.ProjectEntities[0];

        // Act
        var result = await repository.CreateAsync(projectEntity);

        // Assert
        Assert.NotEqual(0, result!.Id);
    }
}