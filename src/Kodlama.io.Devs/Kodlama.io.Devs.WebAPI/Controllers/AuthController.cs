using Core.Security.DTOs;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Login;
using Kodlama.io.Devs.Application.Features.Authorizations.Commands.Register;
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
                UserForRegisterDto = userForRegisterDto,
                IPAddress = getIpAddress()
            };

            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(registeredDto.RefreshToken);
            return Created("", registeredDto.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IPAddress = getIpAddress() };
            LoggedDto loggedDto = await Mediator.Send(loginCommand);

            if (loggedDto.RefreshToken is not null) setRefreshTokenToCookie(loggedDto.RefreshToken);

            return Ok(loggedDto.AccessToken);
        }


        private string getRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }

        private void setRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
