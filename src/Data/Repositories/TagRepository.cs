using Data.context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class TagRepository(DataContext context) : BaseRepository<TagEntity>(context), ITagRepository
{
    
}