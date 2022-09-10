using Application.Features.Developers.Commands.CreateDeveloper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateDeveloperCommand createDeveloperCommand)
        {
            var result = await Mediator.Send(createDeveloperCommand);
            return Ok(result);
        }
    }
}
