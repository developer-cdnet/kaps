using Kaps.Application.Services.KkbService;
using Kaps.Domain.Kkb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Kaps.API.Controllers;

[Route("api/v1/kkb")]
[ApiController]
public class KkbController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(KapsCreateNotificationRequest), 200)]
    public async Task<IActionResult> CreateNotificationAsync([FromServices] IKkbService kkbService, [FromBody] KapsCreateNotificationRequest request, CancellationToken cancellationToken = default)
    {
        var result = await kkbService.CreateNotification(request, cancellationToken);
        return Ok(result);
    }
}