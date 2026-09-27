using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Libros;

public interface ILibroRepository
{
    Task<List<Libro>> ObtenerTodosAsync();
    Task<Libro?> ObtenerPorIdAsync(int id);
    Task<List<Libro>> ObtenerPorCategoriaAsync(int categoriaId);
}