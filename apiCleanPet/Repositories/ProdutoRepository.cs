using apiCleanPet.Models;
using Microsoft.EntityFrameworkCore;
namespace apiCleanPet.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> GetPorCategoriaAsync(string animal, string categoria, string subcategoria)
        {
            return await _context.Produtos
                .Where(p => p.Animal == animal && p.Categoria == categoria && p.Subcategoria == subcategoria)
                .ToListAsync();
        }

        public async Task CriarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AtualizarAsync(Produto produto)
        {
            if (!await _context.Produtos.AnyAsync(p => p.Id == produto.Id))
                return false;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Produto>> BuscarPorNome(string nome)
        {
            return await _context.Produtos
                .Where(p => p.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}