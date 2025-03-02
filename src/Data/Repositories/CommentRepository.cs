using Data.context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CommentRepository(DataContext context) : BaseRepository<CommentEntity>(context), ICommentRepository
{
    
}