using Magma3.API.Interfaces;
using Magma3.API.Models;
using MongoDB.Driver;

namespace Magma3.API.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IMongoCollection<Cliente> _collection;
    
    public ClienteRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
        var database = client.GetDatabase(configuration["MongoDb:Database"]);

        _collection = database.GetCollection<Cliente>("clientes");
    }
    
    public List<Cliente> ObterTodos()
    {
        return _collection.Find(_ => true).ToList();
    }

    public void Adicionar(Cliente cliente)
    {
        _collection.InsertOne(cliente);
    }
}