using apiCleanPet.Models;
using apiCleanPet.Repositories;

namespace apiCleanPet.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repository;

        public ServicoService(IServicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Servico>> GetTodos()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Servico?> GetPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Servico> Adicionar(Servico servico)
        {
            await _repository.CriarAsync(servico);
            return servico;
        }

        public async Task<bool> Atualizar(Servico servico)
        {
            return await _repository.AtualizarAsync(servico);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repository.ExcluirAsync(id);
        }
    }
}
