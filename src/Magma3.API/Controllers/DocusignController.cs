using DocuSign.eSign.Model;
using Magma3.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.API.Controllers;

[ApiController]
[Route("docusign")]
public class DocusignController : ControllerBase
{
    private readonly IDocuSignService _service;

    public DocusignController(IDocuSignService service)
    {
        _service = service;
    }

    [HttpPost("envelopes")]
    public async Task<ActionResult<EnvelopeSummary>> CreateEnvelope()
    {
        var envelope = await _service.CreateEnvelope();

        return Ok(envelope);
    }

    [HttpGet("envelopes/{envelopeId}")]
    public async Task<ActionResult<Envelope>> GetEnvelope(
        string envelopeId)
    {
        var envelope = await _service.GetEnvelope(envelopeId);

        return Ok(envelope);
    }

    [HttpGet("envelopes/{envelopeId}/recipients")]
    public async Task<ActionResult<Recipients>> GetRecipients(
        string envelopeId)
    {
        var recipients = await _service.GetRecipients(envelopeId);

        return Ok(recipients);
    }
}