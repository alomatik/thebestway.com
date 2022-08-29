using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.Services;
using TheBestWayServerAPI.Application.Exceptions;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, CommandNoMessageResult>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<CommandNoMessageResult> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserAsync(new ViewModels.UserModels.UpdateUserViewModel
            {
                BirthDate = request.BirthDate,
                Country = request.Country,
                City = request.City,
                TwitterLink = request.TwitterLink,
                GitHubLink = request.GitHubLink,
                YouTubeLink = request.YouTubeLink,
                InstagramLink = request.InstagramLink,
                Profession = request.Profession
            });
        }
    }
}
