using Magma3.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.API.Controllers;

[ApiController]
[Route("google")]
public class GoogleMapsController : ControllerBase
{
    private readonly IGoogleMapsService _service;

    public GoogleMapsController(IGoogleMapsService service)
    {
        _service = service;
    }

    [HttpGet("coordinates")]
    public async Task<IActionResult> GetCoordinates(string address)
    {
        return Ok(await _service.GetCoordinates(address));
    }

    [HttpGet("address")]
    public async Task<IActionResult> GetAddress(string cep)
    {
        return Ok(await _service.GetAddress(cep));
    }

    [HttpGet("reverse")]
    public async Task<IActionResult> Reverse(double lat, double lng)
    {
        return Ok(await _service.ReverseGeocode(lat, lng));
    }
}