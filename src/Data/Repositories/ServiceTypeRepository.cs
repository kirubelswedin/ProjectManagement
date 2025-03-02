using Data.context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ServiceTypeRepository(DataContext context) : BaseRepository<ServiceTypeEntity>(context), IServiceTypeRepository
{
    
}