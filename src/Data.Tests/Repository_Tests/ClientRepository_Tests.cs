using Data.context;
using Data.Interfaces;
using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repository_Tests;

public class ClientRepository_Tests
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
    public async Task GetClientsAsync_ShouldReturnClients()
    {
        // Arrange
        var context = GetDataContext();
        context.Clients.AddRange(TestData.ClientEntities);
        await context.SaveChangesAsync();

        IClientRepository repository = new ClientRepository(context);

        // Act
        var result = await repository.GetAllAsync();

        // Assert
        Assert.Equal(TestData.ClientEntities.Length, result.Count());
    }
}