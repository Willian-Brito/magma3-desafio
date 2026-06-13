using System.Text.Json.Serialization;

namespace Magma3.API.Models;

public class Asset
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("Agent.DataLastCommunication")]
    public DateTime? LastCommunication { get; set; }
}