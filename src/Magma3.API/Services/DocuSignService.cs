using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Magma3.API.Interfaces;

namespace Magma3.API.Services;

public class DocuSignService : IDocuSignService
{
    private readonly IConfiguration _configuration;

    public DocuSignService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private EnvelopesApi GetApi()
    {
        var apiClient = new ApiClient(_configuration["DocuSign:BasePath"]);
        var accessToken = _configuration["DocuSign:AccessToken"];
        var config = new DocuSign.eSign.Client.Configuration
        {
            ApiClient = apiClient
        };

        config.DefaultHeader.Add("Authorization", $"Bearer {accessToken}");

        return new EnvelopesApi(config);
    }
    public async Task<EnvelopeSummary> CreateEnvelope()
    {
        var api = GetApi();
        var accountId = _configuration["DocuSign:AccountId"];
        var envelope = new EnvelopeDefinition
        {
            EmailSubject = "Teste SDK",
            Status = "created"
        };

        return await api.CreateEnvelopeAsync(accountId, envelope);
    }

    public async Task<Envelope> GetEnvelope(string envelopeId)
    {
        var api = GetApi();
        var accountId = _configuration["DocuSign:AccountId"];
        
        return await api.GetEnvelopeAsync(accountId, envelopeId);
    }

    public async Task<Recipients> GetRecipients(string envelopeId)
    {
        var api = GetApi();
        var accountId = _configuration["DocuSign:AccountId"];
        
        return await api.ListRecipientsAsync(accountId, envelopeId);
    }
}