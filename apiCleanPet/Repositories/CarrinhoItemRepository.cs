using apiCleanPet.Models;
using apiCleanPet;
using Microsoft.EntityFrameworkCore;
using apiCleanPet.Repositories;

namespace apiCarrinho.Repositories
{
    public class CarrinhoItemRepository : ICarrinhoItemRepository
    {
        private readonly AppDbContext _context;

        public CarrinhoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarrinhoItem>> GetCarrinhoPorUsuario(int usuarioId)
        {
            return await _context.CarrinhoItens
                .Where(i => i.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<CarrinhoItem> GetPorId(int id)
        {
            return await _context.CarrinhoItens.FindAsync(id);
        }

        public async Task<CarrinhoItem> Adicionar(CarrinhoItem item)
        {
            item.DataCadastro = DateTime.UtcNow;
            _context.CarrinhoItens.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Atualizar(CarrinhoItem item)
        {
            var existente = await _context.CarrinhoItens.FindAsync(item.Id);
            if (existente == null) return false;

            _context.Entry(existente).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var item = await _context.CarrinhoItens.FindAsync(id);
            if (item == null) return false;

            _context.CarrinhoItens.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
