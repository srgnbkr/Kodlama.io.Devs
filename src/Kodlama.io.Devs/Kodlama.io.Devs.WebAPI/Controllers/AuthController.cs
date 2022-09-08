using Core.Security.DTOs;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands;
using Kodlama.io.Devs.Application.Features.Authorizations.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new RegisterCommand
            {
                UserForRegisterDto = userForRegisterDto
            };

            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            return Created("", registeredDto.AccessToken);
        }
    }
}
