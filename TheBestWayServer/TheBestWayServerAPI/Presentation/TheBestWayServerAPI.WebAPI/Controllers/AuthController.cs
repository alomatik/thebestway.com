using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBestWayServerAPI.Application.Dtos;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.ChangePassword;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.ForgotPassword;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.ResetPassword;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.SignIn;
using TheBestWayServerAPI.Application.Features.Commands.UserCommand.SignInByRefreshToken;

namespace TheBestWayServerAPI.WebAPI.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInUserCommandRequest signInUserCommandRequest)
        {
            var result = await _mediator.Send(signInUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SignInByRefreshToken([FromForm] SignInByRefreshTokenUserCommandRequest signInByRefreshTokenUserCommandRequest)
        {
            var result = await _mediator.Send(signInByRefreshTokenUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordUserCommandRequest changePasswordUserCommandRequest)
        {
            var result = await _mediator.Send(changePasswordUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FargotPassword(ForgotPasswordUserCommandRequest forgotPasswordUserCommandRequest)
        {
            var result = await _mediator.Send(forgotPasswordUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword(string userId, string token, ResetPasswordDto resetPasswordDto)
        {
            ResetPasswordUserCommandRequest resetPasswordUserCommandRequest = new()
            {
                UserId = userId,
                ResetPasswordToken = token,
                NewPassword = resetPasswordDto.NewPassword,
                NewPasswordConfirm = resetPasswordDto.NewPasswordConfirm
            };
            var result = await _mediator.Send(resetPasswordUserCommandRequest);
            return StatusCode(result.StatusCode, result);
        }

    }
}
