using Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Application.Features.GitHubProfiles.Commands.DeleteGitHubProfile;
using Application.Features.GitHubProfiles.Commands.UpdateGitHubProfile;
using Application.Features.GitHubProfiles.Dtos;
using Application.Features.GitHubProfiles.Models;
using Application.Features.GitHubProfiles.Queries.ListGitHubProfile;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfileController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(CreateGitHubProfileCommand createGitHubProfileCommand)
        {
            CreatedGitHubProfileDto createdGitHubProfileDto = await Mediator.Send(createGitHubProfileCommand);
            return Ok(createdGitHubProfileDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteGitHubProfileCommand deleteGitHubProfileCommand)
        {
            DeletedGitHubProfileDto deletedGitHubProfileDto = await Mediator.Send(deleteGitHubProfileCommand);
            return Ok(deletedGitHubProfileDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGitHubProfileCommand updateGitHubProfileCommand)
        {
            UpdatedGitHubProfileDto updatedGitHubProfileDto = await Mediator.Send(updateGitHubProfileCommand);
            return Ok(updatedGitHubProfileDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            ListGitHubProfileQuery listGitHubProfileQuery = new() { PageRequest = pageRequest };

            GitHubProfileListModel gitHubProfileListModel = await Mediator.Send(listGitHubProfileQuery);

            return Ok(gitHubProfileListModel);
        }
    }
}
