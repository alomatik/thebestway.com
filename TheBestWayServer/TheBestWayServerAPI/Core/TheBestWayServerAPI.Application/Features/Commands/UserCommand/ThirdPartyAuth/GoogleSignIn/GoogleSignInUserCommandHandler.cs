using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;
using TheBestWayServerAPI.Domain.Entities;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ThirdPartyAuth.GoogleSignIn
{
    public class GoogleSignInUserCommandHandler : IRequestHandler<GoogleSignInUserCommandRequest, CommandWithTokenResult>
    {
        public Task<CommandWithTokenResult> Handle(GoogleSignInUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
