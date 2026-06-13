using Magma3.API.Models;

namespace Magma3.API.DTOs;

public class CriarClienteRequest
{
    public string Nome { get; set; }

    public string Email { get; set; }

    public Cliente ToEntity()
    {
        return new Cliente {Nome = Nome, Email = Email};
    }
}