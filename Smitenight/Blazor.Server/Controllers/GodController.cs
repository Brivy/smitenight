using Microsoft.AspNetCore.Mvc;
using Smitenight.Application.Blazor.Business.Contracts.Services.Gods;

namespace Smitenight.Presentation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GodController : ControllerBase
    {
        private readonly IGodService _godService;

        public GodController(IGodService godService)
        {
            _godService = godService;
        }

        [HttpGet]
        [Route("skins/home/loading")]
        public async Task<IActionResult> ListHomeLoadingSkins()
        {
            var result = await _godService.ListHomeLoadingSkinsAsync();
            return Ok(result);
        }
    }
}
