using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.EmailConfirmation
{
    public class EmailConfirmationUserCommandHandler:IRequestHandler<EmailConfirmationUserCommandRequest,Result>
    {
        private readonly UserManager<User> _userManager;

        public EmailConfirmationUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(EmailConfirmationUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user != null)
            {
                string confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
               
            }

            throw new NotImplementedException();
        }
    }
}
