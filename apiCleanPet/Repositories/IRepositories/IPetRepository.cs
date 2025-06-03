using CadastroPetAPI.Models;

namespace CadastroPetAPI.Repositories
{
    public interface IPetRepository
    {
        Task CadastrarPetAsync(Pet pet);
    }
}