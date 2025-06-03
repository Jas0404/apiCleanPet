using apiCleanPet.Models;
using System.Threading.Tasks;

namespace apiCleanPet.Service.Interfaces
{
    public interface ILoginService
    {
        Task<Usuario> AutenticarService(string login, string senha);
        string CriptografarSenha(string senha);
        Task<Usuario> BuscarPorEmailService(string email);
        Task<bool> EnviarChaveAcessoPorEmail(string email);
        string GerarToken(Usuario dadosLogin);
    }
}
