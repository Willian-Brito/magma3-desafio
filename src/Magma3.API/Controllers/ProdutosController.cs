using Magma3.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.API.Controllers;

[ApiController]
[Route("produtos")]
public class ProdutosController : ControllerBase
{
    private static readonly List<Produto> Produtos =
    [
        new Produto
        {
            Id = 1,
            Nome = "Notebook",
            Preco = 3500
        }
    ];
    
    [HttpGet]
    public ActionResult<List<Produto>> Get()
    {
        return Ok(Produtos);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Produto produto)
    {
        Produtos.Add(produto);

        return CreatedAtAction(
            nameof(Get),
            new { id = produto.Id },
            produto);
    }
}