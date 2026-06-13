using Magma3.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.API.Controllers;

[ApiController]
[Route("force1")]
public class Force1Controller : ControllerBase
{
    private readonly IForce1Service _service;

    public Force1Controller(IForce1Service service)
    {
        _service = service;
    }

    [HttpGet("ativos-sem-comunicacao")]
    public async Task<IActionResult> Get(
        [FromQuery] string assetType = "computador",
        [FromQuery] int pagination = 0
    )
    {
        var ativos = await _service.GetInactiveAssets(assetType, pagination);
        return Ok(ativos);
    }
    
    [HttpGet("ativos")]
    public async Task<IActionResult> Get()
    {
        var ativos = await _service.GetAssets();
        return Ok(ativos);
    }
}