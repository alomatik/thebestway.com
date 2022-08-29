using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Features.Commands.BaseCategoryCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.CategoryCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.CommentCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.PostCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.QuestionCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.RoleCommand.Create;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.Create;
using TheBestWayServerAPI.Application.ViewModels.BaseCategoryModels;
using TheBestWayServerAPI.Application.ViewModels.CategoryModels;
using TheBestWayServerAPI.Application.ViewModels.PostModels;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Mapping
{
    public class GenericMapProfile : Profile
    {
        public GenericMapProfile()
        {
            CreateMap<BaseCategory, CreateBaseCategoryCommandRequest>()
               .ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>()
                .ReverseMap();
            CreateMap<Post, CreatePostCommandRequest>()
                .ReverseMap();
            CreateMap<Comment, CreateCommentCommandRequest>()
                .ReverseMap();
            CreateMap<Question, CreateQuestionCommandRequest>()
                .ReverseMap();
            CreateMap<User, CreateUserCommandRequest>()
                .ReverseMap();
            CreateMap<Role, CreateRoleCommandRequest>()
                .ReverseMap();
            ///
            CreateMap<BaseCategory, GetAllBaseCategoryViewModel>()
               .ReverseMap();
            CreateMap<BaseCategory, GetBaseCategoryViewModel>()
               .ReverseMap();
            CreateMap<Category, GetCategoryViewModel>()
               .ReverseMap();
            CreateMap<Post, GetPostViewModel>()
              .ReverseMap();
        }
    }
}
