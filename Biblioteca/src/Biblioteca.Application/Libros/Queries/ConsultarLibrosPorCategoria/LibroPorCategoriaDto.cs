namespace Biblioteca.Application.Libros.Queries.ConsultarLibrosPorCategoria;

public class LibroPorCategoriaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int AnioPublicacion { get; set; }
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
}