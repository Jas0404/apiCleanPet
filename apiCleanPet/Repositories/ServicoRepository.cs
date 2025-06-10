using apiCleanPet.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AppDbContext _context;

        public ServicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servico>> GetAllAsync()
        {
            return await _context.Servicos.ToListAsync();
        }

        public async Task<Servico?> GetByIdAsync(int id)
        {
            return await _context.Servicos.FindAsync(id);
        }

        public async Task CriarAsync(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AtualizarAsync(Servico servico)
        {
            if (!await _context.Servicos.AnyAsync(s => s.Id == servico.Id))
                return false;

            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
                return false;

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
