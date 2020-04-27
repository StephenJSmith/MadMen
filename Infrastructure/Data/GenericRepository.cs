using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specfications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private readonly MadMenContext _context;
    public GenericRepository(MadMenContext context)
    {
      _context = context;
    }

    public async Task<T> GetById(int id)
    {
      var item = await _context.Set<T>().FindAsync(id);

      return item;
    }

    public async Task<IReadOnlyList<T>> ListAll()
    {
      var items = await _context.Set<T>().ToListAsync();

      return items;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
      var tEntity = await ApplySpecification(spec).FirstOrDefaultAsync();

      return tEntity;
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
      var tEntities = await ApplySpecification(spec).ToListAsync();

      return tEntities;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec) {
      var queryable = SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);

      return queryable;
    }

    public async Task<int> Count(ISpecification<T> spec)
    {
      var count = await ApplySpecification(spec).CountAsync();

      return count;
    }
  }
}