﻿using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Languages.DTOs;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
    }
}
