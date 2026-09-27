using MediatR;
using Biblioteca.Application.Libros;

namespace Biblioteca.Application.Libros.Queries.ConsultarLibrosPorCategoria;

public class ConsultarLibrosPorCategoriaQueryHandler
    : IRequestHandler<ConsultarLibrosPorCategoriaQuery, List<LibroPorCategoriaDto>>
{
    private readonly ILibroRepository _libroRepository;

    public ConsultarLibrosPorCategoriaQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<List<LibroPorCategoriaDto>> Handle(
        ConsultarLibrosPorCategoriaQuery request,
        CancellationToken cancellationToken)
    {
        var libros = await _libroRepository.ObtenerPorCategoriaAsync(request.CategoriaId);

        return libros.Select(libro => new LibroPorCategoriaDto
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