using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels;
using TheBestWayServerAPI.Application.ViewModels.QuestionModels;

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByPostId
{
    public class GetAllByPostIdQuestionQueryHandler : IRequestHandler<GetAllByPostIdQuestionQueryRequest, PaginatedQueryResult<List<QuestionViewModel>>>
    {
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetAllByPostIdQuestionQueryHandler(IQuestionReadRepository questionReadRepository)
        {
            _questionReadRepository = questionReadRepository;
        }

        public async Task<PaginatedQueryResult<List<QuestionViewModel>>> Handle(GetAllByPostIdQuestionQueryRequest request, CancellationToken cancellationToken)
        {

            int totalQuestionCountForPostId = await _questionReadRepository.CountAsync(q => q.PostId == request.PostId && !q.IsDeleted);

            if (totalQuestionCountForPostId>=1)
            {
                var questionViewModels = await _questionReadRepository.GetAll(q => q.PostId == request.PostId && !q.IsDeleted).Select(question => new QuestionViewModel
                {
                    PostId = question.PostId,
                    Id = question.Id,
                    Title = question.Title,
                    Content = question.Content,
                    CreatedDate = question.CreatedDate,
                    UserId = question.UserId,
                    UserName = question.User.UserName,
                }).OrderByDescending(c => c.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken); 

                return new PaginatedQueryResult<List<QuestionViewModel>>(200, questionViewModels, new Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalQuestionCountForPostId
                });
            }

            throw new NotFoundException($"Not Found Any Question");
        }
    }
}
