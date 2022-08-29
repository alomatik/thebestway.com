using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Domain.Common;
using TheBestWayServerAPI.Persistence.Contexts;

namespace TheBestWayServerAPI.Persistence.Repositories.Read
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : BaseEntity
    {
        protected readonly TheBestWayDbContext _theBestWayDbContext;

        public GenericReadRepository(TheBestWayDbContext theBestWayDbContext)
        {
            _theBestWayDbContext = theBestWayDbContext;
        }

        public async Task<bool> AnyAsync()
            => await _theBestWayDbContext.Set<T>().AnyAsync();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _theBestWayDbContext.Set<T>().AnyAsync(predicate);

        public int Count()
           => _theBestWayDbContext.Set<T>().Count();

        public int Count(Expression<Func<T, bool>> predicate)
            => _theBestWayDbContext.Set<T>().Count(predicate);

        public async Task<int> CountAsync()
            => await _theBestWayDbContext.Set<T>().CountAsync();

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
            => await _theBestWayDbContext.Set<T>().CountAsync(predicate);

        public IQueryable<T> GetAll()
            => _theBestWayDbContext.Set<T>().AsQueryable();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
             => _theBestWayDbContext.Set<T>().AsQueryable().Where(predicate);

        public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return _theBestWayDbContext.Set<T>().Where(predicate);
        }
        public IQueryable<T> GetAsQueryable()
        {
            return _theBestWayDbContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
             => await _theBestWayDbContext.Set<T>().SingleOrDefaultAsync(predicate);

        public async Task<T> GetByIdAsync(int id)
             => await _theBestWayDbContext.Set<T>().FindAsync(id);
    }
}
