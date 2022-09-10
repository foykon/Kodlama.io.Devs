using Application.Features.GitHubProfiles.Commands.CreateGitHubProfile;
using Application.Features.GitHubProfiles.Dtos;
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
    }
}
