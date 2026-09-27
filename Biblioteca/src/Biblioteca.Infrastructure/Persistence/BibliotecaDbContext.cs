using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Infrastructure.Persistence;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Libro> Libros => Set<Libro>();
    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Categoria> Categorias => Set<Categoria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Autor)
            .WithMany(a => a.Libros)
            .HasForeignKey(l => l.AutorId);

        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Categoria)
            .WithMany(c => c.Libros)
            .HasForeignKey(l => l.CategoriaId);

        base.OnModelCreating(modelBuilder);
    }
}