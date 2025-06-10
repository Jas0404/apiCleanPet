using apiCleanPet.Models;

namespace apiCleanPet.Services
{
    public interface IServicoService
    {
        Task<List<Servico>> GetTodos();
        Task<Servico?> GetPorId(int id);
        Task<Servico> Adicionar(Servico servico);
        Task<bool> Atualizar(Servico servico);
        Task<bool> Remover(int id);
    }
}
