using MediatR;

namespace Biblioteca.Application.Libros.Queries.ConsultarLibroPorId;

public class ConsultarLibroPorIdQuery : IRequest<LibroDetalleDto?>
{
    public int Id { get; set; }

    public ConsultarLibroPorIdQuery(int id)
    {
        Id = id;
    }
}