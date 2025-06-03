using CadastroPetAPI.Models;
using CadastroPetAPI.Repositories;

namespace CadastroPetAPI.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task CadastrarPetAsync(Pet pet)
        {
            await _petRepository.CadastrarPetAsync(pet);
        }
    }
}
