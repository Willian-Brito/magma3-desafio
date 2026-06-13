using Azure.Identity;
using Magma3.API.Interfaces;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Magma3.API.Services;

public class GraphService : IGraphService
{
    private readonly GraphServiceClient _client;

    public GraphService(IConfiguration configuration)
    {
        var credential = new ClientSecretCredential(
            configuration["MicrosoftGraph:TenantId"],
            configuration["MicrosoftGraph:ClientId"],
            configuration["MicrosoftGraph:ClientSecret"]
        );

        _client = new GraphServiceClient(credential);
    }
    public async Task<UserCollectionResponse> GetUsers()
    {
        return await _client.Users.GetAsync();
    }

    public async Task SendMail(string email)
    {
        var message = new Microsoft.Graph.Models.Message
        {
            Subject = "Teste SDK",
            Body = new ItemBody
            {
                Content = "Mensagem enviada pelo SDK",
                ContentType = BodyType.Text
            },
            ToRecipients =
            [
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = email
                    }
                }
            ]
        };

        await _client.Me.SendMail.PostAsync(
            new Microsoft.Graph.Me.SendMail.SendMailPostRequestBody { Message = message }
        );
    }

    public async Task<EventCollectionResponse> GetEvents(string userId)
    {
        return await _client.Users[userId].Events.GetAsync();
    }
}