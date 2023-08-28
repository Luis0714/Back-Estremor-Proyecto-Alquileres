using Application.Features.Roles.Command.CreateRolCommand;
using Application.Features.Roles.Querys.GetAllRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize(Policy = "SuperAdmin")]
    public class RolController : BaseApiController
    {
        [HttpPost]
        [Route("createRol")]
        public async Task<IActionResult> Create(CreateRolCommand rol)
        {
            return Ok(await Mediator.Send(rol));
        }

        [HttpGet]
        [Route("getAllRoles")]
        public async Task<IActionResult> Create()
        {
            return Ok(await Mediator.Send(new GetAllRoles()));
        }

    }
}
