using apiCleanPet.Models;

namespace apiCleanPet.Service.Interfaces
{
    public interface IAgendamentoService
    {
        Task<List<Agendamento>> GetAll();
        Task<Agendamento?> GetById(int id);
        Task CriarAsync(Agendamento agendamento);

        Task AdicionarServicosAsync(int agendamentoId, List<int> servicosIds);
        Task<bool> Atualizar(Agendamento agendamento);
        Task<bool> Excluir(int id);
    }
}
