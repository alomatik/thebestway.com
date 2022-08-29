using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Repositories.Read;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Application.ViewModels.PostModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Queries.PostQueries.GetById
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, QueryResult<GetPostViewModel>>
    {
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IPostReadRepository _postReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly UserManager<User> _userManager;

        public GetByIdPostQueryHandler(IPostReadRepository postReadRepository, ICategoryReadRepository categoryReadRepository, UserManager<User> userManager, ICommentReadRepository commentReadRepository)
        {
            _postReadRepository = postReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _userManager = userManager;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<QueryResult<GetPostViewModel>> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            //var getPostViewModel=  await _postReadRepository.GetPostFullIncludeAsync(request.Id);

            var getPostViewModel = await _postReadRepository.GetAsQueryable(p => p.Id == request.Id).Select(p => new GetPostViewModel
            {
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                ViewCount = p.PostDetail.ViewCount,
                LikeCount = p.PostDetail.LikeCount,
                DislikeCount = p.PostDetail.DislikeCount,
                UserId = p.UserId,
                UserName = p.User.UserName
            }).SingleOrDefaultAsync(cancellationToken);

            if (getPostViewModel != null)
            {
                return new QueryResult<GetPostViewModel>(200, getPostViewModel);
            }

            throw new NotFoundException($"{request.Id} post not found.");

        }
    }
}
