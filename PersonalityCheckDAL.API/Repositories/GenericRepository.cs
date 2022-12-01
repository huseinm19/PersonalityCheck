using PersonalityCheckDAL.API.DatabaseContexts;
using PersonalityCheckDAL.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PersonalityCheckDAL.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PersonalityCheckContext _context;
        private readonly DbSet<T> _entities;
        public GenericRepository(PersonalityCheckContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);

        }
    }
}