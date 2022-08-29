using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.ViewModels.PostModels;
using TheBestWayServerAPI.Domain.Entities;
using TheBestWayServerAPI.Persistence.Contexts;

namespace TheBestWayServerAPI.Persistence.Repositories.Read
{
    public class PostReadRepository : GenericReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(TheBestWayDbContext theBestWayDbContext) : base(theBestWayDbContext)
        {
        }

        public async Task<GetPostViewModel> GetPostFullIncludeAsync(int id)
        {
            var x = await _theBestWayDbContext.GetPostViewModels.FromSqlInterpolated($"exec sp_get_post_by_id {id}").ToListAsync();

            throw new Exception();

        }
    }
}
