using Data.context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TimeEntryRepository(DataContext context) : BaseRepository<TimeEntryEntity>(context), ITimeEntryRepository
{
    
}