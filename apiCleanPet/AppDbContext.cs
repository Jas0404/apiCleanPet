using apiCleanPet.Models;
using CadastroPetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<StatusAgendamento> StatusAgendamentos { get; set; }
        public DbSet<AgendamentoServico> AgendamentoServicos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


    }
}
