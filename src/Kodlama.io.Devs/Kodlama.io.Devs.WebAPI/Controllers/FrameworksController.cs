using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;
using Kodlama.io.Devs.Application.Features.Frameworks.Models;
using Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.Queries.GetListFrameworkByDynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        //[HttpPost("Add")]
        //public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand createFrameworkCommand)
        //{
        //    CreateFrameworkDto createFrameworkDto = await Mediator.Send(createFrameworkCommand);
        //    return Created("", createFrameworkDto);
        //}

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkQuery getListFrameworkQuery = new GetListFrameworkQuery { PageRequest = pageRequest };
            FrameworkListModel frameworkListModel = await Mediator.Send(getListFrameworkQuery);
            return Ok(frameworkListModel);
        }



        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListFrameworkByDynamicQuery  getListFrameworkByDynamicQuery = new GetListFrameworkByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            FrameworkListModel frameworkListModel = await Mediator.Send(getListFrameworkByDynamicQuery);
            return Ok(frameworkListModel);
        }
    }
}
