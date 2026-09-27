using MediatR;
using Biblioteca.Application.Libros;

namespace Biblioteca.Application.Libros.Queries.ConsultarLibroPorId;

public class ConsultarLibroPorIdQueryHandler
    : IRequestHandler<ConsultarLibroPorIdQuery, LibroDetalleDto?>
{
    private readonly ILibroRepository _libroRepository;

    public ConsultarLibroPorIdQueryHandler(ILibroRepository libroRepository)
    {
        _libroRepository = libroRepository;
    }

    public async Task<LibroDetalleDto?> Handle(
        ConsultarLibroPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var libro = await _libroRepository.ObtenerPorIdAsync(request.Id);

        if (libro is null)
        {
            return null;
        }

        return new LibroDetalleDto
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            Isbn = libro.Isbn,
            AnioPublicacion = libro.AnioPublicacion,
            Autor = libro.Autor.Nombre,
            Categoria = libro.Categoria.Nombre
        };
    }
}