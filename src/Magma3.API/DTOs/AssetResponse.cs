using Magma3.API.Models;

namespace Magma3.API.DTOs;

public class AssetResponse
{
    public bool Success { get; set; }
    public List<Asset> Data { get; set; } = [];
}