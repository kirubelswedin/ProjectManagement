using Data.context;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repository_Tests;

public class StatusRepository_Tests
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
    public async Task GetStatusesAsync_ShouldReturnStatuses()
    {
        // Arrange
        var context = GetDataContext();
        context.Statuses.AddRange(TestData.StatusEntities);
        await context.SaveChangesAsync();

        IStatusRepository repository = new StatusRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.StatusEntities.Length, result.Count());
    }
}