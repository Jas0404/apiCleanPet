using apiCleanPet.Models;

namespace apiCleanPet.Repositories.IRepositories
{
    public interface IAgendamentoRepository
    {
        Task<List<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task CriarAsync(Agendamento agendamento);
        Task<bool> AtualizarAsync(Agendamento agendamento);
        Task<bool> ExcluirAsync(int id);
        Task AdicionarServicosAsync(int agendamentoId, List<int> servicosIds);


    }
}
