using MediatR;

namespace Biblioteca.Application.Libros.Queries.ConsultarTodosLosLibros;

public class ConsultarTodosLosLibrosQuery : IRequest<List<LibroDto>>
{
}