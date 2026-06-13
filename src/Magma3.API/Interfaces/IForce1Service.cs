using Magma3.API.Models;

namespace Magma3.API.Interfaces;

public interface IForce1Service
{
    Task<List<Asset>> GetInactiveAssets(string assetType, int pagination);
    Task<List<Asset?>> GetAssets();
}