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

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionQueries.GetAllByUserId
{
    public class GetAllByUserIdQuestionQueryHandler : IRequestHandler<GetAllByUserIdQuestionQueryRequest, PaginatedQueryResult<List<QuestionForUserViewModel>>>
    {
        private readonly IQuestionReadRepository _questionReadRepository;

        public GetAllByUserIdQuestionQueryHandler(IQuestionReadRepository questionReadRepository)
        {
            _questionReadRepository = questionReadRepository;
        }


        public async Task<PaginatedQueryResult<List<QuestionForUserViewModel>>> Handle(GetAllByUserIdQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            int totalQuestionCountForUserId = await _questionReadRepository.CountAsync(q => q.UserId == request.UserId);

            if (totalQuestionCountForUserId >= 1)
            {
                var questionForUserViewModels = await _questionReadRepository.GetAll(q => q.UserId == request.UserId && !q.IsDeleted).Select(question => new QuestionForUserViewModel
                {
                    PostId = question.PostId,
                    Id = question.Id,
                    Title = question.Title,
                    Content = question.Content,
                    CreatedDate = question.CreatedDate,
                    UserId = question.UserId,
                    PostTitle= question.Post.Title
                }).OrderByDescending(c => c.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken); ;

                return new PaginatedQueryResult<List<QuestionForUserViewModel>>(200, questionForUserViewModels, new Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalQuestionCountForUserId
                });
            }
            throw new NotFoundException($"Not Found Any Question");
        }
    }
}
