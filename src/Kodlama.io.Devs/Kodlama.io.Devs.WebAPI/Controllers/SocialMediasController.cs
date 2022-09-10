using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreateSocialMediaDto result = await Mediator.Send(createSocialMediaCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            UpdateSocialMediaDto result = await Mediator.Send(updateSocialMediaCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeleteSocialMediaDto result = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }
    }
}
