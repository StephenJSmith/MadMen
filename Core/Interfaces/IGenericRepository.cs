using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specfications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
         Task<T> GetById(int id);
         Task<IReadOnlyList<T>> ListAll();
         Task<T> GetEntityWithSpec(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}