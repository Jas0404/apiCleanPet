using apiCleanPet.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
