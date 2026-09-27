using MediatR;
using Biblioteca.Application.Libros;

namespace Biblioteca.Application.Libros.Queries.ConsultarTodosLosLibros;

public class ConsultarTodosLosLibrosQueryHandler
    : IRequestHandler<ConsultarTodosLosLibrosQuery, List<LibroDto>>
{
    private readonly ILibroRepository _libroRepository;

    public ConsultarTodosLosLibrosQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<List<LibroDto>> Handle(
        ConsultarTodosLosLibrosQuery request,
        CancellationToken cancellationToken)
    {
        var libros = await _libroRepository.ObtenerTodosAsync();

        return libros.Select(libro => new LibroDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Isbn = libro.Isbn,
            AnioPublicacion = libro.AnioPublicacion,
            Autor = libro.Autor.Nombre,
            Categoria = libro.Categoria.Nombre
        }).ToList();
    }
}