using System.Text.Json;
using Magma3.API.DTOs;
using Magma3.API.Interfaces;

namespace Magma3.API.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Force1Api");
    }
    
    public async Task<string> GetToken()
    {
        var request = new LoginRequest
        {
            Enterprise = "magma3teste",
            Login = "provadev",
            Password = "Provadev@123123"
        };

        var response = await _httpClient.PostAsJsonAsync("/v2/Auth/Login", request);

        response.EnsureSuccessStatusCode();

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        if (loginResponse is null || !loginResponse.Success)
            throw new Exception("Falha ao autenticar na API.");
        
        return loginResponse.Token;
    }
}