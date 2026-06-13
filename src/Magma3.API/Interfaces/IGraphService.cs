using Microsoft.Graph.Models;

namespace Magma3.API.Interfaces;

public interface IGraphService
{
    Task<UserCollectionResponse> GetUsers();
    Task SendMail(string email);
    Task<EventCollectionResponse> GetEvents(string userId);
}