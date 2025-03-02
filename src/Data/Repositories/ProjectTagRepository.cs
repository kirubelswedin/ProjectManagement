using Data.context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectTagRepository(DataContext context) : BaseRepository<ProjectTagEntity>(context), IProjectTagRepository
{
    
}