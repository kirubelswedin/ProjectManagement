using Data.context;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repository_Tests;

public class EmployeeRepository_Tests
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
  public async Task GetEmployeesAsync_ShouldReturnEmployees()
  {
    // Arrange
    var context = GetDataContext();
    context.Employees.AddRange(TestData.EmployeeEntities);
    await context.SaveChangesAsync();
    
    IEmployeeRepository repository = new EmployeeRepository(context);

    // Act
    var result = await repository.GetAllAsync();

    // Assert
    Assert.NotNull(result);
    var resultList = result.ToList();
    Assert.Equal(TestData.EmployeeEntities.Length, resultList.Count);
  }
}