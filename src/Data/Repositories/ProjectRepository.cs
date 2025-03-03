using System.Diagnostics;
using System.Linq.Expressions;
using Data.context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>?> GetAllAsync()
    {
        try
        {
            // Include all related entities
            var entities = await _context.Projects
                .Include(p => p.Status)
                .Include(p => p.Client)
                .Include(p => p.ProjectManager)
                .Include(p => p.ServiceType)
                .ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Projects
                .Include(p => p.Status)
                .Include(p => p.Client)
                .Include(p => p.ProjectManager)
                .Include(p => p.ServiceType)
                .FirstOrDefaultAsync(predicate);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<int> GetMaxProjectNumberAsync()
    {
        try
        {
            var maxNumber = await _context.Projects.MaxAsync(p => (int?)p.ProjectNumber);
            return maxNumber ?? 100;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return 100;
        }
    }
}