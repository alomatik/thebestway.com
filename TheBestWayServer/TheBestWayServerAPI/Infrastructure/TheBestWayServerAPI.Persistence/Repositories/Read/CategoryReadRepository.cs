using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayServerAPI.Persistence.Contexts;

namespace TheBestWayServerAPI.Persistence.Repositories.Read
{
    public class CategoryReadRepository : GenericReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(TheBestWayDbContext theBestWayDbContext) : base(theBestWayDbContext)
        {
        }
    }
}
