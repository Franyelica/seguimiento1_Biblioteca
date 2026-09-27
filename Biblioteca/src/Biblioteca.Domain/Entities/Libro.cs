namespace Biblioteca.Domain.Entities;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int AnioPublicacion { get; set; }

    // Relación con Autor (clave foránea)
    public int AutorId { get; set; }
    public Autor Autor { get; set; } = null!;

    // Relación con Categoría (clave foránea)
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;
}