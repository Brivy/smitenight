using Microsoft.AspNetCore.Mvc;
using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;

namespace Smitenight.Presentation.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MaintenanceController(IMaintainSmitenight maintainSmitenight) : ControllerBase
{
    private readonly IMaintainSmitenight _maintainSmitenight = maintainSmitenight;

    /// <summary>
    /// Manually search and apply the latest SMITE patch
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> MaintainPatch()
    {
        await _maintainSmitenight.MaintainPatchesAsync(CancellationToken.None);
        await _maintainSmitenight.MaintainGodsAsync(CancellationToken.None);
        await _maintainSmitenight.MaintainItemsAsync(CancellationToken.None);
        return Ok();
    }
}
