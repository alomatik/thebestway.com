using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.ViewModels.PostModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Repositories.Read
{
    public interface IPostReadRepository : IGenericReadRepository<Post>
    {
        Task<GetPostViewModel> GetPostFullIncludeAsync(int id);
    }
}
