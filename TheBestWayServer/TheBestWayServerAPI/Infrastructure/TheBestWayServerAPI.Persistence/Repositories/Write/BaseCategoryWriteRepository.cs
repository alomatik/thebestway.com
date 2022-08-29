using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Write;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayServerAPI.Persistence.Contexts;

namespace TheBestWayServerAPI.Persistence.Repositories.Write
{
    public class BaseCategoryWriteRepository : GenericWriteRepository<BaseCategory>, IBaseCategoryWriteRepository
    {
        public BaseCategoryWriteRepository(TheBestWayDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
