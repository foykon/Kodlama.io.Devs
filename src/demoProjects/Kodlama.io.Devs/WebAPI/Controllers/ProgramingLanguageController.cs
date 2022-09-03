using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgramingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgramingLanguageCommand deleteProgramingLanguageCommand)
        {
            DeletedProgramingLanguageDto result = await Mediator.Send(deleteProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            UpdatedProgramingLanguageDto result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            GetByIdProgramingLanguageDto getByIdProgramingLanguageDto = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(getByIdProgramingLanguageDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(result);
        }
    }
}
