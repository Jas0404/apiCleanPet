using System.Threading.Tasks;

namespace apiCleanPet.Service.Interfaces
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(string email, string assunto, string corpo);
    }
}
