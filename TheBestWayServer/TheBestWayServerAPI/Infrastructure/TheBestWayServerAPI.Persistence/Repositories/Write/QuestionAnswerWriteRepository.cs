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
    public class QuestionAnswerWriteRepository : GenericWriteRepository<QuestionAnswer>, IQuestionAnswerWriteRepository
    {
        public QuestionAnswerWriteRepository(TheBestWayDbContext dbContext) : base(dbContext)
        {
        }
    }
}
