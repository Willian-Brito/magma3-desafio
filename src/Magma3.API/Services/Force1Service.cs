using System.Text.Json;
using Magma3.API.DTOs;
using Magma3.API.Interfaces;
using Magma3.API.Models;

namespace Magma3.API.Services;

public class Force1Service : IForce1Service
{
    private readonly HttpClient _httpClient;
    private readonly IAuthService _authService;

    public Force1Service(IHttpClientFactory factory, IAuthService authService)
    {
        _httpClient = factory.CreateClient("Force1Api");
        _authService = authService;
    }

    public async Task<List<Asset>> GetInactiveAssets(string assetType, int pagination)
    {
        var token = await _authService.GetToken();
        var cookie = token.Split(';')[0];
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"/v2/Force1/GetAssets?assetType={assetType}&pagination={pagination}");
        request.Headers.TryAddWithoutValidation("Cookie", cookie);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var assets = JsonSerializer.Deserialize<AssetResponse>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
    
        if (assets?.Data == null)
            return [];

        return assets.Data
            .Where(x =>
                x.LastCommunication.HasValue &&
                x.LastCommunication.Value <
                DateTime.UtcNow.AddDays(-60))
            .ToList();
    }
    
    public async Task<List<Asset?>> GetAssets()
    {
        var token = await _authService.GetToken();
        var cookie = token.Split(';')[0];
        var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/Force1/GetAssets");

        request.Headers.TryAddWithoutValidation("Cookie", cookie);

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<AssetResponse>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        return result?.Data ?? new List<Asset>();
    }
}