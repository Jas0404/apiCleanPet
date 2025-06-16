using apiCleanPet.Models;
using System.Threading.Tasks;

namespace apiCleanPet.Repositories.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> Autenticar(string email, string senha);
        Task<Usuario> BuscarPorEmail(string email);
        Task<bool> AtualizarUsuario(Usuario usuario);
    }
}
