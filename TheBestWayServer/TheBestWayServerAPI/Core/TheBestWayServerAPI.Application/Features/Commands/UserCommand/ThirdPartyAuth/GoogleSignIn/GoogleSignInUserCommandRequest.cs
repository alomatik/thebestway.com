using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Results;

namespace TheBestWayServerAPI.Application.Features.Commands.UserCommand.ThirdPartyAuth.GoogleSignIn
{
    public class GoogleSignInUserCommandRequest:IRequest<CommandWithTokenResult>
    {

    }
}
