using Magma3.API.Models;

namespace Magma3.API.Interfaces;

public interface IClienteRepository
{
    List<Cliente> ObterTodos();
    void Adicionar(Cliente cliente);
}