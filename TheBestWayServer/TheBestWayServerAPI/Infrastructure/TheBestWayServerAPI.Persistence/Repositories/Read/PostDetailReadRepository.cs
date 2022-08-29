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
    public class PostDetailReadRepository : GenericReadRepository<PostDetail>, IPostDetailReadRepository
    {
        public PostDetailReadRepository(TheBestWayDbContext theBestWayDbContext) : base(theBestWayDbContext)
        {
        }
    }
}
