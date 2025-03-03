using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IEmployeeRepository : IBaseRepository<EmployeeEntity>
{
    Task<IEnumerable<EmployeeEntity>?> GetAllWithDetailsAsync();
    Task<EmployeeEntity?> GetWithDetailsAsync(Expression<Func<EmployeeEntity, bool>> predicate);
}