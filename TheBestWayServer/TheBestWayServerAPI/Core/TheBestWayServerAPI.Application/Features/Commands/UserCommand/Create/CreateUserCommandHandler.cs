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

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.Create
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommandRequest, CommandWithMessageResult>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CommandWithMessageResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUserAsync(new ViewModels.UserModels.CreateUserViewModel
            {
                UserName = request.UserName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Profession = request.Profession
            });
        }
    }
}
