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
using TheBestWayServerAPI.Application.ViewModels.QuestionAnswerModels;

namespace TheBestWayServerAPI.Application.Features.Queries.QuestionAnswerQueries.GetAllByQuestionId
{
    public class GetAllByQuestionIdQuestionAnswerHandler : IRequestHandler<GetAllByQuestionIdQuestionAnswerRequest, PaginatedQueryResult<List<QuestionAnswerViewModel>>>
    {

        private readonly IQuestionAnswerReadRepository _questionAnswerReadRepository;

        public GetAllByQuestionIdQuestionAnswerHandler(IQuestionAnswerReadRepository questionAnswerReadRepository)
        {
            _questionAnswerReadRepository = questionAnswerReadRepository;
        }

        public async Task<PaginatedQueryResult<List<QuestionAnswerViewModel>>> Handle(GetAllByQuestionIdQuestionAnswerRequest request, CancellationToken cancellationToken)
        {

            int totalQuestionAnswerCountForQuestionId = await _questionAnswerReadRepository.CountAsync(qa => qa.QuestionId == request.QuestionId);

            if (totalQuestionAnswerCountForQuestionId >= 1)
            {
                var questionAnswerViewModels = await _questionAnswerReadRepository.GetAll(qa => qa.QuestionId == request.QuestionId).Select(questionAnswer => new QuestionAnswerViewModel
                {
                    QuestionId = questionAnswer.QuestionId,
                    Id = questionAnswer.Id,
                    Content = questionAnswer.Content,
                    CreatedDate = questionAnswer.CreatedDate,
                    UserId = questionAnswer.UserId,
                    UserName = questionAnswer.User.UserName
                }).OrderByDescending(c => c.CreatedDate).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                return new PaginatedQueryResult<List<QuestionAnswerViewModel>>(200, questionAnswerViewModels, new Pagination
                {
                    CurrentPage = request.Page,
                    PageSize = request.PageSize,
                    TotalCount = totalQuestionAnswerCountForQuestionId
                });
            }

            throw new NotFoundException("Not found Question Answer");
        }
    }
}
