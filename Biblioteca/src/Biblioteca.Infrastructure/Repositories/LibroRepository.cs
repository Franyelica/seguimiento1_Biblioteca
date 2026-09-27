using Microsoft.EntityFrameworkCore;
using Biblioteca.Application.Libros;
using Biblioteca.Domain.Entities;
using Biblioteca.Infrastructure.Persistence;

namespace Biblioteca.Infrastructure.Repositories;

public class LibroRepository : ILibroRepository
{
    private readonly BibliotecaDbContext _context;

    public LibroRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<List<Libro>> ObtenerTodosAsync()
    {
        return await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .ToListAsync();
    }

    public async Task<Libro?> ObtenerPorIdAsync(int id)
    {
        return await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<List<Libro>> ObtenerPorCategoriaAsync(int categoriaId)
    {
        return await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .Where(l => l.CategoriaId == categoriaId)
            .ToListAsync();
    }
}
