using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Magma3.API.Models;

public class Cliente
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }
}