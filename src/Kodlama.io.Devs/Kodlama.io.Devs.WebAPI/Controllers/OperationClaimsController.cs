using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Frameworks.DTOs;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.DTOs;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createOperationClaimDto);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdateOperationClaimDto updateOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(updateOperationClaimDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeleteOperationClaimDto deleteOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deleteOperationClaimDto);
        }
    }
}
