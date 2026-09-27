using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biblioteca.Infrastructure.Persistence;

public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
{
    public BibliotecaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BibliotecaDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=BibliotecaDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new BibliotecaDbContext(optionsBuilder.Options);
    }
}