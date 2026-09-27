using MediatR;

namespace Biblioteca.Application.Libros.Queries.ConsultarLibrosPorCategoria;

public class ConsultarLibrosPorCategoriaQuery : IRequest<List<LibroPorCategoriaDto>>
{
    public int CategoriaId { get; set; }

    public ConsultarLibrosPorCategoriaQuery(int categoriaId)
    {
        CategoriaId = categoriaId;
    }
}