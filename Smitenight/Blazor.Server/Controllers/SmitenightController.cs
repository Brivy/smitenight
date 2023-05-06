using Microsoft.AspNetCore.Mvc;
using Smitenight.Application.Blazor.Business.Contracts.Services.Smitenights;
using Smitenight.Domain.Models.Contracts.Smitenights;

namespace Smitenight.Presentation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmitenightController : ControllerBase
    {
        private readonly ISmitenightService _smitenightService;

        public SmitenightController(ISmitenightService smitenightService)
        {
            _smitenightService = smitenightService;
        }

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> Start([FromBody] SmitenightProcessDto smitenightProcessRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _smitenightService.StartSmitenightAsync(smitenightProcessRequestDto.PlayerName, smitenightProcessRequestDto.PinCode);
            return Ok(result);
        }

        [HttpPost]
        [Route("end")]
        public async Task<IActionResult> End([FromBody] SmitenightProcessDto smitenightProcessRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _smitenightService.EndSmitenightAsync(smitenightProcessRequestDto.PlayerName, smitenightProcessRequestDto.PinCode);
            return Ok(result);
        }
    }
}