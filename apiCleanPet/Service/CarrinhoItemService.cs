using apiCleanPet.Models;
using apiCleanPet.Repositories;
using apiCleanPet.Services;

namespace apiCleanPet.Services
{
    public class CarrinhoItemService : ICarrinhoItemService
    {
        private readonly ICarrinhoItemRepository _repository;

        public CarrinhoItemService(ICarrinhoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CarrinhoItem>> GetCarrinho(int usuarioId)
        {
            return await _repository.GetCarrinhoPorUsuario(usuarioId);
        }

        public async Task<CarrinhoItem> GetItem(int id)
        {
            return await _repository.GetPorId(id);
        }

        public async Task<CarrinhoItem> Adicionar(CarrinhoItem item)
        {
            return await _repository.Adicionar(item);
        }

        public async Task<bool> Atualizar(CarrinhoItem item)
        {
            return await _repository.Atualizar(item);
        }

        public async Task<bool> Remover(int id)
        {
            return await _repository.Remover(id);
        }
    }
}
