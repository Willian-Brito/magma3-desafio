using GoogleMaps.LocationServices;
using Magma3.API.Interfaces;

namespace Magma3.API.Services;

public class GoogleMapsService : IGoogleMapsService
{
    private readonly IConfiguration _configuration;

    public GoogleMapsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<MapPoint> GetAddress(string cep)
    {
        var service = new GoogleLocationService(_configuration["GoogleMaps:ApiKey"]);
        var point = service.GetLatLongFromAddress(cep);
        return Task.FromResult(point);
    }

    public Task<string> GetCoordinates(string address)
    {
        throw new NotImplementedException();
    }

    public Task<AddressData> ReverseGeocode(double latitude, double longitude)
    {
        var service = new GoogleLocationService(_configuration["GoogleMaps:ApiKey"]);
        var result = service.GetAddressFromLatLang(latitude, longitude);
        
        return Task.FromResult(result);
    }
}