using System.Collections.Generic;
using System.Threading.Tasks;
using coredapperapi.Domain;

namespace coredapperapi.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
         Task<List<T>> GetAllAsync();
         Task<T> GetByIdAsync(int id);
         Task<int> CreateAsync(T entity);
         Task<int> UpdateAsync(T entity);
         Task<int> DeleteAsync(T entity);
    }
}