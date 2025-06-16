using apiCleanPet.Models;
using apiCleanPet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AppDbContext _context;

        public AgendamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> GetAllAsync()
        {
            return await _context.Agendamentos
         .Include(a => a.Usuario)
         .Include(a => a.Servicos)
             .ThenInclude(asv => asv.Servico)
         .Include(a => a.Status)
         .ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _context.Agendamentos
             .Include(a => a.Usuario) // carrega o usuário completo
             .Include(a => a.Servicos)
                 .ThenInclude(asv => asv.Servico)
             .Include(a => a.Status)
             .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CriarAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AtualizarAsync(Agendamento agendamento)
        {
            if (!_context.Agendamentos.Any(a => a.Id == agendamento.Id)) return false;

            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null) return false;

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task AdicionarServicosAsync(int agendamentoId, List<int> servicosIds)
        {
            foreach (var servicoId in servicosIds)
            {
                var agendamentoServico = new AgendamentoServico
                {
                    AgendamentoId = agendamentoId,
                    ServicoId = servicoId
                };
                _context.AgendamentoServicos.Add(agendamentoServico);
            }
            await _context.SaveChangesAsync();
        }
    }
}