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
      // Easier to test and more flexible
      return await _context.Employees.ToListAsync();
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null;
    }
  }

  public async Task<IEnumerable<EmployeeEntity>?> GetAllWithDetailsAsync()
  {
    try
    {
      return await _context.Employees
          .Include(e => e.Department)
          .Include(e => e.Address)
          .ToListAsync();
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null;
    }
  }

  public override async Task<EmployeeEntity?> GetAsync(Expression<Func<EmployeeEntity, bool>> predicate)
  {
    try
    {
      return await _context.Employees
          .FirstOrDefaultAsync(predicate);
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null;
    }
  }

  public async Task<EmployeeEntity?> GetWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> predicate)
  {
    try
    {
      return await _context.Employees
          .Include(e => e.Department)
          .Include(e => e.Address)
          .FirstOrDefaultAsync(predicate);
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return null;
    }
  }
}