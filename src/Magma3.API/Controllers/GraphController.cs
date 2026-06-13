// using Magma3.API.Interfaces;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Magma3.API.Controllers;
//
// [ApiController]
// [Route("graph")]
// public class GraphController : ControllerBase
// {
//     private readonly IGraphService _service;
//
//     public GraphController(IGraphService service)
//     {
//         _service = service;
//     }
//
//     [HttpGet("users")]
//     public async Task<IActionResult> Users()
//     {
//         return Ok(await _service.GetUsers());
//     }
//
//     [HttpPost("send-email")]
//     public async Task<IActionResult> SendEmail()
//     {
//         await _service.SendEmail(
//             "teste@email.com",
//             "Assunto",
//             "Mensagem");
//
//         return Ok();
//     }
//
//     [HttpGet("events")]
//     public async Task<IActionResult> Events()
//     {
//         return Ok(await _service.GetCalendarEvents());
//     }
// }