using Application.Features.Users.Commands.ChangePasswordCommand;
using Application.Features.Users.Commands.CrateUserCommand;
using Application.Features.Users.Commands.ResetPassword;
using Application.Features.Users.Querys.GetAllUserPages;
using Application.Features.Users.Querys.GetAllUsers;
using Application.Features.Users.Querys.GetUserById;
using Application.Filters.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> Create(CreateUserCommand user)
        {
            return Ok(await Mediator.Send(user));
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsers()));
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpGet]
        [Route("getAllUsersPages")]
        public async Task<IActionResult> GetAllPages([FromBody]UsersFilters filters)
        {
            return Ok(await Mediator.Send(new GetAllUsersPages() { Fiters = filters}));
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpGet]
        [Route("getUserById")]
        public async Task<IActionResult> GetById(GetUserById userId)
        {
            return Ok(await Mediator.Send(userId));
        }

        [Authorize]
        [HttpGet]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand email)
        {
            return Ok(await Mediator.Send(email));
        }

        [Authorize]
        [HttpPut]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand credencials)
        {
            return Ok(await Mediator.Send(credencials));
        }
    }
}
