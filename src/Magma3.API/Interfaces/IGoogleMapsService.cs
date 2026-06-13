using GoogleMaps.LocationServices;

namespace Magma3.API.Interfaces;

public interface IGoogleMapsService
{
    Task<MapPoint> GetAddress(string cep);
    Task<string> GetCoordinates(string address);
    Task<AddressData> ReverseGeocode(double latitude, double longitude);
}