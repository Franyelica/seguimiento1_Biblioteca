namespace Biblioteca.Domain.Entities;

public class Autor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    // Un autor puede tener muchos libros
    public ICollection<Libro> Libros { get; set; } = new List<Libro>();
}