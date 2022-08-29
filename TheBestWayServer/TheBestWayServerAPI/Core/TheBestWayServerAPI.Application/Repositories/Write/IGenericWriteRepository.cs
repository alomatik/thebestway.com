using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Domain.Common;

namespace TheBestWayServerAPI.Application.Repositories.Write
{
    public interface IGenericWriteRepository<T> where T : BaseEntity
    {
        Task<int> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task AddRangeAsync(params T[] entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entites);
        void UpdateRange(params T[] entities);

        void DeleteRange(IEnumerable<T> entities);
        void DeleteRange(params T[] entities);
        void Delete(T entity);
    }
}
