using apiCleanPet.Models;

namespace apiCleanPet.Repositories
{
    public interface IServicoRepository
    {
        Task<List<Servico>> GetAllAsync();
        Task<Servico?> GetByIdAsync(int id);
        Task CriarAsync(Servico servico);
        Task<bool> AtualizarAsync(Servico servico);
        Task<bool> ExcluirAsync(int id);
    }
}
