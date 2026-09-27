using MediatR;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Libros.Queries.ConsultarTodosLosLibros;
using Biblioteca.Application.Libros.Queries.ConsultarLibroPorId;
using Biblioteca.Application.Libros.Queries.ConsultarLibrosPorCategoria;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibrosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LibroDto>>> ConsultarTodos()
    {
        var resultado = await _mediator.Send(new ConsultarTodosLosLibrosQuery());
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LibroDetalleDto>> ConsultarPorId(int id)
    {
        var resultado = await _mediator.Send(new ConsultarLibroPorIdQuery(id));

        if (resultado is null)
        {
            return NotFound();
        }

        return Ok(resultado);
    }

    [HttpGet("categoria/{categoriaId}")]
    public async Task<ActionResult<List<LibroPorCategoriaDto>>> ConsultarPorCategoria(int categoriaId)
    {
        var resultado = await _mediator.Send(new ConsultarLibrosPorCategoriaQuery(categoriaId));
        return Ok(resultado);
    }
}