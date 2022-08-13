using Microsoft.AspNetCore.Mvc;
using SmitenightApp.Abstractions.Application.Services.Smitenights;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Server.Controllers
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
        public async Task<IActionResult> Start([FromBody] SmitenightProcessResponseDto smitenightProcessDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _smitenightService.StartSmitenightAsync(smitenightProcessDto.PlayerName);
            return Ok();
        }

        [HttpPost]
        [Route("end")]
        public async Task<IActionResult> End([FromBody] SmitenightProcessResponseDto smitenightProcessDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _smitenightService.EndSmitenightAsync(smitenightProcessDto.PlayerName);
            return Ok();
        }
    }
}