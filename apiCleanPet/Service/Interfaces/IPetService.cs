using CadastroPetAPI.Models;

namespace CadastroPetAPI.Services
{
    public interface IPetService
    {
        Task CadastrarPetAsync(Pet pet);
    }
}