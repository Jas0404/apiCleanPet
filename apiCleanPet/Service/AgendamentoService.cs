using apiCleanPet.Models;
using apiCleanPet.Repositories.IRepositories;
using apiCleanPet.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace apiCleanPet.Service
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _repository;

        public AgendamentoService(IAgendamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Agendamento>> GetAll() => await _repository.GetAllAsync();

        public async Task<Agendamento?> GetById(int id) => await _repository.GetByIdAsync(id);

        public async Task CriarAsync(Agendamento agendamento)
        {
            await _repository.CriarAsync(agendamento);
        }

        public async Task AdicionarServicosAsync(int agendamentoId, List<int> servicosIds)
        {
            await _repository.AdicionarServicosAsync(agendamentoId, servicosIds);
        }

        public async Task<bool> Atualizar(Agendamento agendamento) => await _repository.AtualizarAsync(agendamento);

        public async Task<bool> Excluir(int id) => await _repository.ExcluirAsync(id);
    }
}
