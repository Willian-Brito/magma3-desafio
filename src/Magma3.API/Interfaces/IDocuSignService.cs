using DocuSign.eSign.Model;

namespace Magma3.API.Interfaces;

public interface IDocuSignService
{
    Task<EnvelopeSummary> CreateEnvelope();
    Task<Envelope> GetEnvelope(string envelopeId);
    Task<Recipients> GetRecipients(string envelopeId);
}