using System.Diagnostics;
using System.Linq.Expressions;
using Data.context;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeeEntity>(context), IEmployeeRepository
{
  public override async Task<IEnumerable<EmployeeEntity>?> GetAllAsync()
  {
    try
    {
      var entities = await _context.Employees
          .Include(e => e.Department)
          .Include(e => e.Address)
          .ToListAsync();
      return entities;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return [];
    }
  }

  public override async Task<EmployeeEntity?> GetAsync(Expression<Func<EmployeeEntity, bool>> predicate)
  {
    try
    {
      var entity = await _context.Employees
          .Include(e => e.Department)
          .Include(e => e.Address)
          .FirstOrDefaultAsync(predicate);
      return entity;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null;
    }
  }
}