using Magma3.API.DTOs;
using Magma3.API.Interfaces;
using Magma3.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.API.Controllers;

[ApiController]
[Route("clientes")]
public class ClientesController : ControllerBase
{
    private readonly IClienteRepository _repository;

    public ClientesController(IClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.ObterTodos());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CriarClienteRequest cliente)
    {
        _repository.Adicionar(cliente.ToEntity());

        return Created("", cliente);
    }
}